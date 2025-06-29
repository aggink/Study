﻿using Study.Lab2.Logic.Interfaces.IvanZ;

namespace Study.Lab2.Logic.IvanZ;

public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }

    public string FetchData(string url)
    {
        var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
        }
        return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
        }
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

}
