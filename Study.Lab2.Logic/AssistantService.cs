using Study.Lab2.Logic.Assistant;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Assistant;
using System.Diagnostics;

namespace Study.Lab2.Logic
{
    public class AssistantService : IRunService
    {
        private readonly IRequestService _requestService;

        public AssistantService()
        {
            _requestService = new RequestService();
        }

        private readonly string[] Urls = new string[]
        {
            "https://jsonplaceholder.typicode.com/posts/1",
            "https://jsonplaceholder.typicode.com/posts/2",
            "https://jsonplaceholder.typicode.com/posts/3"
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

        public async Task RunTaskAsync()
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

                    tasks[i] = _requestService.FetchDataAsync(Urls[i]);
                }

                var responses = await Task.WhenAll(tasks);

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
    }
}