using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.danaky1;
using Study.Lab2.Logic.danaky1.DtoModels;

namespace Study.Lab2.Logic.UnitTests.danaky1;

[TestFixture]
public class RequestServiceTests
{
    private RequestService _requestService;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly string _requestUrl = "https://example.com/api/test";

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
        var data = new RussiaFactResponseDto
        {
            Fact = "Россия - самая большая страна в мире по площади."
        };
        var json = JsonSerializer.Serialize(data);

        // Настройка мок-ответа
        SetupHttpResponse(_requestUrl, json, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(_requestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(json));
    }

    [Test]
    public void FetchDataAsync_Failure_ThrowsException()
    {
        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(_requestUrl, "Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => await
            _requestService.FetchDataAsync(_requestUrl, CancellationToken.None));

        StringAssert.Contains("Ошибка: NotFound", exception.Message);
    }

    private void SetupHttpResponse(string url, string content, HttpStatusCode statusCode)
    {
        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == url),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });
    }

    [TearDown]
    public void Dispose()
    {
        _requestService?.Dispose();
    }
}