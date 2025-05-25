using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Jki749;
using Study.Lab2.Logic.Services.Jki749;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.Jki749;
    public class jki749Service : IRunService, IDisposable
    { 
        private readonly string[] _apiUrls = new[]          
        {
            "https://jsonplaceholder.typicode.com/posts/1",
            "https://api.agify.io?name=alex",
            "https://api.genderize.io?name=maria"
        };

    private readonly IRequestService _requestService;

    public jki749Service(IRequestService requestService = null)
        {
            _requestService = requestService ?? new RequestService(new HttpClient());
        }

        public void RunTask()
        {
            Console.WriteLine("Синхронные запросы ");
            var timer = Stopwatch.StartNew();

            try
            {
                foreach (var url in _apiUrls)
                {
                    Console.WriteLine($"Запрос к: {url}");
                    string response = _requestService.FetchData(url);
                    Console.WriteLine($"Ответ: {response}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                timer.Stop();
                Console.WriteLine($"Общее время: {timer.ElapsedMilliseconds} мс");
            }
        }

        public async Task RunTaskAsync(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Асинхронные запросы ");
            var timer = Stopwatch.StartNew();

            try
            {
                foreach (var url in _apiUrls)
                {
                    Console.WriteLine($"Запрос к: {url}");
                    string response = await _requestService.FetchDataAsync(url, cancellationToken);
                    Console.WriteLine($"Ответ: {response}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                timer.Stop();
                Console.WriteLine($"Общее время: {timer.ElapsedMilliseconds} мс");
            }
        }

        public void Dispose()
        {
            _requestService?.Dispose();
        }
    }