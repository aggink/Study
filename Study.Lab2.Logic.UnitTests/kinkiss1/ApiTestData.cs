using System.Text.Json;
using Study.Lab2.Logic.kinkiss1.DtoModels;

namespace Study.Lab2.Logic.UnitTests.kinkiss1;


public static class ApiTestData
{
    #region general constats

    public const string ApiKeyHeader = "x-api-key";

    #endregion

    #region RequestService

    public const string ApiKeyValueRequestService = "test-key";

    public const string RequestServiceTestUrl = "https://example.com/api";
    public const string RequestServiceTestResponse = "{\"name\":\"Test\"}";

    public static readonly Dictionary<string, string> RequestServiceTestHeaders = new()
    {
        { ApiKeyHeader, ApiKeyValueRequestService }
    };

    #endregion

    #region ServerRequestService

    // Base URL
    public const string CatFactsBaseUrl = "https://catfact.ninja";
    public const string KanyeRestBaseUrl = "https://api.kanye.rest";
    public const string GoogleTranslateBaseUrl = "https://translate.googleapis.com/translate_a";

    // JSON responses through object serialization
    public static string CatFactsResponse => GetCatFactsResponseJson();
    public static string KanyeQuoteResponse => GetKanyeRestResponseJson();
    public static string GoogleTranslateCatFactResponse => GetGoogleTranslateCatFactResponseJson();
    public static string GoogleTranslateKanyeResponse => GetGoogleTranslateKanyeResponseJson();
    public static string CatFactsWithTranslationFormatted => GetCatFactsWithTranslationFormattedJson();
    public static string KanyeRestWithTranslationFormatted => GetKanyeRestWithTranslationFormattedJson();

    // translated data
    public const string TranslatedCatFactText = "У кошек есть индивидуальные предпочтения для царапин поверхностей и углов. Некоторые являются горизонтальными царапаниями, в то время как другие тренируют свои когти вертикально.";
    public const string TranslatedKanyeQuoteText = "Поверьте мне... Я не остановлюсь";

    // Ошибки
    public const string CatFactNotFoundErrorMessage = "Факт о кошке не найден в JSON";
    public const string KanyeQuoteNotFoundErrorMessage = "Цитата Канье не найдена в JSON";

    // Methods for obtaining JSON strings
    public static string GetCatFactsResponseJson()
    {
        var response = new CatFactResponseDto
        {
            Fact = "Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.",
            Length = 145
        };
        return JsonSerializer.Serialize(response);
    }

    public static string GetKanyeRestResponseJson()
    {
        var response = new KanyeRestResponseDto
        {
            Quote = "Trust me... I won't stop"
        };
        return JsonSerializer.Serialize(response);
    }

    public static string GetCatFactsWithTranslationFormattedJson()
    {
        var response = new CatFactTranslatedResponseDto
        {
            Fact = "Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.",
            Length = 145,
            Translate = TranslatedCatFactText
        };
        return JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });
    }

    public static string GetKanyeRestWithTranslationFormattedJson()
    {
        var response = new KanyeRestTranslatedResponseDto
        {
            Quote = "Trust me... I won't stop",
            Translate = TranslatedKanyeQuoteText
        };
        return JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });
    }

    public static string GetGoogleTranslateCatFactResponseJson()
    {
        var response = new GoogleTranslateResponseDto
        {
            Translations = new List<GoogleTranslateSegmentDto>
            {
                new GoogleTranslateSegmentDto
                {
                    Items = new List<MainGoogleTranslateDto>
                    {
                        new MainGoogleTranslateDto
                        {
                            TranslatedText = TranslatedCatFactText,
                            OriginalText = "Cats have individual preferences for scratching surfaces and angles. Some are horizontal scratchers while others exercise their claws vertically.",
                            Confidence = 3,
                            Index = 1
                        }
                    }
                }
            },
            SourceLanguage = "en"
        };

        return JsonSerializer.Serialize(response);
    }

    public static string GetGoogleTranslateKanyeResponseJson()
    {
        var response = new GoogleTranslateResponseDto
        {
            Translations = new List<GoogleTranslateSegmentDto>
            {
                new GoogleTranslateSegmentDto
                {
                    Items = new List<MainGoogleTranslateDto>
                    {
                        new MainGoogleTranslateDto
                        {
                            TranslatedText = TranslatedKanyeQuoteText,
                            OriginalText = "Trust me... I won't stop",
                            Confidence = 3,
                            Index = 1
                        }
                    }
                }
            },
            SourceLanguage = "en"
        };

        return JsonSerializer.Serialize(response);
    }

    // generation methods url
    public static string GetCatFactsUrl()
    {
        return $"{CatFactsBaseUrl}/fact";
    }

    public static string GetKanyeRestUrl()
    {
        return $"{KanyeRestBaseUrl}";
    }

    public static string GetGoogleTranslateUrl(string text, string sourceLang = "en", string targetLang = "ru")
    {
        var builder = new UriBuilder(GoogleTranslateBaseUrl)
        {
            Path = Path.Combine(new Uri(GoogleTranslateBaseUrl).AbsolutePath, "single")
        };

        var queryParams = System.Web.HttpUtility.ParseQueryString(string.Empty);
        queryParams["client"] = "gtx";
        queryParams["sl"] = sourceLang;
        queryParams["tl"] = targetLang;
        queryParams["dt"] = "t";
        queryParams["q"] = text;

        builder.Query = queryParams.ToString();

        return builder.Uri.ToString();
    }
    #endregion
}