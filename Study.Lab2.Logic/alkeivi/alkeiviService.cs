using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.alkeivi;
using System.Diagnostics;

namespace Study.Lab2.Logic.alkeivi;

public class alkeiviService : IRunService
{
    private readonly IRequestService _requestService;

    public alkeiviService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    private readonly string[] urls = new string[]
    {
        "https://random-word-api.herokuapp.com/word?number=12",
        "https://random-word-api.herokuapp.com/word?lang=es",
        "https://random-word-api.herokuapp.com/word?length=12"
    };

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос к Random Word API...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var responses = new List<string>();

            for (int i = 0; i < urls.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Запрос {i + 1}: {urls[i]}");
                Console.ResetColor();

                var response = _requestService.FetchData(urls[i]);
                responses.Add(response);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            for (int i = 0; i < responses.Count; i++)
            {
                Console.WriteLine($"{GetRequestDescription(i)}: {responses[i]}");
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
        Console.WriteLine("\nВыполняется асинхронный запрос к Random Word API...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var tasks = new Task<string>[urls.Length];

            for (int i = 0; i < urls.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Запрос {i + 1}: {urls[i]}");
                Console.ResetColor();

                tasks[i] = _requestService.FetchDataAsync(urls[i], cancellationToken);
            }

            var responses = await Task.WhenAll(tasks);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            for (int i = 0; i < responses.Length; i++)
            {
                Console.WriteLine($"{GetRequestDescription(i)}: {responses[i]}");
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

    private string GetRequestDescription(int index)
    {
        return index switch
        {
            0 => "Случайные 12 слов",
            1 => "Случайное испанское слово",
            2 => "Случайное слово из 12 букв",
            _ => "Неизвестный запрос"
        };
    }

    public void Dispose()
    {
        _requestService.Dispose();
    }
}