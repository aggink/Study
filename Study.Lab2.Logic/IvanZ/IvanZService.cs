using Study.Lab2.Logic.Interfaces.IvanZ;
using System.Diagnostics;

namespace Study.Lab2.Logic.IvanZ;

public class IvanZService : IRunService
{
    private readonly IRequestService _requestService;

    public IvanZService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    private readonly string[] urls = new string[]
    {
        "https://random-word-api.herokuapp.com/word?lang=zh",
        "https://random-word-api.herokuapp.com/word?number=42",
        "https://random-word-api.herokuapp.com/word?length=7"
    };

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос..\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var responses = new List<string>();

            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine($"Запрос {i + 1}: {urls[i]}");

                var response = _requestService.FetchData(urls[i]);
                responses.Add(response);
            }

            Console.WriteLine("\nВсе ответы успешно получены!\n");

            for (int i = 0; i < responses.Count; i++)
            {
                Console.WriteLine($"{GetRequestDescription(i)}: {responses[i]}");
                Console.WriteLine(new string('-', 50));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
        }
        finally
        {
            stopwatch.Stop();
            Console.WriteLine($"\nВремя выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("\nВыполняется асинхронный запрос..\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var tasks = new Task<string>[urls.Length];

            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine($"Запрос {i + 1}: {urls[i]}");
                tasks[i] = _requestService.FetchDataAsync(urls[i], cancellationToken);
            }

            var responses = await Task.WhenAll(tasks);

            Console.WriteLine("\nВсе ответы успешно получены!\n");

            for (int i = 0; i < responses.Length; i++)
            {
                Console.WriteLine($"{GetRequestDescription(i)}: {responses[i]}");
                Console.WriteLine(new string('-', 50));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
        }
        finally
        {
            stopwatch.Stop();
            Console.WriteLine($"\nВремя выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
    }

    private string GetRequestDescription(int index)
    {
        return index switch
        {
            0 => "случайно китайское слово",
            1 => "случайные 42 слова",
            2 => "случайное слово из 7 букв",
            _ => "неизвестный запрос"
        };
    }

    public void Dispose()
    {
        _requestService.Dispose();
    }
}
