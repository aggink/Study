using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.cocobara;
using System.Diagnostics; 
using System.Text.Json;

namespace Study.Lab2.Logic.cocobara;
 
public sealed class cocobaraService : IRunService
{
    private readonly string[] _urls =
    {
        "https://official-joke-api.appspot.com/random_joke",
        "https://randomuser.me/api/?inc=name,gender,email",
        "https://catfact.ninja/fact"
    };

    private readonly IRequestService _requestService;

    public cocobaraService() : this(new RequestService(new HttpClient())) { }

    public cocobaraService(IRequestService requestService) =>
        _requestService = requestService;

    public void RunTask()
    {
        Console.WriteLine("\nСинхронный запуск…\n");
        ExecuteRequests(asyncMode: false).GetAwaiter().GetResult();
    }

    public Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\nАсинхронный запуск…\n");
        return ExecuteRequests(asyncMode: true, cancellationToken);
    }

    private async Task ExecuteRequests(bool asyncMode, CancellationToken ct = default)
    {
        var sw = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Отправляем {_urls.Length} запрос(а/ов) …");
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
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            sw.Stop();
            PrintResponses(responses);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nВремя выполнения: {sw.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    private static void PrintResponses(IEnumerable<string> rawResponses)
    {
        int i = 1;
        foreach (var raw in rawResponses)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Ответ #{i}:");
            Console.ResetColor();

            try
            {
                using var doc = JsonDocument.Parse(raw);
                var root = doc.RootElement;

                string text = root.TryGetProperty("setup", out var setup)
                               ? $"{setup.GetString()}\n{root.GetProperty("punchline").GetString()}"
                               : root.TryGetProperty("results", out var results)
                                 ? FormatUserInfo(results[0])
                                 : root.TryGetProperty("fact", out var fact)
                                   ? fact.GetString()!
                                   : root.ToString();

                Console.WriteLine(text);
            }
            catch
            {
                Console.WriteLine(raw);
            }

            Console.WriteLine(new string('-', 80));
            i++;
        }
    }

    private static string FormatUserInfo(JsonElement user)
    {
        var name = user.GetProperty("name");
        return $"Имя: {name.GetProperty("first").GetString()} {name.GetProperty("last").GetString()}\n" +
               $"Пол: {user.GetProperty("gender").GetString()}\n" +
               $"Email: {user.GetProperty("email").GetString()}";
    }

    public void Dispose() => _requestService.Dispose();
}
