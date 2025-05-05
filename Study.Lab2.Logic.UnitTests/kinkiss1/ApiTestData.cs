using System.Text.Json;
using System.Collections.Generic;

namespace Study.Lab2.Logic.UnitTests.kinkiss1;

internal static class ApiTestData
{
    #region Общие константы

    internal const string ApiKeyHeader = "x-api-key";

    #endregion

    #region RequestService

    internal const string ApiKeyValueRequestService = "test-key";

    internal const string RequestServiceTestUrl = "https://example.com/api";
    internal const string RequestServiceTestResponse = "{\"name\":\"Test\"}";

    internal static readonly Dictionary<string, string> RequestServiceTestHeaders = new()
    {
        { ApiKeyHeader, ApiKeyValueRequestService }
    };

    #endregion

    #region ServerRequestService

    // Базовые URL
    internal const string CatFactsBaseUrl = "https://catfact.ninja";
    internal const string KanyeRestBaseUrl = "https://api.kanye.rest";
    internal const string GoogleTranslateBaseUrl = "https://translate.googleapis.com/translate_a";

    // Классы для представления данных
    internal class CatFactResponse
    {
        public string Fact { get; set; }
        public int Length { get; set; }
    }

    internal class CatFactTranslatedResponse : CatFactResponse
    {
        public string Перевод { get; set; }
    }

    internal class KanyeRestResponse
    {
        public string Quote { get; set; }
    }

    internal class KanyeRestTranslatedResponse : KanyeRestResponse
    {
        public string Перевод { get; set; }
    }

    internal class GoogleTranslateResponseItem
    {
        public string TranslatedText { get; set; }
        public string OriginalText { get; set; }
    }

    internal class GoogleTranslateResponse
    {
        public List<List<GoogleTranslateResponseItem>> Data { get; set; }
        public string SourceLanguage { get; set; }
    }

    // JSON ответы через сериализацию объектов
    internal static string CatFactsResponse => GetCatFactsResponseJson();
    internal static string KanyeQuoteResponse => GetKanyeRestResponseJson();
    internal static string GoogleTranslateCatFactResponse => GetGoogleTranslateCatFactResponseJson();
    internal static string GoogleTranslateKanyeResponse => GetGoogleTranslateKanyeResponseJson();
    internal static string CatFactsWithTranslationFormatted => GetCatFactsWithTranslationFormattedJson();
    internal static string KanyeRestWithTranslationFormatted => GetKanyeRestWithTranslationFormattedJson();

    // Переведенные данные
    internal const string TranslatedCatFactText = "У кошек есть индивидуальные предпочтения для царапин поверхностей и углов. Некоторые являются горизонтальными царапаниями, в то время как другие тренируют свои когти вертикально.";
    internal const string TranslatedKanyeQuoteText = "Поверьте мне... Я не остановлюсь";

    // Ошибки
    internal const string CatFactNotFoundErrorMessage = "Факт о кошке не найден в JSON";
    internal const string KanyeQuoteNotFoundErrorMessage = "Цитата Канье не найдена в JSON";

    // Методы для получения JSON-строк
    internal static string GetCatFactsResponseJson()
    {
        var response = new CatFactResponse
        {
            Fact = "Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.",
            Length = 145
        };
        return JsonSerializer.Serialize(response);
    }

    internal static string GetKanyeRestResponseJson()
    {
        var response = new KanyeRestResponse
        {
            Quote = "Trust me... I won't stop"
        };
        return JsonSerializer.Serialize(response);
    }

    internal static string GetCatFactsWithTranslationFormattedJson()
    {
        var response = new CatFactTranslatedResponse
        {
            Fact = "Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.",
            Length = 145,
            Перевод = TranslatedCatFactText
        };
        return JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });
    }

    internal static string GetKanyeRestWithTranslationFormattedJson()
    {
        var response = new KanyeRestTranslatedResponse
        {
            Quote = "Trust me... I won't stop",
            Перевод = TranslatedKanyeQuoteText
        };
        return JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });
    }

    internal static string GetGoogleTranslateCatFactResponseJson()
    {
        // Представление формата ответа Google Translate
        var response = new object[]
        {
        new object[]
        {
            new object[]
            {
                TranslatedCatFactText,
                "Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.",
                null, null, 3, null, null, null, 1
            }
        },
        null,
        "en"
        };

        return JsonSerializer.Serialize(response);
    }

    internal static string GetGoogleTranslateKanyeResponseJson()
    {
        // Представление формата ответа Google Translate
        var response = new object[]
        {
        new object[]
        {
            new object[]
            {
                TranslatedKanyeQuoteText,
                "Trust me... I won't stop",
                null, null, 3, null, null, null, 1
            }
        },
        null,
        "en"
        };

        return JsonSerializer.Serialize(response);
    }

    // Методы генерации URL
    internal static string GetCatFactsUrl()
    {
        return $"{CatFactsBaseUrl}/fact";
    }

    internal static string GetKanyeRestUrl()
    {
        return $"{KanyeRestBaseUrl}";
    }

    internal static string GetGoogleTranslateUrl(string text, string sourceLang = "en", string targetLang = "ru")
    {
        var encodedText = Uri.EscapeDataString(text);
        return $"{GoogleTranslateBaseUrl}/single?client=gtx&sl={sourceLang}&tl={targetLang}&dt=t&q={encodedText}";
    }

    #endregion
}
