using System.Net;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.UnitTests.kinkiss1;

namespace Study.Lab2.Logic.kinkiss1;

[TestFixture]
public class RequestServiceTests
{
    private Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private RequestService _requestService;

    [SetUp]
    public void Setup()
    {
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_mockHttpMessageHandler.Object);
        _requestService = new RequestService(httpClient);
    }

    [TearDown]
    public void TearDown()
    {
        _requestService?.Dispose();
    }

    [Test]
    public void FetchData_SuccessfulResponse_ReturnsContent()
    {
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.RequestServiceTestResponse);

        var result = _requestService.FetchData(ApiTestData.RequestServiceTestUrl);

        Assert.That(result, Is.EqualTo(ApiTestData.RequestServiceTestResponse));
    }

    [Test]
    public void FetchData_WithHeaders_SendsCorrectHeaders()
    {
        SetupMockResponse(
            HttpStatusCode.OK,
            ApiTestData.RequestServiceTestResponse,
            ApiTestData.RequestServiceTestHeaders);

        var result =
            _requestService.FetchData(ApiTestData.RequestServiceTestUrl, ApiTestData.RequestServiceTestHeaders);

        Assert.That(result, Is.EqualTo(ApiTestData.RequestServiceTestResponse));

        VerifyRequestSent(ApiTestData.RequestServiceTestUrl, times: Times.Once());
        VerifyHeadersSent(ApiTestData.ApiKeyHeader, ApiTestData.ApiKeyValueRequestService);
    }

    [Test]
    public async Task FetchDataAsync_SuccessfulResponse_ReturnsContent()
    {
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.RequestServiceTestResponse);

        var result = await _requestService.FetchDataAsync(ApiTestData.RequestServiceTestUrl);

        Assert.That(result, Is.EqualTo(ApiTestData.RequestServiceTestResponse));
    }

    [Test]
    public async Task FetchDataAsync_NetworkIssue_ThrowsException()
    {
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == ApiTestData.RequestServiceTestUrl),
                ItExpr.IsAny<CancellationToken>()
            )
            .ThrowsAsync(new HttpRequestException("Net. error"));

        var exception = Assert.ThrowsAsync<HttpRequestException>(async () =>
            await _requestService.FetchDataAsync(ApiTestData.RequestServiceTestUrl));

        StringAssert.Contains("Net. error", exception.Message);
    }

    [Test]
    public void FetchData_CatFacts_SendsCorrectRequest()
    {
        var catFactsUrl = ApiTestData.GetCatFactsUrl();
        var expectedResponse = ApiTestData.CatFactsResponse;

        SetupMockResponse(HttpStatusCode.OK, expectedResponse, null, catFactsUrl);

        var result = _requestService.FetchData(catFactsUrl);


        Assert.That(result, Is.EqualTo(expectedResponse));

        VerifyRequestSent(catFactsUrl, times: Times.Once());
    }

    [Test]
    public async Task FetchDataAsync_CatFacts_SendsCorrectRequest()
    {
        var catFactsUrl = ApiTestData.GetCatFactsUrl();
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.CatFactsResponse,
            null, catFactsUrl);

        var result = await _requestService.FetchDataAsync(catFactsUrl);

        Assert.That(result, Is.EqualTo(ApiTestData.CatFactsResponse));

        VerifyRequestSent(catFactsUrl, times: Times.Once());
    }

    /// <summary>
    /// Verifies that the request was sent to the specified URL the expected number of times
    /// </summary>
    private void VerifyRequestSent(string url, Times times)
    {
        _mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            times,
            ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == url),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    /// <summary>
    /// Verifies that the request was sent with the correct headers and values
    /// </summary
    private void VerifyHeadersSent(string headerName, string headerValue)
    {
        _mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Headers.Contains(headerName) &&
                req.Headers.GetValues(headerName).Contains(headerValue)),
            ItExpr.IsAny<CancellationToken>()
        );
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
}