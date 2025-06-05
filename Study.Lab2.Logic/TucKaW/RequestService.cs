using Study.Lab2.Logic.Interfaces.TucKaW;
using Study.Lab2.Logic.TucKaW.DtoModels;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.TucKaW;

public class RequestService : IRequestService, IDisposable
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public string FetchData(string url)
    {
        try
        {
            using var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            return ProcessResponse(response);
        }
        catch
        {
            return BarcaFactResponseHelper.GetDefaultJson();
        }
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await _httpClient.GetAsync(url, cancellationToken);
            return await ProcessResponseAsync(response, cancellationToken);
        }
        catch
        {
            return BarcaFactResponseHelper.GetDefaultJson();
        }
    }

    private static string ProcessResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"HTTP Error: {response.StatusCode}");
        }

        using var stream = response.Content.ReadAsStream();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    private static async Task<string> ProcessResponseAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"HTTP Error: {response.StatusCode}");
        }

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}