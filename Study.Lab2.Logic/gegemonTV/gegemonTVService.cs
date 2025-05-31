using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.gegemonTV;
using System.Diagnostics;

namespace Study.Lab2.Logic.gegemonTV;

public class gegemonTVService : IRunService
{
    private readonly IRequestService _requestService;

    private readonly string[] Urls = new string[]
    {
        "http://api.weatherapi.com/v1/current.json?key=f7d95013b8ee420681083144250805&q=Moscow",
        "http://universities.hipolabs.com/search?name=Technion&country=israel",
        "https://jsonplaceholder.typicode.com/posts/1"
    };

    public gegemonTVService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var responses = new List<string>();

            for (int i = 0; i < Urls.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Запрос {i + 1}: {Urls[i]}");
                Console.ResetColor();

                var response = _requestService.FetchData(Urls[i]);
                responses.Add(response);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            foreach (var response in responses)
            {
                Console.WriteLine(JsonHelper.FormatJson(response.Replace('\n', ' ').Replace("\r", string.Empty).Replace("\t", string.Empty)));
                Console.WriteLine(new string('-', 50));
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("\nВыполняется асинхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var tasks = new Task<string>[Urls.Length];

            for (int i = 0; i < Urls.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Запрос {i + 1}: {Urls[i]}");
                Console.ResetColor();

                tasks[i] = _requestService.FetchDataAsync(Urls[i], cancellationToken);
            }

            var responses = await Task.WhenAll(tasks);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            foreach (var response in responses)
            {
                Console.WriteLine(JsonHelper.FormatJson(response.Replace('\n', ' ').Replace("\r", string.Empty).Replace("\t", string.Empty)));
                Console.WriteLine(new string('-', 50));
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public void Dispose()
    {
        _requestService.Dispose();
    }
}

