using Study.Lab2.Logic.Interfaces.cocobara;
using System.Text.Json.Nodes;

namespace Study.Lab2.Logic.cocobara;

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
        {
            throw new Exception($"{(int)response.StatusCode} - {response.ReasonPhrase}");
        }

        var jsObj = JsonObject.Parse(response.Content.ReadAsStringAsync().Result);

        return jsObj.ToString();
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"{(int)response.StatusCode} - {response.ReasonPhrase}");
        }

        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var jsObj = JsonObject.Parse(result);

        return jsObj.ToString();
    }
}
