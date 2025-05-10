using System.Diagnostics;
using System.Text.Json;
using Study.Lab2.Logic.Interfaces.lsokol14l;

namespace Study.Lab2.Logic.lsokol14l
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string FetchData(string url)
        {
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
            }

            using (var stream = response.Content.ReadAsStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        public void PerformRequestsSync(string[] urls, IJsonResponseProcessor responseProcessor)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                foreach (var url in urls)
                {
                    Console.WriteLine($"Запрос к {url}...");
                    var response = FetchData(url);
                    var processedResponse = responseProcessor.ProcessResponse(response);
                    Console.WriteLine($"Обработанный ответ: {JsonSerializer.Serialize(processedResponse, new JsonSerializerOptions { WriteIndented = true })}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении запроса: {ex.Message}");
                return;
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine($"Общее время выполнения: {stopwatch.ElapsedMilliseconds} мс");
            }
        }

        public async Task PerformRequestsAsync(string[] urls, IJsonResponseProcessor responseProcessor, CancellationToken cancellationToken = default)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var tasks = urls.Select(async url =>
                {
                    Console.WriteLine($"Запрос к {url}...");
                    var response = await FetchDataAsync(url, cancellationToken);
                    var processedResponse = responseProcessor.ProcessResponse(response);
                    Console.WriteLine($"Обработанный ответ: {JsonSerializer.Serialize(processedResponse, new JsonSerializerOptions { WriteIndented = true })}");
                });

                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении запроса: {ex.Message}");
                return;
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine($"Общее время выполнения: {stopwatch.ElapsedMilliseconds} мс");
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
