using Moq;
using Moq.Protected;
using NUnit.Framework;
using Study.Lab2.Logic.Selestz;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.UnitTests.Selestz;

[TestFixture]
public class RequestServiceTests
{
    private Mock<HttpMessageHandler> _handlerMock;
    private HttpClient _httpClient;
    private RequestService _requestService;

    [SetUp]
    public void Setup()
    {
        _handlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_handlerMock.Object);
        _requestService = new RequestService(_httpClient);
    }

    [Test]
    public async Task FetchDataAsync_SuccessResponse_ReturnsContent()
    {
        // Arrange
        var expectedContent = "{\"name\":\"John\"}";

        _handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedContent)
            });

        // Act
        var result = await _requestService.FetchDataAsync("http://test.com");

        // Assert
        Assert.AreEqual(expectedContent, result);
    }

    [Test]
    public void FetchDataAsync_ErrorResponse_ThrowsException()
    {
        // Arrange
        _handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            });

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(() => _requestService.FetchDataAsync("http://test.com"));
        Assert.That(ex.Message, Does.Contain("HTTP Error"));
    }

    [TearDown]
    public void Cleanup()
    {
        _requestService.Dispose();
        _httpClient.Dispose();
    }
}