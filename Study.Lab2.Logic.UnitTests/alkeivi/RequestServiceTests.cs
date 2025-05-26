using Moq;
using Moq.Protected;
using Study.Lab2.Logic.alkeivi;
using System.Net;

namespace Study.Lab2.Logic.UnitTests.alkeivi;

[TestFixture]
public class RequestServiceTests : IDisposable
{
    private const string SuccessResponse = "{\"message\": \"Success\"}";
    private const string ErrorResponse = "Not Found";
    private const string SuccessUrl = "https://example.com/api/test";
    private const string ErrorUrl = "https://example.com/api/fail";

    private readonly RequestService _requestService;
    private readonly Mock<HttpMessageHandler> _handlerMock;

    public RequestServiceTests()
    {
        _handlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_handlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [Test]
    public void FetchData_WhenSuccessful_ReturnsExpectedContent()
    {
        SetupMockResponse(SuccessUrl, SuccessResponse, HttpStatusCode.OK);

        var result = _requestService.FetchData(SuccessUrl);

        Assert.That(result, Is.EqualTo(SuccessResponse));
    }

    [Test]
    public async Task FetchDataAsync_WhenSuccessful_ReturnsExpectedContent()
    {
        using var cts = new CancellationTokenSource();

        SetupMockResponse(SuccessUrl, SuccessResponse, HttpStatusCode.OK);

        var result = await _requestService.FetchDataAsync(SuccessUrl, cts.Token);

        Assert.That(result, Is.EqualTo(SuccessResponse));
    }

    [Test]
    public void FetchData_WhenFails_ThrowsWithStatusCode()
    {
        SetupMockResponse(ErrorUrl, ErrorResponse, HttpStatusCode.NotFound);

        var ex = Assert.Throws<Exception>(() => _requestService.FetchData(ErrorUrl));
        Assert.That(ex.Message, Does.Contain("Ошибка: NotFound"));
    }

    [Test]
    public void FetchDataAsync_WhenFails_ThrowsWithStatusCode()
    {
        using var cts = new CancellationTokenSource();

        SetupMockResponse(ErrorUrl, ErrorResponse, HttpStatusCode.NotFound);

        var ex = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(ErrorUrl, cts.Token));
        Assert.That(ex.Message, Does.Contain("Ошибка: NotFound"));
    }

    private void SetupMockResponse(string url, string content, HttpStatusCode statusCode)
    {
        _handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri.ToString() == url),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });
    }

    public void Dispose()
    {
        _requestService?.Dispose();
        _handlerMock.Reset();
    }
}