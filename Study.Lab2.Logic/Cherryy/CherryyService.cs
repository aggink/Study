using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Cherryy;
using System.Diagnostics;
using System.Text.Json;

namespace Study.Lab2.Logic.Cherryy
{
    public class CherryyService : IRunService
    {
        private readonly IRequestService _requestService;

        public CherryyService()
        {
            _requestService = new RequestService(new HttpClient());
        }

        private readonly string[] Urls = new string[]
        {
            "https://api.github.com/users/octocat",
            "https://api.github.com/users/mojombo",
            "https://api.github.com/users/defunkt"
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

                    // Проверка на отрицательный ответ
                    if (response.Contains("\"message\"") || response.Contains("\"error\""))
                    {
                        var jsonDoc = JsonDocument.Parse(response);
                        if (jsonDoc.RootElement.TryGetProperty("message", out var messageProp))
                        {
                            throw new Exception($"Сервер вернул ошибку: {messageProp.GetString()}");
                        }
                        throw new Exception("Сервер вернул отрицательный ответ");
                    }

                    responses.Add(FormatJson(response));
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

                var responses = await Task.WhenAll(tasks);

                // Проверка ответов на ошибки
                foreach (var response in responses)
                {
                    if (response.Contains("\"message\"") || response.Contains("\"error\""))
                    {
                        var jsonDoc = JsonDocument.Parse(response);
                        if (jsonDoc.RootElement.TryGetProperty("message", out var messageProp))
                        {
                            throw new Exception($"Сервер вернул ошибку: {messageProp.GetString()}");
                        }
                        throw new Exception("Сервер вернул отрицательный ответ");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nВсе ответы успешно получены!\n");
                Console.ResetColor();

                foreach (var response in responses)
                {
                    Console.WriteLine(FormatJson(response));
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

        private string FormatJson(string json)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                using var jsonDoc = JsonDocument.Parse(json);
                return JsonSerializer.Serialize(jsonDoc, options);
            }
            catch
            {
                return json; // Если не удалось отформатировать, вернуть как есть
            }
        }

        public void Dispose()
        {
            _requestService.Dispose();
        }
    }
}
