using Moq;
using Moq.Protected;
using Study.Lab2.Logic.p0se1d0n;
using Study.Lab2.Logic.p0se1d0n.DtoModels;
using System.Net;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.p0se1d0n;

[TestFixture]
public class RequestServiceTests
{
    private const string REQUEST_URL = "https://dummyjson.com/recipes/1";

    private RequestService _requestService;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [TearDown]
    public void Dispose()
    {
        _requestService?.Dispose();
    }

    [Test]
    public void FetchData_Success_ReturnsResponse()
    {
        var data = new RecipeDto
        {
            Name = "Classic Margherita Pizza",
            Ingredients = ["Pizza dough", "Tomato sauce", "Fresh mozzarella cheese", "Fresh basil leaves", "Olive oil", "Salt and pepper to taste"],
            Instructions = ["Preheat the oven to 475°F (245°C).", "Roll out the pizza dough and spread tomato sauce evenly.", "Top with slices of fresh mozzarella and fresh basil leaves.", "Drizzle with olive oil and season with salt and pepper.", "Bake in the preheated oven for 12-15 minutes or until the crust is golden brown.", "Slice and serve hot."],
            PrepTimeMinutes = 20,
            CookTimeMinutes = 15,
            Difficulty = "Easy"
        };

        var json = JsonSerializer.Serialize(data);
        SetupHttpResponse(REQUEST_URL, json, HttpStatusCode.OK);

        var result = _requestService.FetchData(REQUEST_URL);

        Assert.That(result, Is.EqualTo(json));
    }

    [Test]
    public void FetchDataAsync_Failure_ThrowsException()
    {
        SetupHttpResponse(REQUEST_URL, "Not Found", HttpStatusCode.NotFound);

        var exception = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(REQUEST_URL, CancellationToken.None));

        StringAssert.Contains("Ошибка: NotFound", exception.Message);
    }

    private void SetupHttpResponse(string url, string content, HttpStatusCode statusCode)
    {
        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == url),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });
    }
}