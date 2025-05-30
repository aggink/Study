using Study.Lab2.Logic.Interfaces.SlavicSquat;
using System.Text.Json.Nodes;

namespace Study.Lab2.Logic.SlavicSquat;

public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }

    public string FetchData(string url)
    {
        var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"HTTP {response.StatusCode}: {response.ReasonPhrase}");

        return response.Content.ReadAsStringAsync().Result;
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"HTTP {response.StatusCode}: {response.ReasonPhrase}");

        return JsonNode.Parse(await response.Content.ReadAsStringAsync(cancellationToken)).ToJsonString();
    }
}