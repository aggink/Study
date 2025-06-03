using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Taipano;
using Study.Lab2.Logic.KirillPoroshin.DtoModels;
using Study.Lab2.Logic.Taipano.DtoModels;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace Study.Lab2.Logic.Taipano;

public class TaipanoService : IRunService
{
    private readonly IRequestService _requestService;
    public TaipanoService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    private readonly string[] Urls = new string[]
    {
        "https://dummyjson.com/products/1",
        "https://dummyjson.com/products/2",
        "https://dummyjson.com/products/3"

    };

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            

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
                ProcessResponses(responses);
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

            List<string> responses = new List<string>(); 
            responses.AddRange(await Task.WhenAll(tasks));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            ProcessResponses(responses);

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

    private void ProcessResponses(List<string> responses)
    {
        int counter = 1;
        foreach (var response in responses)
        {
            try
            {
                var fact = JsonSerializer.Deserialize<PoductFactResponseDto>(response);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Товар: {fact?.Title} ID товара:{fact?.Id}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Категория: {fact?.Category}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Цена: {fact?.Price}");
                counter++;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Товар #{counter}: Ошибка обработки - {ex.Message}");
                Console.ResetColor();
                counter++;
            }
        }
    }

    public void Dispose()
    {
        _requestService.Dispose();
    }
}