using System.Text;
using Study.Lab2.Logic.Interfaces.kinkiss1;

namespace Study.Lab2.Logic.kinkiss1;

public class RequestService : IRequestService
{
    private readonly HttpClient _client;
    public RequestService(HttpClient client)
    {
        _client = client;
    }
    public string FetchSync(string url, Dictionary<string, string> headers = null)
    {
        using (var request = new HttpRequestMessage(HttpMethod.Get, url))
        {
            if (headers != null)
                foreach (var header in headers)
                    request.Headers.Add(header.Key, header.Value);

            var answer = _client.SendAsync(request).GetAwaiter().GetResult();

            if (!answer.IsSuccessStatusCode)
                throw new Exception($"HTTP Error: {answer.StatusCode} - {answer.ReasonPhrase}");

            using (var stream = answer.Content.ReadAsStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

public async Task<string> FetchAsync(
        string url,
        Dictionary<string, string> headers = null,
        CancellationToken cancellationToken = default)
    {
        using (var request = new HttpRequestMessage(HttpMethod.Get, url))
        {
            // Добавляем заголовки, если они предоставлены
            if (headers != null)
                foreach (var header in headers)
                    request.Headers.Add(header.Key, header.Value);

            var response = await _client.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }
    }
    public void Dispose()
    {
        _client?.Dispose();
    }
}
