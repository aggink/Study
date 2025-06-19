using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.UTBL;
using System.Diagnostics;

namespace Study.Lab2.Logic.UTBL;

public class UTBLService : IRunService
{
    private readonly IRequestService _requestHandler;
    private string[] _apiUrls = new string[3];

    public UTBLService()
    {
        _requestHandler = new RequestService(new HttpClient());
        SetupApis(); // Переносим инициализацию URL в конструктор
    }

    public void RunTask()
    {
        Console.WriteLine("Инициализация запросов...\n");
        Console.WriteLine("\nСтарт синхронных запросов...\n");
        var timer = Stopwatch.StartNew();

        try
        {
            var responses = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Запрос {i + 1}: {_apiUrls[i]}");
                responses.Add(_requestHandler.FetchData(_apiUrls[i]));
            }

            ShowSuccess(responses, timer.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            ShowError($"Ошибка: {ex.Message}");
        }
        finally
        {
            timer.Stop();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\nЗапуск асинхронных запросов...\n");
        var timer = Stopwatch.StartNew();

        try
        {
            var tasks = _apiUrls.Select((url, index) =>
            {
                Console.WriteLine($"Запрос {index + 1}: {url}"); // Добавляем вывод URL
                return _requestHandler.FetchDataAsync(url, cancellationToken);
            }).ToArray();

            var responses = await Task.WhenAll(tasks);
            ShowSuccess(responses, timer.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            ShowError($"Ошибка: {ex.Message}");
        }
        finally
        {
            timer.Stop();
        }
    }

    private void SetupApis()
    {
        SetupWeatherApi();
        SetupNasaApi();
        SetupUniversityApi();
    }

    private void SetupWeatherApi()
    {
        Console.Write("WeatherAPI - получение данных о текущей погоде в выбранном городе.\n\n");
        Console.Write("Город для прогноза: ");
        string city = Console.ReadLine();
        _apiUrls[0] = $"http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q={city}";
        PrintSeparator();
    }

    private void SetupNasaApi()
    {
        Console.Write("NASA APOD API - получение астрономической картинки дня.\n\n");
        Console.Write("Год (****): ");
        string year = Console.ReadLine();
        Console.Write("Месяц (**): ");
        string month = Console.ReadLine();
        Console.Write("День (**): ");
        string day = Console.ReadLine();
        _apiUrls[1] = $"https://api.nasa.gov/planetary/apod?api_key=WvVHdwoc2g3ZFW4vjIUucePQqPRLfaCKHn04eY4H&date={year}-{month}-{day}";
        PrintSeparator();
    }

    private void SetupUniversityApi()
    {
        Console.Write("Universities API (HipoLabs) - поиск информации об университетах по стране и названию.\n\n");
        Console.Write("Страна: ");
        string country = Console.ReadLine();
        Console.Write("Университет: ");
        string name = Console.ReadLine();
        _apiUrls[2] = $"http://universities.hipolabs.com/search?country={country}&name={name}";
        PrintSeparator();
    }

    private void ShowSuccess(IEnumerable<string> responses, long time)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nВсе ответы получены!");
        Console.ResetColor();

        int counter = 1;
        foreach (var response in responses)
        {
            Console.WriteLine($"\nОтвет {counter}:\n{response}");
            PrintSeparator();
            counter++;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nВремя выполнения: {time} мс");
        Console.ResetColor();
    }

    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
    }

    private void PrintSeparator() =>
        Console.WriteLine("\n" + new string('~', 100));

    public void Dispose() => _requestHandler.Dispose();
}