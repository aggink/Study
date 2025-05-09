using Study.Lab2.Logic.Interfaces.Selestz;

namespace Study.Lab2.Logic.Selestz;

public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string FetchData(string url, Dictionary<string, string> headers = null)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);

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
            throw new Exception($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }

    public async Task<string> FetchDataAsync(string url, Dictionary<string, string> headers = null, CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);

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
            throw new Exception($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}