using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab2.Logic.Interfaces.Dronio1337;

namespace Study.Lab2.Logic.Dronio1337;

public class Dronio1337Service : IRunService
{
    private readonly IRequstService _requestHandler;
    private string[] _apiUrls = new string[3];

    public Dronio1337Service()
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
        SetupRandomUserApi();
        SetupJsonPlaceholderApi();
        SetupCatFactsApi();
    }

    private void SetupRandomUserApi()
    {
        Console.Write("RandomUser API - получение случайного пользователя.\n\n");
        _apiUrls[0] = "https://randomuser.me/api/";
        PrintSeparator();
    }

    private void SetupJsonPlaceholderApi()
    {
        Console.Write("JSONPlaceholder API - получение фейковых данных.\n\n");
        Console.Write("Выберите тип данных (posts, users, comments): ");
        string dataType = Console.ReadLine();
        _apiUrls[1] = $"https://jsonplaceholder.typicode.com/{dataType}";
        PrintSeparator();
    }

    private void SetupCatFactsApi()
    {
        Console.Write("Cat Facts API - получение случайного факта о кошках.\n\n");
        _apiUrls[2] = "https://catfact.ninja/fact";
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