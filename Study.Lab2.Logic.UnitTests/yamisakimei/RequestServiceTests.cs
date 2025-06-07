using System.Net;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using Study.Lab2.Logic.yamisakimei;

namespace Study.Lab2.Logic.UnitTests.yamisakimei;

[TestFixture]
public class RequestServiceTests : IDisposable
{
    private RequestService _requestService = null!;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock = null!;

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [Test]
    public void FetchData_Success_ReturnsResponse()
    {
        // Arrange
        var expectedResponse = "{\"results\":[]}";
        SetupHttpResponse("/test", expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData("/test");

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void FetchDataAsync_Failure_ThrowsException()
    {
        // Arrange
        SetupHttpResponse("/test", "Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(() =>
            _requestService.FetchDataAsync("/test", CancellationToken.None));
    }

    private void SetupHttpResponse(string url, string content, HttpStatusCode statusCode)
    {
        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri!.ToString().Contains(url)),
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
    }
}