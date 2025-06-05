using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.freaxd;
using System.Diagnostics;

namespace Study.Lab2.Logic.freaxd;

public class freaxdService : IRunService
{
    private readonly IRequestService _requestService;
    private string[] urls = new string[3];

    public freaxdService()
    {
        _requestService = new RequestService(new HttpClient());
        GetFirstRequest();
        GetSecondRequest();
        GetThirdRequest();
    }

    public void RunTask()
    {
        Console.WriteLine("\nВыполнение синхронных запросов...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var responses = new List<String>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Запрос {i + 1}: {urls[i]}");
                responses.Add(_requestService.FetchData(urls[i]));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\nРезультат запроса №" + (i + 1) + "\n");
                Console.WriteLine(responses[i]);

                Console.WriteLine("\n" + new string('-', 100));
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
            Console.ResetColor();

            Console.WriteLine("\n" + new string('-', 100));
        }
        finally
        {
            stopwatch.Stop();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\nВыполнение асинхронных запросов...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var tasks = new Task<String>[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Запрос {i + 1}: {urls[i]}");
                tasks[i] = _requestService.FetchDataAsync(urls[i], cancellationToken);
            }
            var responses = await Task.WhenAll(tasks);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\nРезультат запроса №" + (i + 1) + "\n");
                Console.WriteLine(responses[i]);

                Console.WriteLine("\n" + new string('-', 100));
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
            Console.ResetColor();

            Console.WriteLine("\n" + new string('-', 100));
        }
        finally
        {
            stopwatch.Stop();
        }
    }

    public void Dispose()
    {
        _requestService.Dispose();
    }

    private void GetFirstRequest()
    {
        Console.WriteLine("Weather API - сервис для получения данных о текущей погоде в выбранном городе.\n");

        Console.Write("Введите город для прогноза: ");
        string city = Console.ReadLine();

        urls[0] = $"http://api.weatherapi.com/v1/current.json?key=d562fdc8be7d4a54ab5153019252605&q={city}";

        Console.WriteLine(new string('-', 100));
    }

    private void GetSecondRequest()
    {
        Console.WriteLine("NASA APOD API - получение астрономической картинки дня.\n");

        Console.WriteLine("Введите дату\n");

        Console.Write("Год: ");
        string year = Console.ReadLine();
        Console.Write("Месяц: ");
        string month = Console.ReadLine();
        Console.Write("День: ");
        string day = Console.ReadLine();

        urls[1] = $"https://api.nasa.gov/planetary/apod?api_key=SN7OwGvGyd5Vs3UZD0cx0f8mte8Zwb8UkILSeJhq&date={year}-{month}-{day}";

        Console.WriteLine("\n" + new string('-', 100));
    }

    private void GetThirdRequest()
    {
        Console.WriteLine("REST Countries - получение информации о стране.\n");

        Console.Write("Введите название страны: ");
        string country = Console.ReadLine();

        urls[2] = $"https://restcountries.com/v3.1/name/{country}?fields=name,capital,currencies";

        Console.WriteLine("\n" + new string('-', 100));
    }
}
