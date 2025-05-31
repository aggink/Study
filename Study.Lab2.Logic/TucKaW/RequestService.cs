using Study.Lab2.Logic.Interfaces.TucKaW;
using Study.Lab2.Logic.TucKaW.DtoModels;
using Study.Lab2.Logic.TucKaW.DtoModels;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.TucKaW
{
    public class RequestService : IRequestService, IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed = false;

        // Локальные данные для fallback
        private readonly List<string> _localBarcaFacts = new()
        {
            "ФК Барселона была основана 29 ноября 1899 года.",
            "Камп Ноу - самый большой стадион в Европе.",
            "Легендарный игрок Лионель Месси - лучший бомбардир клуба."
        };

        public RequestService(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();

            // Настройка HttpClient для реального API
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "BarcaFactsApp");
            _httpClient.Timeout = TimeSpan.FromSeconds(15);
        }

        public string FetchData(string url)
        {
            try
            {
                // Проверка URL
                if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    return GetLocalFact();
                }

                var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
                return ProcessResponse(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error: {ex.Message}");
                return GetLocalFact();
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Request timeout");
                return GetLocalFact();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return GetLocalFact();
            }
        }

        public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
        {
            try
            {
                // Проверка URL
                if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    return GetLocalFact();
                }

                var response = await _httpClient.GetAsync(url, cancellationToken);
                return await ProcessResponseAsync(response, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error: {ex.Message}");
                return GetLocalFact();
            }
            catch (TaskCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Request was cancelled");
                return GetLocalFact();
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Request timeout");
                return GetLocalFact();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return GetLocalFact();
            }
        }

        private string ProcessResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
            }

            using var stream = response.Content.ReadAsStream();
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();

            if (string.IsNullOrWhiteSpace(content))
            {
                return GetLocalFact();
            }

            return content;
        }

        private async Task<string> ProcessResponseAsync(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (string.IsNullOrWhiteSpace(content))
            {
                return GetLocalFact();
            }

            return content;
        }

        private string GetLocalFact()
        {
            var random = new Random();
            var fact = _localBarcaFacts[random.Next(_localBarcaFacts.Count)];
            return JsonSerializer.Serialize(new BarcaFactResponseDto { Data = new List<string> { fact } });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}