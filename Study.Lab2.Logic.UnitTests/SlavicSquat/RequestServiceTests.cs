using Moq;
using Moq.Protected;
using Study.Lab2.Logic.SlavicSquat;
using System.Net;

namespace Study.Lab2.Logic.UnitTests.SlavicSquat;

[TestFixture]
public class RequestServiceTests
{
    private const string TEST_URL = "http://test";

    [Test]
    public void FetchData_ReturnsJsonString_OnSuccess()
    {
        // Arrange: подготовим хэндлер, возвращающий код 200 и простой JSON
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"foo\":123}"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);
        using var svc = new RequestService(httpClient);

        // Act
        var result = svc.FetchData(TEST_URL);

        // Assert
        Assert.That(result, Is.EqualTo("{\"foo\":123}"));
    }

    [Test]
    public void FetchData_ThrowsException_OnNonSuccess()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Fail",
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);
        using var svc = new RequestService(httpClient);

        Assert.Throws<Exception>(() => svc.FetchData(TEST_URL));
    }

    [Test]
    public async Task FetchDataAsync_ReturnsJsonString_OnSuccessAsync()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"bar\":456}"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);
        using var svc = new RequestService(httpClient);

        var result = await svc.FetchDataAsync(TEST_URL);
        Assert.That(result, Is.EqualTo("{\"bar\":456}"));
    }

    [Test]
    public void FetchDataAsync_ThrowsException_OnNonSuccessAsync()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Bad",
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);
        using var svc = new RequestService(httpClient);

        Assert.ThrowsAsync<Exception>(async () => await svc.FetchDataAsync(TEST_URL));
    }
}
