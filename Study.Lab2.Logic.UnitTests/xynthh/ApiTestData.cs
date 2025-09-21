namespace Study.Lab2.Logic.UnitTests.xynthh;

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

    internal const string ApiKeyValueReqRes = "reqres-free-v1";

    // Базовые URL
    internal const string JsonPlaceholderBaseUrl = "https://jsonplaceholder.typicode.com";
    internal const string ReqResBaseUrl = "https://reqres.in/api";

    // ID для тестов
    internal const int JsonPlaceholderTestUserId = 1;
    internal const int ReqResTestUserId = 2;
    internal const int JsonPlaceholderTestPostId = 3;
    internal const int NonExistentUserId = 999;

    internal static readonly Dictionary<string, string> ReqResHeaders = new()
    {
        { ApiKeyHeader, ApiKeyValueReqRes }
    };

    // JSON ответы
    internal const string JsonPlaceholderUserResponse = "{\"id\":1,\"name\":\"User\"}";
    internal const string ReqResUserResponseRaw = "{\"data\":{\"id\":2,\"name\":\"Janet\"}}";
    internal const string JsonPlaceholderPostResponse = "{\"id\":1,\"title\":\"Post Title\",\"body\":\"Post body\"}";

    // Форматированные JSON ответы
    internal const string JsonPlaceholderUserFormatted = "{\n  \"id\": 1,\n  \"name\": \"User\"\n}";
    internal const string ReqResUserFormatted = "{\n  \"data\": {\n    \"id\": 2,\n    \"name\": \"Janet\"\n  }\n}";

    internal const string JsonPlaceholderPostFormatted =
        "{\n  \"id\": 1,\n  \"title\": \"Post Title\",\n  \"body\": \"Post body\"\n}";

    // Ошибки
    internal const string NotFoundErrorResponseJson = "{\"error\":\"Not found\"}";
    internal const string UserNotFoundErrorResponseJson = "{\"error\":\"User not found\"}";
    internal const string NotFoundErrorMessage = "Not found";
    internal const string UserNotFoundErrorMessage = "User not found";

    // Методы генерации URL
    internal static string GetJsonPlaceholderUserUrl(int userId)
    {
        return $"{JsonPlaceholderBaseUrl}/users/{userId}";
    }

    internal static string GetReqResUserUrl(int userId)
    {
        return $"{ReqResBaseUrl}/users/{userId}";
    }

    internal static string GetJsonPlaceholderPostUrl(int postId)
    {
        return $"{JsonPlaceholderBaseUrl}/posts/{postId}";
    }

    #endregion
}