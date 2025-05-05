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

    // JSON ответы
    internal const string CatFactsResponse = "{\"fact\":\"Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.\",\"length\":145}";
    internal const string KanyeRestResponse = "{\"quote\":\"Trust me... I won't stop\"}";

    // Ответы от Google Translate API
    internal const string GoogleTranslateCatFactResponse = "[[[\"\u0423 \u043A\u043E\u0448\u0435\u043A \u0435\u0441\u0442\u044C \u0438\u043D\u0434\u0438\u0432\u0438\u0434\u0443\u0430\u043B\u044C\u043D\u044B\u0435 \u043F\u0440\u0435\u0434\u043F\u043E\u0447\u0442\u0435\u043D\u0438\u044F \u0434\u043B\u044F \u0446\u0430\u0440\u0430\u043F\u0438\u043D \u043F\u043E\u0432\u0435\u0440\u0445\u043D\u043E\u0441\u0442\u0435\u0439 \u0438 \u0443\u0433\u043B\u043E\u0432. \u041D\u0435\u043A\u043E\u0442\u043E\u0440\u044B\u0435 \u044F\u0432\u043B\u044F\u044E\u0442\u0441\u044F \u0433\u043E\u0440\u0438\u0437\u043E\u043D\u0442\u0430\u043B\u044C\u043D\u044B\u043C\u0438 \u0446\u0430\u0440\u0430\u043F\u0430\u043D\u0438\u044F\u043C\u0438, \u0432 \u0442\u043E \u0432\u0440\u0435\u043C\u044F \u043A\u0430\u043A \u0434\u0440\u0443\u0433\u0438\u0435 \u0442\u0440\u0435\u043D\u0438\u0440\u0443\u044E\u0442 \u0441\u0432\u043E\u0438 \u043A\u043E\u0433\u0442\u0438 \u0432\u0435\u0440\u0442\u0438\u043A\u0430\u043B\u044C\u043D\u043E.\",\"Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.\",null,null,3,null,null,null,1]],null,\"en\"]";
    internal const string GoogleTranslateKanyeResponse = "[[[\"\u041F\u043E\u0432\u0435\u0440\u044C\u0442\u0435 \u043C\u043D\u0435... \u042F \u043D\u0435 \u043E\u0441\u0442\u0430\u043D\u043E\u0432\u043B\u044E\u0441\u044C\",\"Trust me... I won't stop\",null,null,3,null,null,null,1]],null,\"en\"]";

    // Переведенные данные
    internal const string TranslatedCatFactText = "У кошек есть индивидуальные предпочтения для царапин поверхностей и углов. Некоторые являются горизонтальными царапаниями, в то время как другие тренируют свои когти вертикально.";
    internal const string TranslatedKanyeQuoteText = "Поверьте мне... Я не остановлюсь";

    // Форматированные JSON ответы с переводом
    internal const string CatFactsWithTranslationFormatted = "{\n  \"fact\": \"Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.\",\n  \"length\": 145,\n  \"перевод\": \"У кошек есть индивидуальные предпочтения для царапин поверхностей и углов. Некоторые являются горизонтальными царапаниями, в то время как другие тренируют свои когти вертикально.\"\n}";
    internal const string KanyeRestWithTranslationFormatted = "{\n  \"quote\": \"Trust me... I won't stop\",\n  \"перевод\": \"Поверьте мне... Я не остановлюсь\"\n}";

    // Ошибки
    internal const string CatFactNotFoundErrorMessage = "Факт о кошке не найден в JSON";
    internal const string KanyeQuoteNotFoundErrorMessage = "Цитата Канье не найдена в JSON";

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