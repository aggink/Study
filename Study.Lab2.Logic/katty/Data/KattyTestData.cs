namespace Study.Lab2.Logic.katty.Data;

public static class KattyTestData
{
    public static readonly string[] Urls =
    {
        "https://jsonplaceholder.typicode.com/todos/1",
        "https://jsonplaceholder.typicode.com/posts/1",
        "https://jsonplaceholder.typicode.com/users/1"
    };

    public static readonly string[] RawResponses =
    {
        @"{""userId"": 1, ""id"": 1, ""title"": ""Test"", ""completed"": false}",
        @"{""userId"": 1, ""id"": 1, ""title"": ""Post"", ""body"": ""Body""}",
        @"{""id"": 1, ""name"": ""User"", ""username"": ""User1"", ""email"": ""user@example.com""}"
    };

    public static readonly string[] ProcessedResponses =
    {
        "{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"Test\",\n  \"completed\": false\n}",
        "{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"Post\",\n  \"body\": \"Body\"\n}",
        "{\n  \"id\": 1,\n  \"name\": \"User\",\n  \"username\": \"User1\",\n  \"email\": \"user@example.com\"\n}"
    };

    public static readonly string[] FormattedResponses =
    {
        $"Ответ от сервера {Urls[0]}:\n{ProcessedResponses[0]}",
        $"Ответ от сервера {Urls[1]}:\n{ProcessedResponses[1]}",
        $"Ответ от сервера {Urls[2]}:\n{ProcessedResponses[2]}"
    };

    public static readonly string ErrorResponse = "Error: 404 Not Found";
}
