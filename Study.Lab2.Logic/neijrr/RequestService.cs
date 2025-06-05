using Study.Lab2.Logic.Interfaces.neijrr;

namespace Study.Lab2.Logic.neijrr;

public class RequestService(HttpClient httpClient) : IRequestService
{
    private readonly HttpClient _httpClient = httpClient;

    public string FetchData(string url)
    {
        using var httpReq = new HttpRequestMessage(HttpMethod.Get, url);

        var response = _httpClient.SendAsync(httpReq).GetAwaiter().GetResult();

        if (!response.IsSuccessStatusCode)
            throw new Exception(GetHttpError(response));

        using var stream = response.Content.ReadAsStream();
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }

    public string SendData(string url, HttpMethod method, string request)
    {
        using var httpReq = new HttpRequestMessage(method, url);
        httpReq.Content = new StringContent(request);

        var response = _httpClient.SendAsync(httpReq).GetAwaiter().GetResult();

        if (!response.IsSuccessStatusCode)
            throw new Exception(GetHttpError(response));

        using var stream = response.Content.ReadAsStream();
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        using var httpReq = new HttpRequestMessage(HttpMethod.Get, url);

        var response = await _httpClient.SendAsync(httpReq, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception(GetHttpError(response));

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    public async Task<string> SendDataAsync(string url, HttpMethod method, string request, CancellationToken cancellationToken)
    {
        using var httpReq = new HttpRequestMessage(method, url);
        httpReq.Content = new StringContent(request);

        var response = await _httpClient.SendAsync(httpReq, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception(GetHttpError(response));

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }

    private static string GetHttpError(HttpResponseMessage response) => $"Ошибка HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}";
}
