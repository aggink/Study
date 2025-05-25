using Study.Lab2.Logic.Interfaces.Cherryy;

namespace Study.Lab2.Logic.Cherryy;

public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        // Настройка HttpClient (например, таймауты, заголовки по умолчанию)
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Lab2-Assistant");
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
    }

    public string FetchData(string url)
    {
        try
        {
            var response = _httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при выполнении запроса к {url}: {ex.Message}");
        }
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при выполнении запроса к {url}: {ex.Message}");
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}
