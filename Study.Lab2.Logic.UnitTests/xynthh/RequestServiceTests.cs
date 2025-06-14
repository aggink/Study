using System.Net;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.xynthh;

namespace Study.Lab2.Logic.UnitTests.xynthh;

[TestFixture]
public class RequestServiceTests
{
    private Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private HttpClient _httpClient;
    private RequestService _requestService;

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
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.RequestServiceTestResponse);

        // Act
        var result = _requestService.FetchData(ApiTestData.RequestServiceTestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(ApiTestData.RequestServiceTestResponse));
    }

    [Test]
    public void FetchData_WithHeaders_SendsCorrectHeaders()
    {
        // Arrange
        SetupMockResponse(
            HttpStatusCode.OK,
            ApiTestData.RequestServiceTestResponse,
            ApiTestData.RequestServiceTestHeaders);

        // Act
        var result =
            _requestService.FetchData(ApiTestData.RequestServiceTestUrl, ApiTestData.RequestServiceTestHeaders);

        // Assert
        Assert.That(result, Is.EqualTo(ApiTestData.RequestServiceTestResponse));
        _mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Headers.Contains(ApiTestData.ApiKeyHeader) &&
                req.Headers.GetValues(ApiTestData.ApiKeyHeader).First() ==
                ApiTestData.ApiKeyValueRequestService),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Test]
    public void FetchData_ErrorResponse_ThrowsException()
    {
        // Arrange
        SetupMockResponse(HttpStatusCode.InternalServerError, "Error");

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(ApiTestData.RequestServiceTestUrl));
        Assert.IsTrue(exception != null && exception.Message.Contains("HTTP Error"));
        Assert.IsTrue(exception.Message.Contains("InternalServerError"));
    }


    [Test]
    public async Task FetchDataAsync_SuccessfulResponse_ReturnsContent()
    {
        // Arrange
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.RequestServiceTestResponse);

        // Act
        var result = await _requestService.FetchDataAsync(ApiTestData.RequestServiceTestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(ApiTestData.RequestServiceTestResponse));
    }

    [Test]
    public async Task FetchDataAsync_WithHeaders_SendsCorrectHeaders()
    {
        // Arrange
        SetupMockResponse(
            HttpStatusCode.OK,
            ApiTestData.RequestServiceTestResponse,
            ApiTestData.RequestServiceTestHeaders);

        // Act
        var result = await _requestService.FetchDataAsync(
            ApiTestData.RequestServiceTestUrl,
            ApiTestData.RequestServiceTestHeaders);

        // Assert
        Assert.That(result, Is.EqualTo(ApiTestData.RequestServiceTestResponse));
        _mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Headers.Contains(ApiTestData.ApiKeyHeader) &&
                req.Headers.GetValues(ApiTestData.ApiKeyHeader).First() ==
                ApiTestData.ApiKeyValueRequestService),
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
            await _requestService.FetchDataAsync(ApiTestData.RequestServiceTestUrl));
        Assert.IsTrue(exception != null && exception.Message.Contains("HTTP Error"));
        Assert.IsTrue(exception.Message.Contains("NotFound"));
    }

    private void SetupMockResponse(
        HttpStatusCode statusCode,
        string content,
        Dictionary<string, string> expectedHeaders = null)
    {
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString() == ApiTestData.RequestServiceTestUrl &&
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