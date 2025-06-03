using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Assistant;
using Study.Lab2.Logic.p0se1d0n.DtoModels;
using System.Diagnostics;
using System.Text.Json;

namespace Study.Lab2.Logic.p0se1d0n;

public class p0se1d0nService : IRunService
{
    private readonly IRequestService _requestService;

    public p0se1d0nService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    private readonly string[] Urls = new string[]
    {
        "https://dummyjson.com/recipes/1",
        "https://dummyjson.com/recipes/2",
        "https://dummyjson.com/recipes/3"
    };

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var responses = new List<string>();

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

            Console.WriteLine(new string('-', 50));
            ProcessResponses(responses);
            Console.WriteLine(new string('-', 50));

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

            Console.WriteLine(new string('-', 50));
            ProcessResponses(responses);
            Console.WriteLine(new string('-', 50));

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

    public void Dispose()
    {
        _requestService.Dispose();
    }

    private void ProcessResponses(List<string> responses)
    {
        int counter = 1;
        foreach (var response in responses)
        {
            try
            {
                var recipe = JsonSerializer.Deserialize<RecipeDto>(response);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\nРецепт #{counter} ({recipe?.Name}):");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Ингредиенты:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient}");
                }
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Инструкции:");
                foreach (var instruction in recipe.Instructions)
                {
                    Console.WriteLine($"{instruction}");
                }
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Время подготовки: {recipe.PrepTimeMinutes}");
                Console.WriteLine($"Время приготовления: {recipe.CookTimeMinutes}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Сложность: {recipe.Difficulty}");
                Console.ResetColor();
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
}