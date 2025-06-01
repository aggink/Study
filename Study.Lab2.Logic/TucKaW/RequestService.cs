using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Study.Lab2.Logic.Interfaces.TucKaW;

namespace Study.Lab2.Logic.TucKaW;

public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;
    private bool _disposed = false;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public string FetchData(string url)
    {
        try
        {
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            return ProcessResponse(response);
        }
        catch
        {
            return GetLocalFact();
        }
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);
            return await ProcessResponseAsync(response, cancellationToken);
        }
        catch
        {
            return GetLocalFact();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            _disposed = true;
        }
    }

    private string ProcessResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"HTTP Error: {response.StatusCode}");
        }

        using var stream = response.Content.ReadAsStream();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    private async Task<string> ProcessResponseAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"HTTP Error: {response.StatusCode}");
        }

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    private string GetLocalFact()
    {
        return JsonSerializer.Serialize(new
        {
            Data = new[]
            {
                "ФК Барселона основана в 1899 году",
                "Камп Ноу - домашний стадион",
                "Известные игроки: Месси, Хави, Иньеста"
            }
        });
    }
}