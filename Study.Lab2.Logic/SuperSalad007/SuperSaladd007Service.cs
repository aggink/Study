using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.SuperSalad007;

namespace Study.Lab2.Logic.SuperSalad007;
public class SuperSalad007Service : IRunService
{
    private readonly IRequestService _requestService;

    public SuperSalad007Service()
    {
        _requestService = new RequestService(new HttpClient());
    }

    private readonly string[] urls = new string[]
    {
        "https://api.adviceslip.com/advice/3",
        "https://api.adviceslip.com/advice/5",
        "https://api.adviceslip.com/advice/7"
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
            3 => "Совет про снег",
            5 => "Совет про шанс",
            7 => "Совет про выбор",
            _ => "Другой совет"
        };
    }

    public void Dispose()
    {
        _requestService.Dispose();
    }
}