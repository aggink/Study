using System.Text.Json;
using Study.Lab2.Logic.Interfaces.kinkiss1;
using Study.Lab2.Logic.Logic.kinkiss1.DtoModels;

namespace Study.Lab2.Logic.kinkiss1;

public class ServerRequestService : IServerRequestService
{
    private readonly IRequestService _requestService;
    private readonly IResponseProcessor _responseProcessor;
    private readonly IRequestService _rService;

    public ServerRequestService(IRequestService requestService, IResponseProcessor responseProcessor)
    {
        _requestService = requestService;
        _responseProcessor = responseProcessor;
    }

    public string TranslateCatsSync(string jsonString)
    {
        try
        {
            // Парсим входящий JSON
            var jsonDocument = JsonDocument.Parse(jsonString);
            var factText = jsonDocument.RootElement.GetProperty("fact").GetString();

            //// Выводим исходный текст в консоль для отладки
            //Console.WriteLine($"Исходный текст для перевода: {factText}");

            if (string.IsNullOrEmpty(factText))
                throw new Exception("Факт о кошке не найден в JSON");

            // Формируем URL для запроса к Google Translate API
            var encodedText = Uri.EscapeDataString(factText);
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=ru&dt=t&q={encodedText}";

            var response = _requestService.FetchData(url, null);

            // Парсим ответ Google API
            var jsonResponse = JsonDocument.Parse(response);
            var translatedText = jsonResponse.RootElement[0][0][0].GetString();

            //// Выводим переведенный текст в консоль для отладки
            //Console.WriteLine($"Переведенный текст: {translatedText}");

            // Создаем новый JSON с добавленным переводом с явным указанием кодировки
            var jsonObj = new Dictionary<string, object>
            {
                { "fact", factText },
                { "length", factText.Length },
                { "перевод", translatedText }
            };

            return JsonSerializer.Serialize(jsonObj, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при переводе текста: {ex.Message}");
        }
    }

    public string TranslateKanyeSync(string jsonString)
    {
        try
        {
            // Парсим входящий JSON
            var jsonDocument = JsonDocument.Parse(jsonString);
            var quoteText = jsonDocument.RootElement.GetProperty("quote").GetString();

            if (string.IsNullOrEmpty(quoteText))
                throw new Exception("Цитата Канье не найдена в JSON");

            // Формируем URL для запроса к Google Translate API
            var encodedText = Uri.EscapeDataString(quoteText);
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=ru&dt=t&q={encodedText}";

            var response = _requestService.FetchData(url, null);

            // Парсим ответ Google API
            var jsonResponse = JsonDocument.Parse(response);
            var translatedText = jsonResponse.RootElement[0][0][0].GetString();

            // Создаем новый JSON с добавленным переводом с явным указанием кодировки
            var jsonObj = new Dictionary<string, object>
            {
                { "quote", quoteText },
                { "перевод", translatedText }
            };

            return JsonSerializer.Serialize(jsonObj, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при переводе цитаты: {ex.Message}");
        }
    }

    public async Task<string> TranslateCatsAsync(string jsonString, CancellationToken cancellationToken = default)
    {
        try
        {
            // Парсим входящий JSON
            var jsonDocument = JsonDocument.Parse(jsonString);
            var factText = jsonDocument.RootElement.GetProperty("fact").GetString();

            if (string.IsNullOrEmpty(factText))
                throw new Exception("Факт о кошке не найден в JSON");

            // Формируем URL для запроса к Google Translate API
            var encodedText = Uri.EscapeDataString(factText);
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=ru&dt=t&q={encodedText}";

            // Асинхронно выполняем запрос
            var response = await _requestService.FetchDataAsync(url, cancellationToken);

            // Парсим ответ Google API
            var jsonResponse = JsonDocument.Parse(response);
            var translatedText = jsonResponse.RootElement[0][0][0].GetString();

            // Создаем новый JSON с добавленным переводом с явным указанием кодировки
            var jsonObj = new Dictionary<string, object>
            {
                { "fact", factText },
                { "length", factText.Length },
                { "перевод", translatedText }
            };

            return JsonSerializer.Serialize(jsonObj, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при асинхронном переводе текста: {ex.Message}");
        }
    }

    public async Task<string> TranslateKanyeAsync(string jsonString, CancellationToken cancellationToken = default)
    {
        try
        {
            // Парсим входящий JSON
            var jsonDocument = JsonDocument.Parse(jsonString);
            var quoteText = jsonDocument.RootElement.GetProperty("quote").GetString();

            if (string.IsNullOrEmpty(quoteText))
                throw new Exception("Цитата Канье не найдена в JSON");

            // Формируем URL для запроса к Google Translate API
            var encodedText = Uri.EscapeDataString(quoteText);
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=ru&dt=t&q={encodedText}";

            // Асинхронно выполняем запрос
            var response = await _requestService.FetchDataAsync(url, cancellationToken);

            // Парсим ответ Google API
            var jsonResponse = JsonDocument.Parse(response);
            var translatedText = jsonResponse.RootElement[0][0][0].GetString();

            // Создаем новый JSON с добавленным переводом с явным указанием кодировки
            var jsonObj = new Dictionary<string, object>
            {
                { "quote", quoteText },
                { "перевод", translatedText }
            };

            return JsonSerializer.Serialize(jsonObj, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при асинхронном переводе цитаты: {ex.Message}");
        }
    }

    // --- СИНХРОННЫЕ ---

    public string CatGetFacts()
    {
        var url = $"https://catfact.ninja/fact";
        var response = _requestService.FetchData(url, null);

        // Форматируем JSON для лучшей читаемости
        var formattedResponse = _responseProcessor.FormatJson<CatFactResponseDto>(response);
        // Переводим текст
        try
        {
            return TranslateCatsSync(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при переводе: {ex.Message}");
            return formattedResponse;
        }
    }

    public string KanyeRest()
    {
        var url = $"https://api.kanye.rest";
        var response = _requestService.FetchData(url, null);

        // Форматируем JSON для лучшей читаемости
        var formattedResponse = _responseProcessor.FormatJson<KanyeRestResponseDto>(response);

        // Переводим текст
        try
        {
            return TranslateKanyeSync(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при переводе: {ex.Message}");
            return formattedResponse;
        }
    }

    // --- АСИНХРОННЫЕ ---

    public async Task<string> CatGetFactsAsync(CancellationToken cancellationToken = default)
    {
        var url = $"https://catfact.ninja/fact";
        var response = await _requestService.FetchDataAsync(url, cancellationToken);

        // Форматируем JSON для лучшей читаемости
        var formattedResponse = _responseProcessor.FormatJson<CatFactResponseDto>(response);
        // Переводим текст асинхронно
        try
        {
            return await TranslateCatsAsync(response, cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при асинхронном переводе: {ex.Message}");
            return formattedResponse;
        }
    }

    public async Task<string> KanyeRestAsync(CancellationToken cancellationToken = default)
    {
        var url = $"https://api.kanye.rest";
        var response = await _requestService.FetchDataAsync(url, cancellationToken);

        // Форматируем JSON для лучшей читаемости
        var formattedResponse = _responseProcessor.FormatJson<KanyeRestResponseDto>(response);

        // Переводим текст асинхронно
        try
        {
            return await TranslateKanyeAsync(response, cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при асинхронном переводе: {ex.Message}");
            return formattedResponse;
        }
    }

    public void Dispose()
    {
        _rService?.Dispose();
    }
}