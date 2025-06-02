using Moq;
using Moq.Protected;
using Study.Lab2.Logic.freaxd;
using Study.Lab2.Logic.Interfaces.freaxd;
using System.Net;

namespace Study.Lab2.Logic.UnitTests.freaxd;

[TestFixture]
public class RequestServiceTests
{
    private IRequestService _requestService;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly string _requestUrl = "http://test.url";

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [TearDown]
    public void TearDown()
    {
        _requestService?.Dispose();
    }

    [Test]
    public void FetchData_ValidRequest_ReturnsJsonString()
    {
        var expectedJson = "{\"key\":\"value\"}";
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(expectedJson)
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var result = _requestService.FetchData(_requestUrl);

        Assert.That(result, Is.EqualTo(expectedJson));
    }

    [Test]
    public void FetchData_HttpError_ThrowsException()
    {
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.NotFound,
            ReasonPhrase = "Not Found"
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        Assert.Throws<Exception>(() => _requestService.FetchData(_requestUrl));
    }

    [Test]
    public async Task FetchDataAsync_ValidRequest_ReturnsJsonString()
    {
        var expectedJson = "{\"key\":\"value\"}";
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(expectedJson)
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var result = await _requestService.FetchDataAsync(_requestUrl);

        Assert.That(result, Is.EqualTo(expectedJson));
    }

    [Test]
    public async Task FetchDataAsync_HttpError_ThrowsException()
    {
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.BadRequest,
            ReasonPhrase = "Bad Request"
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        Assert.ThrowsAsync<Exception>(async () => await _requestService.FetchDataAsync(_requestUrl));
    }
}
