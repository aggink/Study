using System.Diagnostics;
using System.Text.Json;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.lsokol14l;

namespace Study.Lab2.Logic.lsokol14l
{
    public class lsokol14lService : IRunService
    {
        private readonly IRequestService _requestService;

        public lsokol14lService()
        {
            _requestService = new RequestService(new HttpClient());
        }

        public lsokol14lService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        private readonly string[] Urls = new string[]
        {
            "https://jsonplaceholder.typicode.com/posts/1",
            "https://jsonplaceholder.typicode.com/posts/2",
            "https://jsonplaceholder.typicode.com/posts/3"
        };

        public void RunTask()
        {
            Console.WriteLine("\nВыполняется синхронный запрос с обработкой ответов...\n");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Создаем процессор для обработки ответов 
                IJsonResponseProcessor responseProcessor = new JsonResponseProcessor();

                var responses = new List<object>();

                for (int i = 0; i < Urls.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Запрос {i + 1}: {Urls[i]}");
                    Console.ResetColor();

                    // Выполняем запрос
                    var response = _requestService.FetchData(Urls[i]);

                    // Обрабатываем ответ с помощью процессора
                    var processedResponse = responseProcessor.ProcessResponse(response);
                    responses.Add(processedResponse);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nВсе ответы успешно обработаны!\n");
                Console.ResetColor();

                // Выводим обработанные ответы
                foreach (var response in responses)
                {
                    Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
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
            Console.WriteLine("\nВыполняется асинхронный запрос с обработкой ответов...\n");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Создаем процессор для обработки ответов
                IJsonResponseProcessor responseProcessor = new JsonResponseProcessor();

                var tasks = new Task<string>[Urls.Length];

                for (int i = 0; i < Urls.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Запрос {i + 1}: {Urls[i]}");
                    Console.ResetColor();

                    // Выполняем асинхронный запрос
                    tasks[i] = _requestService.FetchDataAsync(Urls[i], cancellationToken);
                }

                // Ожидаем выполнения всех запросов
                var responses = await Task.WhenAll(tasks);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nВсе ответы успешно получены и обработаны!\n");
                Console.ResetColor();

                // Обрабатываем ответы с помощью процессора
                var processedResponses = new List<object>();
                foreach (var response in responses)
                {
                    var processedResponse = responseProcessor.ProcessResponse(response);
                    processedResponses.Add(processedResponse);
                }

                // Выводим обработанные ответы
                foreach (var processedResponse in processedResponses)
                {
                    Console.WriteLine(JsonSerializer.Serialize(processedResponse, new JsonSerializerOptions { WriteIndented = true }));
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
}