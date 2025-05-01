using System.Net;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.xynthh;

namespace Study.Lab2.Logic.UnitTests.xynthh;

[TestFixture]
public class RequestServiceTests
{
    private Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private HttpClient               _httpClient;
    private RequestService           _requestService;

    [SetUp]
    public void Setup()
    {
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_mockHttpMessageHandler.Object);
        _requestService = new RequestService(_httpClient);
    }

    [Test]
    public void FetchData_SuccessfulResponse_ReturnsContent()
    {
        // Arrange
        const string url = "https://example.com/api";
        const string responseContent = "{\"name\":\"Test\"}";
        SetupMockResponse(url, HttpStatusCode.OK, responseContent);

        // Act
        var result = _requestService.FetchData(url);

        // Assert
        Assert.That(result, Is.EqualTo(responseContent));
    }

    [Test]
    public void FetchData_WithHeaders_SendsCorrectHeaders()
    {
        // Arrange
        const string url = "https://example.com/api";
        const string responseContent = "{\"name\":\"Test\"}";
        var headers = new Dictionary<string, string>
        {
            { "x-api-key", "test-key" }
        };

        SetupMockResponse(url, HttpStatusCode.OK, responseContent, headers);

        // Act
        var result = _requestService.FetchData(url, headers);

        // Assert
        Assert.That(result, Is.EqualTo(responseContent));
        _mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Headers.Contains("x-api-key") &&
                req.Headers.GetValues("x-api-key").First() == "test-key"),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Test]
    public void FetchData_ErrorResponse_ThrowsException()
    {
        // Arrange
        const string url = "https://example.com/api";
        SetupMockResponse(url, HttpStatusCode.InternalServerError, "Error");

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(url));
        // Проверяем, что сообщение содержит "HTTP Error" и имя статус-кода, а не конкретное число
        Assert.IsTrue(exception != null && exception.Message.Contains("HTTP Error"));
        Assert.IsTrue(exception.Message.Contains("InternalServerError"));
    }


    [Test]
    public async Task FetchDataAsync_SuccessfulResponse_ReturnsContent()
    {
        // Arrange
        const string url = "https://example.com/api";
        const string responseContent = "{\"name\":\"Test\"}";
        SetupMockResponse(url, HttpStatusCode.OK, responseContent);

        // Act
        var result = await _requestService.FetchDataAsync(url);

        // Assert
        Assert.That(result, Is.EqualTo(responseContent));
    }

    [Test]
    public async Task FetchDataAsync_WithHeaders_SendsCorrectHeaders()
    {
        // Arrange
        const string url = "https://example.com/api";
        const string responseContent = "{\"name\":\"Test\"}";
        var headers = new Dictionary<string, string>
        {
            { "x-api-key", "test-key" }
        };

        SetupMockResponse(url, HttpStatusCode.OK, responseContent, headers);

        // Act
        var result = await _requestService.FetchDataAsync(url, headers);

        // Assert
        Assert.That(result, Is.EqualTo(responseContent));
        _mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Headers.Contains("x-api-key") &&
                req.Headers.GetValues("x-api-key").First() == "test-key"),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Test]
    public void FetchDataAsync_ErrorResponse_ThrowsException()
    {
        // Arrange
        const string url = "https://example.com/api";
        SetupMockResponse(url, HttpStatusCode.NotFound, "Not Found");

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(url));
        // Проверяем, что сообщение содержит "HTTP Error" и имя статус-кода, а не конкретное число
        Assert.IsTrue(exception != null && exception.Message.Contains("HTTP Error"));
        Assert.IsTrue(exception.Message.Contains("NotFound"));
    }

    private void SetupMockResponse(string url, HttpStatusCode statusCode, string content,
        Dictionary<string, string>        expectedHeaders = null)
    {
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString() == url &&
                    (expectedHeaders == null || CheckHeaders(req, expectedHeaders))),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });
    }

    private bool CheckHeaders(HttpRequestMessage request, Dictionary<string, string> expectedHeaders)
    {
        foreach (var header in expectedHeaders)
            if (!request.Headers.Contains(header.Key) ||
                !request.Headers.GetValues(header.Key).Contains(header.Value))
                return false;

        return true;
    }

    [TearDown]
    public void TearDown()
    {
        _requestService?.Dispose();
        _httpClient?.Dispose();
    }
}