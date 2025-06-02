using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.PresvyatoyKabachok;
using System.Diagnostics;
using System.Text.Json;

namespace Study.Lab2.Logic.PresvyatoyKabachok;

/// <summary>
/// Реализация задания «HTTP-запросы» для PresvyatoyKabachok.
/// Делает три запроса: шутка Чака Норриса, совет дня и факт о котиках.
/// </summary>
public sealed class PresvyatoyKabachokService : IRunService
{
    private readonly string[] _urls =
    {
        "https://api.chucknorris.io/jokes/random",   // joke.value
        "https://api.adviceslip.com/advice",         // slip.advice
        "https://catfact.ninja/fact"                 // fact
    };

    private readonly IRequestService _requestService;

    public PresvyatoyKabachokService() : this(new RequestService(new HttpClient())) { }

    public PresvyatoyKabachokService(IRequestService requestService) =>
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

                string text = root.TryGetProperty("value", out var cn)
                              ? cn.GetString()!
                              : root.TryGetProperty("slip", out var slip) && slip.TryGetProperty("advice", out var advice)
                                ? advice.GetString()!
                                : root.TryGetProperty("fact", out var fact)
                                  ? fact.GetString()!
                                  : root.ToString();

                Console.WriteLine(text);
            }
            catch
            {
                Console.WriteLine(raw); // если не JSON
            }

            Console.WriteLine(new string('-', 80));
            i++;
        }
    }

    public void Dispose() => _requestService.Dispose();
}
