using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.chirique_online;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Study.Lab2.Logic.chirique_online;

public class chiriqueOnlineService : IRunService
{
    private readonly IRequestService _requestService;

    public chiriqueOnlineService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    private readonly string[] Url = new string[]
    {
        "https://jokeapi.dev/joke/Any?format=txt&type=single&blacklistFlags=nsfw,racist,explicit,sexist&lang=en",
        "https://randomuser.me/api/?inc=gender,name,email",
        "https://catfact.ninja/fact"
    };

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос к API...\n");
        var stopwatch = Stopwatch.StartNew();
        try
        {
            var responses = new List<string>();

            for (int i = 0; i < Url.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Запрос {i + 1}: {Url[i]}");
                Console.ResetColor();

                var response = _requestService.FetchData(Url[i]);
                if (Url[i].Contains("randomuser.me") || Url[i].Contains("catfact.ninja"))
                {
                    var jsonDoc = JsonDocument.Parse(response);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    var formattedJson = JsonSerializer.Serialize(jsonDoc, options);
                    responses.Add(formattedJson);
                }
                else
                {
                    responses.Add(response);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            for (int i = 0; i < responses.Count; i++)
            {
                Console.WriteLine($"\nРезультат запроса №{i + 1} ");

                switch (i)
                {
                    case 0:
                        Console.WriteLine("Подключение к JokeAPI.\nСлучайная шутка:");
                        break;
                    case 1:
                        Console.WriteLine("Подключение к RandomUserAPI.\nСлучайный пользователь:");
                        break;
                    case 2:
                        Console.WriteLine("Подключение к СatFact.NinjaAPI.\nСлучайный факт о кошках:");
                        break;
                    default:
                        Console.WriteLine("Неизвестный вариант.");
                        break;
                }

                Console.WriteLine(System.Text.RegularExpressions.Regex.Unescape(responses[i]));

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n" + new string('-', 100));
                Console.ResetColor();
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
        Console.WriteLine("\nВыполняется асинхронный запрос к API...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var tasks = new Task<string>[Url.Length];

            for (int i = 0; i < Url.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Запрос {i + 1}: {Url[i]}");
                Console.ResetColor();

                tasks[i] = _requestService.FetchDataAsync(Url[i], cancellationToken);
            }

            var responses = await Task.WhenAll(tasks);

            for (int i = 0; i < responses.Length; i++)
            {
                if (Url[i].Contains("randomuser.me") || Url[i].Contains("catfact.ninja"))
                {
                    try
                    {
                        using var jsonDoc = JsonDocument.Parse(responses[i]);
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        var formattedJson = JsonSerializer.Serialize(jsonDoc, options);
                        responses = responses.Select((r, idx) => idx == i ? formattedJson : r).ToArray();
                    }
                    catch
                    {
                        // если не удалось распарсить — оставляем как есть
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            foreach (var response in responses)
            {
                Console.WriteLine(response);
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

    public void Dispose()
    {
        _requestService.Dispose();
    }
}

