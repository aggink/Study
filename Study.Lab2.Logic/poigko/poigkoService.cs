using System.Diagnostics;
using System.Text.Json;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.poigko;
using Study.Lab2.Logic.poigko.DtoModels;

namespace Study.Lab2.Logic.poigko;

public class poigkoService : IRunService
{
    private readonly IRequestService _requestService;

    private readonly string url = "https://meowfacts.herokuapp.com/";

    public poigkoService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Было отправлено 3 запроса к: {url}");
            Console.ResetColor();
            for (int i = 0; i < 3; i++)
            {
                var response = _requestService.FetchData(url);
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

            int counter = 1;

            foreach (var response in responses)
            {
                try
                {
                    CatFactResponseDto catFact = JsonSerializer.Deserialize<CatFactResponseDto>(response);

                    if (catFact.Data != null && catFact.Data.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Here's your cat fun fact number " + counter + " for today!");
                        Console.ResetColor();
                        Console.WriteLine(catFact.Data[0]);
                        Console.WriteLine(new string('-', 100));
                        counter++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No cat facts for you today, sorry");
                        Console.ResetColor();
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON Error: {ex.Message}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("\nВыполняется асинхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();
        var jsonResponses = new string[3];

        try
        {
            var tasks = new Task<string>[3];

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Было отправлено 3 запроса к: {url}");
            Console.ResetColor();

            for (int i = 0; i < 3; i++)
            {
                tasks[i] = _requestService.FetchDataAsync(url, cancellationToken);
            }

            var responses = await Task.WhenAll(tasks);
            jsonResponses = responses;

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

            int counter = 1;

            foreach (var response in jsonResponses)
            {
                try
                {
                    CatFactResponseDto catFact = JsonSerializer.Deserialize<CatFactResponseDto>(response);

                    if (catFact.Data != null && catFact.Data.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Here's your cat fun fact number " + counter + " for today!");
                        Console.ResetColor();
                        Console.WriteLine(catFact.Data[0]);
                        Console.WriteLine(new string('-', 100));
                        counter++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No cat facts for you today, sorry");
                        Console.ResetColor();
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON Error: {ex.Message}");
                }
            }

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
