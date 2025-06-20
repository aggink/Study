using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.mansurgh;
using System.Diagnostics;

namespace Study.Lab2.Logic.mansurgh;

public class mansurghService : IRunService
{
    private readonly IRequestService _requestHandler;
    private string[] _apiUrls = new string[3];

    public mansurghService()
    {
        _requestHandler = new RequestService(new HttpClient());
        SetupApis();
    }

    public void RunTask()
    {
        Console.WriteLine("mansurghService: синхронный запуск...\n");
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
        Console.WriteLine("\nmansurghService: асинхронный запуск...\n");
        var timer = Stopwatch.StartNew();

        try
        {
            var tasks = _apiUrls.Select((url, index) =>
            {
                Console.WriteLine($"Запрос {index + 1}: {url}");
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
        SetupSpacexApi();
        SetupBoredApi();
        SetupAgifyApi();
    }

    private void SetupSpacexApi()
    {
        Console.WriteLine("API 1: SpaceX — последний запуск");
        _apiUrls[0] = "https://api.spacexdata.com/v4/launches/latest";
        PrintSeparator();
    }

    private void SetupBoredApi()
    {
        Console.WriteLine("API 2: Bored API — случайная идея для досуга");
        _apiUrls[1] = "https://www.boredapi.com/api/activity";
        PrintSeparator();
    }

    private void SetupAgifyApi()
    {
        Console.Write("API 3: Agify — предсказание возраста по имени\nВведите имя: ");
        string name = Console.ReadLine();
        _apiUrls[2] = $"https://api.agify.io/?name={name}";
        PrintSeparator();
    }

    private void ShowSuccess(IEnumerable<string> responses, long time)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nВсе ответы получены!\n");
        Console.ResetColor();

        int count = 1;
        foreach (var r in responses)
        {
            Console.WriteLine($"Ответ {count++}:\n{r}");
            PrintSeparator();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Время выполнения: {time} мс");
        Console.ResetColor();
    }

    private void ShowError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{msg}");
        Console.ResetColor();
    }

    private void PrintSeparator() =>
        Console.WriteLine("\n" + new string('-', 80));

    public void Dispose() => _requestHandler.Dispose();
}
