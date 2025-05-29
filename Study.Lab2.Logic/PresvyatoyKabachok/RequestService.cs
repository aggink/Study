using Study.Lab2.Logic.Interfaces.PresvyatoyKabachok;

namespace Study.Lab2.Logic.PresvyatoyKabachok;

/// <summary>
/// Мини-обёртка над <see cref="HttpClient"/> с проверкой кода ответа.
/// </summary>
public class RequestService : IRequestService
{
    private readonly HttpClient _http;

    public RequestService(HttpClient httpClient) => _http = httpClient;

    public string FetchData(string url)
    {
        var resp = _http.GetAsync(url).GetAwaiter().GetResult();
        EnsureSuccess(resp);
        return resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        var resp = await _http.GetAsync(url, cancellationToken);
        EnsureSuccess(resp);
        return await resp.Content.ReadAsStringAsync(cancellationToken);
    }

    private static void EnsureSuccess(HttpResponseMessage resp)
    {
        if (!resp.IsSuccessStatusCode)
            throw new Exception($"HTTP {(int)resp.StatusCode}: {resp.ReasonPhrase}");
    }

    public void Dispose() => _http.Dispose();
}