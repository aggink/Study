using System.Net;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.kinkiss1;

namespace Study.Lab2.Logic.UnitTests.kinkiss1;

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
        var exception = Assert.Throws<HttpRequestException>(() =>
            _requestService.FetchData(ApiTestData.RequestServiceTestUrl));

        StringAssert.Contains("Ошибка запроса", exception.Message);
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
    public void FetchDataAsync_ErrorResponse_ThrowsException()
    {
        // Arrange
        SetupMockResponse(HttpStatusCode.NotFound, "Not Found");

        // Act & Assert
        var exception = Assert.ThrowsAsync<HttpRequestException>(async () =>
            await _requestService.FetchDataAsync(ApiTestData.RequestServiceTestUrl));

        StringAssert.Contains("Ошибка при запросе к", exception.Message);
    }

    [Test]
    public void CatFacts_SuccessfulResponse_ReturnsCorrectData()
    {
        // Arrange
        var catFactsUrl = ApiTestData.GetCatFactsUrl();
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.CatFactsResponse,
            null, catFactsUrl);

        // Act
        var result = _requestService.FetchData(catFactsUrl);

        // Assert
        Assert.That(result, Is.EqualTo(ApiTestData.CatFactsResponse));
        Assert.That(result, Does.Contain("fact"));
        Assert.That(result, Does.Contain("length"));
    }

    [Test]
    public async Task CatFactsAsync_SuccessfulResponse_ReturnsCorrectData()
    {
        // Arrange
        var catFactsUrl = ApiTestData.GetCatFactsUrl();
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.CatFactsResponse,
            null, catFactsUrl);

        // Act
        var result = await _requestService.FetchDataAsync(catFactsUrl);

        // Assert
        Assert.That(result, Is.EqualTo(ApiTestData.CatFactsResponse));
        Assert.That(result, Does.Contain("fact"));
    }

    private void SetupMockResponse(
    HttpStatusCode statusCode,
    string content,
    Dictionary<string, string> expectedHeaders = null,
    string url = null)
    {
        url ??= ApiTestData.RequestServiceTestUrl;

        Console.WriteLine($"Setting up mock for URL: {url}");

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
