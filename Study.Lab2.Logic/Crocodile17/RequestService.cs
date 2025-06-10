using Study.Lab2.Logic.Interfaces.Crocodile17;

namespace Study.Lab2.Logic.Crocodile17;

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
            throw new Exception($"[ERROR]: {response.StatusCode} - {response.ReasonPhrase}");
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
            throw new Exception($"[ERROR]: {response.StatusCode} - {response.ReasonPhrase}");
        }

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}