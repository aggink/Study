using Study.Lab2.Logic.Interfaces.kinkiss1;

namespace Study.Lab2.Logic.kinkiss1;

public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;
    private bool _disposed = false;

    public RequestService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public string FetchData(string url, Dictionary<string, string> headers = null)
    {
        // Проверяем URL на корректность
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("URL не может быть пустым", nameof(url));
        }

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Добавляем заголовки, если они заданы
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            // Отправляем запрос
            using var response = _httpClient.SendAsync(request).Result;

            // Проверяем статус ответа
            response.EnsureSuccessStatusCode();

            // Читаем содержимое ответа
            return response.Content.ReadAsStringAsync().Result;
        }
        catch (HttpRequestException ex)
        {
            // Перехватываем ошибки HTTP и добавляем дополнительную информацию
            throw new HttpRequestException($"Ошибка запроса к {url}: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            // Перехватываем прочие ошибки
            throw new Exception($"Ошибка при выполнении запроса к {url}: {ex.Message}", ex);
        }
    }


    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Ошибка при запросе к {url}: {(int)response.StatusCode} {response.ReasonPhrase}");

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _httpClient.Dispose();
            _disposed = true;
        }
    }
}