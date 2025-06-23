using Study.Lab2.Logic.Interfaces.mansurgh;
using Study.Lab2.Logic.Interfaces.mansurgh.DtoModels;
using System.Text.Json;


namespace Study.Lab2.Logic.mansurgh;

public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public HttpResponseDto FetchData(string url)
    {
        var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
        ValidateResponse(response);

        var content = response.Content.ReadAsStringAsync().Result;
        return new HttpResponseDto
        {
            StatusCode = (int)response.StatusCode,
            Text = FormatJson(url, content)
        };
    }

    public async Task<HttpResponseDto> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);
        ValidateResponse(response);

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return new HttpResponseDto
        {
            StatusCode = (int)response.StatusCode,
            Text = FormatJson(url, content)
        };
    }

    private void ValidateResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new Exception($"HTTP {response.StatusCode}: {response.ReasonPhrase}");
    }

    private string FormatJson(string url, string raw)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        try
        {
            if (url.Contains("spacex"))
            {
                var dto = JsonSerializer.Deserialize<SpaceXLaunchDto>(raw);
                return JsonSerializer.Serialize(dto, options);
            }
            if (url.Contains("boredapi"))
            {
                var dto = JsonSerializer.Deserialize<BoredActivityDto>(raw);
                return JsonSerializer.Serialize(dto, options);
            }
            if (url.Contains("agify"))
            {
                var dto = JsonSerializer.Deserialize<AgifyResponseDto>(raw);
                return JsonSerializer.Serialize(dto, options);
            }

            // если не удалось сопоставить — возвращаем отформатированный JSON как есть
            using var doc = JsonDocument.Parse(raw);
            return JsonSerializer.Serialize(doc, options);
        }
        catch
        {
            // если парсинг не удался — возвращаем как есть
            return raw;
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
