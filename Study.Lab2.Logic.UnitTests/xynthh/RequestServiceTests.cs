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

    private const string Url             = "https://example.com/api";
    private const string ResponseContent = "{\"name\":\"Test\"}";

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
        SetupMockResponse(HttpStatusCode.OK, ResponseContent);

        // Act
        var result = _requestService.FetchData(Url);

        // Assert
        Assert.That(result, Is.EqualTo(ResponseContent));
    }

    [Test]
    public void FetchData_WithHeaders_SendsCorrectHeaders()
    {
        // Arrange
        var headers = new Dictionary<string, string>
        {
            { "x-api-key", "test-key" }
        };

        SetupMockResponse(HttpStatusCode.OK, ResponseContent, headers);

        // Act
        var result = _requestService.FetchData(Url, headers);

        // Assert
        Assert.That(result, Is.EqualTo(ResponseContent));
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
        SetupMockResponse(HttpStatusCode.InternalServerError, "Error");

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(Url));
        // Проверяем, что сообщение содержит "HTTP Error" и имя статус-кода, а не конкретное число
        Assert.IsTrue(exception != null && exception.Message.Contains("HTTP Error"));
        Assert.IsTrue(exception.Message.Contains("InternalServerError"));
    }


    [Test]
    public async Task FetchDataAsync_SuccessfulResponse_ReturnsContent()
    {
        // Arrange
        SetupMockResponse(HttpStatusCode.OK, ResponseContent);

        // Act
        var result = await _requestService.FetchDataAsync(Url);

        // Assert
        Assert.That(result, Is.EqualTo(ResponseContent));
    }

    [Test]
    public async Task FetchDataAsync_WithHeaders_SendsCorrectHeaders()
    {
        // Arrange
        var headers = new Dictionary<string, string>
        {
            { "x-api-key", "test-key" }
        };

        SetupMockResponse(HttpStatusCode.OK, ResponseContent, headers);

        // Act
        var result = await _requestService.FetchDataAsync(Url, headers);

        // Assert
        Assert.That(result, Is.EqualTo(ResponseContent));
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
        SetupMockResponse(HttpStatusCode.NotFound, "Not Found");

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(Url));
        // Проверяем, что сообщение содержит "HTTP Error" и имя статус-кода, а не конкретное число
        Assert.IsTrue(exception != null && exception.Message.Contains("HTTP Error"));
        Assert.IsTrue(exception.Message.Contains("NotFound"));
    }

    private void SetupMockResponse(HttpStatusCode statusCode, string content,
        Dictionary<string, string>                expectedHeaders = null)
    {
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString() == Url &&
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