using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.mariabyrrrrak;
using System.Diagnostics;
using System.Text.Json;

namespace Study.Lab2.Logic.mariabyrrrrak;

public sealed class mariabyrrrrakService : IRunService
{
    private readonly string[] _urls =
    {
        "https://api.kanye.rest/",
        "https://uselessfacts.jsph.pl/random.json?language=en",
        "https://zenquotes.io/api/random"
    };

    private readonly IRequestService _requestService;

    public mariabyrrrrakService() : this(new RequestService(new HttpClient())) { }

    public mariabyrrrrakService(IRequestService requestService) =>
        _requestService = requestService;

    public void RunTask()
    {
        Console.WriteLine("\nSynchronous launch\n");
        ExecuteRequests(asyncMode: false).GetAwaiter().GetResult();
    }

    public Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\nAsynchronous launch\n");
        return ExecuteRequests(asyncMode: true, cancellationToken);
    }

    private async Task ExecuteRequests(bool asyncMode, CancellationToken ct = default)
    {
        var sw = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Sending {_urls.Length} request");
            Console.ResetColor();

            if (asyncMode)
            {
                var tasks = _urls.Select(u => _requestService.FetchDataAsync(u, ct));
                responses.AddRange(await Task.WhenAll(tasks));
            }
            else
            {
                foreach (var url in _urls)
                    responses.Add(_requestService.FetchData(url));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAll responses have been received successfully\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            sw.Stop();
            PrintResponses(responses);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nКequest completion time: {sw.ElapsedMilliseconds} ms");
            Console.ResetColor();
        }
    }

    private static void PrintResponses(IEnumerable<string> rawResponses)
    {
        int i = 1;
        foreach (var raw in rawResponses)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Response #{i}:");
            Console.ResetColor();

            try
            {
                using var doc = JsonDocument.Parse(raw);
                var root = doc.RootElement;

                string text = ExtractTextFromJson(root);

                Console.WriteLine(text);
            }
            catch (JsonException)
            {
                // Если не JSON — просто выводим как есть
                Console.WriteLine(raw);
            }

            Console.WriteLine(new string('-', 80));
            i++;
        }
    }

    private static string ExtractTextFromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("quote") || prop.NameEquals("text") || prop.NameEquals("q"))
                {
                    if (prop.Value.ValueKind is JsonValueKind.String)
                        return prop.Value.GetString()!;
                }

                // Рекурсивно ищем нужное поле
                var result = ExtractTextFromJson(prop.Value);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
        }
        else if (element.ValueKind == JsonValueKind.Array && element.GetArrayLength() > 0)
        {
            return ExtractTextFromJson(element[0]);
        }

        return string.Empty;
    }

    public void Dispose() => _requestService.Dispose();
}
