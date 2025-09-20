using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.mansurgh;
using System.Diagnostics;

namespace Study.Lab2.Logic.mansurgh
{
    public class MansurghService : IRunService
    {
        private readonly IRequestService _requestService;

        public MansurghService()
        {
            _requestService = new RequestService(new HttpClient());
        }

        /// <summary>
        /// URLs для выполнения трех запросов к разным серверам
        /// </summary>
        private readonly string[] Urls = new string[]
        {
            "https://jsonplaceholder.typicode.com/posts/1",  // Первый сервер - JSONPlaceholder
            "https://httpbin.org/json",                      // Второй сервер - HTTPBin
            "https://jsonplaceholder.typicode.com/users/1"   // Третий сервер - JSONPlaceholder Users
        };

        public void RunTask()
        {
            Console.WriteLine("\n=== СИНХРОННОЕ ВЫПОЛНЕНИЕ ===");
            Console.WriteLine("Выполняется синхронный запрос к трем серверам...\n");
            
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
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✓ Ответ {i + 1} получен успешно");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n=== ВСЕ ОТВЕТЫ ПОЛУЧЕНЫ УСПЕШНО ===\n");
                Console.ResetColor();

                // Выводим ответы в формате JSON
                for (int i = 0; i < responses.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Ответ от сервера {i + 1}:");
                    Console.ResetColor();
                    Console.WriteLine(responses[i]);
                    Console.WriteLine(new string('-', 80));
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ ОШИБКА ЗАПРОСА: {ex.Message}");
                Console.WriteLine("Выполнение прервано из-за негативного ответа от сервера.");
                Console.ResetColor();
                return;
            }
            finally
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n⏱️ ОБЩЕЕ ВРЕМЯ РАБОТЫ (синхронно): {stopwatch.ElapsedMilliseconds} мс");
                Console.ResetColor();
            }
        }

        public async Task RunTaskAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("\n=== АСИНХРОННОЕ ВЫПОЛНЕНИЕ ===");
            Console.WriteLine("Выполняется асинхронный запрос к трем серверам...\n");
            
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var tasks = new Task<string>[Urls.Length];

                // Запускаем все запросы параллельно
                for (int i = 0; i < Urls.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Запуск асинхронного запроса {i + 1}: {Urls[i]}");
                    Console.ResetColor();

                    tasks[i] = _requestService.FetchDataAsync(Urls[i], cancellationToken);
                }

                // Ожидаем завершения всех запросов
                var responses = await Task.WhenAll(tasks);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n=== ВСЕ ОТВЕТЫ ПОЛУЧЕНЫ УСПЕШНО ===\n");
                Console.ResetColor();

                // Выводим ответы в формате JSON
                for (int i = 0; i < responses.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Ответ от сервера {i + 1}:");
                    Console.ResetColor();
                    Console.WriteLine(responses[i]);
                    Console.WriteLine(new string('-', 80));
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ ОШИБКА ЗАПРОСА: {ex.Message}");
                Console.WriteLine("Выполнение прервано из-за негативного ответа от сервера.");
                Console.ResetColor();
                return;
            }
            finally
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n⏱️ ОБЩЕЕ ВРЕМЯ РАБОТЫ (асинхронно): {stopwatch.ElapsedMilliseconds} мс");
                Console.ResetColor();
            }
        }

        public void Dispose()
        {
            _requestService.Dispose();
        }
    }
}
