namespace Study.Lab2.Logic.UnitTests.neijrr;

internal static class ApiTestData
{
    // Общие для нескольких тестов данные с jsonplaceholder.typicode.com
    #region JsonPlaceholder

    internal const string JsonPlaceholder_URL = "https://jsonplaceholder.typicode.com/";
    internal const string JsonPlaceholder_Post_One =
        "{\"userId\":1,\"id\":1,\"title\":\"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\",\"body\":\"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
    internal const string JsonPlaceholder_Post_One_Pretty =
        """
        {
          "userId": 1,
          "id": 1,
          "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
          "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
        }
        """;

    #endregion JsonPlaceholder

    // Данные для тестов RequestService
    #region RequestService

    internal const string RequestService_TestUrl = "https://example.com/api";
    internal const string RequestService_TestResponse = "{\"name\":\"Test\"}";

    #endregion

    // Данные для тестов ResponseProcessor
    #region ResponseProcessor

    internal const string ResponseProcessor_ErrorMessage = "Internal server error";
    internal const string ResponseProcessor_TestErrorResponse = $"{{\"error\": \"{ResponseProcessor_ErrorMessage}\"}}";
    internal const string ResponseProcessor_TestComplexErrorResponse = $"{{\"error\": {{ \"code\": 500, \"message\": \"{ResponseProcessor_ErrorMessage}\"}}}}";
    internal const string ResponseProcessor_TestInvalidResponse = "{\"text\": \"123\"";

    #endregion

    #region ServerRequestService

    internal const int ServerRequestService_UserID = 3;
    internal const int ServerRequestService_NewPostID = 101;
    internal const string ServerRequestService_NewPostTitle = "Title";
    internal const string ServerRequestService_NewPostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris accumsan tempor metus sit amet sollicitudin.";
    #endregion
}
