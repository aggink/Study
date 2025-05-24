using System.Diagnostics;
using System.Text.Json;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.KirillPoroshin;
using Study.Lab2.Logic.KirillPoroshin.DtoModels;

namespace Study.Lab2.Logic.KirillPoroshin;

public class KirillPoroshinService : IRunService
{
    private readonly IRequestService _requestService;
    private readonly string[] urls = new[]
    {
        "http://numbersapi.com/random/trivia?json",
        "http://numbersapi.com/random/math?json",
        "http://numbersapi.com/random/year?json"
    };

    public KirillPoroshinService() : this(new RequestService(new HttpClient()))
    { }

    public KirillPoroshinService(IRequestService requestService)
    {
        _requestService = requestService;
    }

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос...\n");
        ProcessRequests(false);
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("\nВыполняется асинхронный запрос...\n");
        await ProcessRequestsAsync(cancellationToken);
    }

    private void ProcessRequests(bool async)
    {
        var stopwatch = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Было отправлено 3 запроса к NumbersAPI");
            Console.ResetColor();

            foreach (var url in urls)
            {
                var response = async
                    ? _requestService.FetchDataAsync(url).GetAwaiter().GetResult()
                    : _requestService.FetchData(url);
                responses.Add(response);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();
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
            ProcessResponses(responses);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    private async Task ProcessRequestsAsync(CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Было отправлено 3 запроса к NumbersAPI");
            Console.ResetColor();

            var tasks = urls.Select(url => _requestService.FetchDataAsync(url, cancellationToken)).ToList();
            var results = await Task.WhenAll(tasks);
            responses.AddRange(results);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();
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
            ProcessResponses(responses);
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
                var fact = JsonSerializer.Deserialize<NumberFactResponseDto>(response);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Факт #{counter} ({fact?.Type} о числе {fact?.Number}):");
                Console.ResetColor();
                Console.WriteLine(fact?.Text);
                Console.WriteLine(new string('-', 100));
                counter++;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Факт #{counter}: Ошибка обработки - {ex.Message}");
                Console.ResetColor();
                counter++;
            }
        }
    }

    public void Dispose()
    {
        _requestService?.Dispose();
    }
}