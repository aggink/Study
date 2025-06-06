using Study.Lab2.Logic.Interfaces.chaspix;

namespace Study.Lab2.Logic.chaspix;

public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public string FetchData(string url, Dictionary<string, string> headers = null)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Добавляем заголовки если они есть
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = _httpClient.SendAsync(request).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка HTTP: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при выполнении запроса к {url}: {ex.Message}", ex);
        }
    }

    public async Task<string> FetchDataAsync(string url, Dictionary<string, string> headers = null, CancellationToken cancellationToken = default)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Добавляем заголовки если они есть
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка HTTP: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при выполнении асинхронного запроса к {url}: {ex.Message}", ex);
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}