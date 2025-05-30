using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab2.Logic.Interfaces.SuperSalad007;

namespace Study.Lab2.Logic.SuperSalad007
{
    public class SuperSaladService : IRunService
    {
        private readonly IRequestService _requestService;

        public SuperSaladService()
        {
            _requestService = new RequestService(new HttpClient());
        }

        private readonly string[] Urls = new string[]
        {
            "https://jsonplaceholder.typicode.com/posts/32",
            "https://jsonplaceholder.typicode.com/posts/54",
            "https://jsonplaceholder.typicode.com/posts/78"
        };

        public void Dispose()
        {
            _requestService.Dispose();
        }

        public void RunTask()
        {
            Console.WriteLine("\nA synchronous request is being executed...\n");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var responses = new List<string>();

                for (int i = 0; i < Urls.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Request {i + 1}: {Urls[i]}");
                    Console.ResetColor();

                    var response = _requestService.FetchData(Urls[i]);
                    responses.Add(response);
                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nAll responses have been successfully received!\n");
                Console.ResetColor();

                foreach (var response in responses)
                {
                    Console.WriteLine(response);
                    Console.WriteLine(new string('-', 50));
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nRequest error: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nTotal duration: {stopwatch.ElapsedMilliseconds} мс");
                Console.ResetColor();
            }
        }

        public async Task RunTaskAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("\nAn asynchronous request is being made...\n");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var tasks = new Task<string>[Urls.Length];

                for (int i = 0; i < Urls.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Request {i + 1}: {Urls[i]}");
                    Console.ResetColor();

                    tasks[i] = _requestService.FetchDataAsync(Urls[i], cancellationToken);
                }

                var responses = await Task.WhenAll(tasks);

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nAll responses have been successfully received!\n");
                Console.ResetColor();

                foreach (var response in responses)
                {
                    Console.WriteLine(response);
                    Console.WriteLine(new string('-', 50));
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nRequest error: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nTotal duration: {stopwatch.ElapsedMilliseconds} мс");
                Console.ResetColor();
            }
        }
    }
}
