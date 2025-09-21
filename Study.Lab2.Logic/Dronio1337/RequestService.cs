using Study.Lab2.Logic.Interfaces.Dronio1337;
using System.Text.Json.Nodes;

namespace Study.Lab2.Logic.Dronio1337;

public class RequestService : IRequstService
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
        ValidateResponse(response);
        return JsonNode.Parse(response.Content.ReadAsStringAsync().Result).ToJsonString();
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);
        ValidateResponse(response);
        return JsonNode.Parse(await response.Content.ReadAsStringAsync(cancellationToken)).ToJsonString();
    }

    private void ValidateResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new Exception($"HTTP {response.StatusCode}: {response.ReasonPhrase}");
    }
}