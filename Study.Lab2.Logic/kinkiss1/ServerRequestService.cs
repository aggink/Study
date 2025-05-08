using System.Text.Json;
using Study.Lab2.Logic.Interfaces.kinkiss1;
using Study.Lab2.Logic.kinkiss1.DtoModels;

namespace Study.Lab2.Logic.kinkiss1;

public class ServerRequestService : IServerRequestService
{
    private readonly IRequestService _requestService;
    private readonly IResponseProcessor _responseProcessor;

    public ServerRequestService(IRequestService requestService, IResponseProcessor responseProcessor)
    {
        _requestService = requestService;
        _responseProcessor = responseProcessor;
    }

    #region Translate sync and async

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
            // 1. Десериализуем входной JSON от Cat Facts API
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var catFactDto = JsonSerializer.Deserialize<CatFactResponseDto>(jsonString, options);

            if (catFactDto == null || string.IsNullOrEmpty(catFactDto.Fact))
                throw new Exception("Факт о кошке не найден в JSON");

            // 2. Отправляем запрос к Google Translate API
            var encodedText = Uri.EscapeDataString(catFactDto.Fact);
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=ru&dt=t&q={encodedText}";

            var response = await _requestService.FetchDataAsync(url, cancellationToken);

            // 3. Создаем объект для хранения перевода
            string translatedText;
            try
            {
                // Пытаемся использовать наш DTO-класс
                var translateResponse = new GoogleTranslateResponse(response);
                translatedText = translateResponse.TranslatedText;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при десериализации: {ex.Message}");
                // Запасной вариант с JsonDocument
                var jsonResponse = JsonDocument.Parse(response);
                translatedText = jsonResponse.RootElement[0][0][0].GetString();
            }

            // 4. Создаем объект ответа и сериализуем его
            var resultDto = new CatFactTranslatedResponseDto
            {
                Fact = catFactDto.Fact,
                Length = catFactDto.Length,
                Translate = translatedText ?? "Перевод не доступен"
            };

            // 5. Сериализуем ответ для вывода в консоль
            return JsonSerializer.Serialize(resultDto, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при асинхронном переводе текста: {ex.Message}", ex);
        }
    }

    public async Task<string> TranslateKanyeAsync(string jsonString, CancellationToken cancellationToken = default)
    {
        try
        {
            // Десериализуем входящий JSON в DTO
            var kanyeQuoteDto = JsonSerializer.Deserialize<KanyeRestResponseDto>(jsonString);

            if (kanyeQuoteDto == null || string.IsNullOrEmpty(kanyeQuoteDto.Quote))
                throw new Exception("Цитата Канье не найдена в JSON");

            // Используем общий метод для перевода
            var translatedText = await TranslateTextAsync(kanyeQuoteDto.Quote, cancellationToken);

            // Создаем объект для ответа
            var responseDto = new
            {
                quote = kanyeQuoteDto.Quote,
                перевод = translatedText
            };

            // Сериализуем для вывода в консоль
            return JsonSerializer.Serialize(responseDto, new JsonSerializerOptions
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

    #endregion

    #region Sync
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

    #endregion

    #region Async

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

    #endregion

    public void Dispose()
    {
        _requestService?.Dispose();
    }

    private async Task<string> TranslateTextAsync(string sourceText, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(sourceText))
            throw new ArgumentException("Текст для перевода не может быть пустым", nameof(sourceText));

        // Формируем URL для запроса к Google Translate API
        var encodedText = Uri.EscapeDataString(sourceText);
        var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=ru&dt=t&q={encodedText}";

        // Асинхронно выполняем запрос
        var response = await _requestService.FetchDataAsync(url, cancellationToken);

        try
        {
            // Пытаемся десериализовать в нашу модель
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Метод 1: Используем нашу специальную модель
            var translateResponse = new GoogleTranslateResponse(response);
            return translateResponse.TranslatedText;

            // Метод 2 (альтернативный): Используем динамическую десериализацию
            // var jsonResponse = JsonDocument.Parse(response);
            // return jsonResponse.RootElement[0][0][0].GetString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при десериализации ответа от Google API: {ex.Message}");

            // Возвращаемся к проверенному методу с JsonDocument если десериализация не удалась
            var jsonResponse = JsonDocument.Parse(response);
            return jsonResponse.RootElement[0][0][0].GetString();
        }
    }
}