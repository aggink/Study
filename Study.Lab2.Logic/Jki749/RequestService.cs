using Study.Lab2.Logic.Interfaces.Jki749;

namespace Study.Lab2.Logic.Services.Jki749;

public class RequestService : IRequestService, IDisposable
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? new HttpClient();
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
            throw new Exception($"Ошибка при запросе к {url}: {ex.Message}");
        }
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при запросе к {url}: {ex.Message}");
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}