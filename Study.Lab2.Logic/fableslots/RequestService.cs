using Study.Lab2.Logic.Interfaces.fableslots;

namespace Study.Lab2.Logic.fableslots;

public class RequestService : IRequestService
{
    private readonly HttpClient _http;

    public RequestService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    public string FetchData(string url)
    {
        var response = _http.GetAsync(url).GetAwaiter().GetResult();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        using (var stream = response.Content.ReadAsStream())
        using (var reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _http.GetAsync(url, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    public void Dispose()
    {
        _http.Dispose();
    }
}