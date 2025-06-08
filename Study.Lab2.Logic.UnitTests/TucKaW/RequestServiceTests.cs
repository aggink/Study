using Moq;
using Moq.Protected;
using Study.Lab2.Logic.TucKaW;
using Study.Lab2.Logic.TucKaW.DtoModels;
using System.Net;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.TucKaW;

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
        var data = new BarcaFactResponseDto
        {
            Data = new List<string>
            {
<<<<<<< HEAD
                "ФК Барселона выиграла свой первый титул чемпиона Испании в сезоне 1928-29."
=======
                "ФК Барселона выиграла свой первый титул чемпиона Испании в сезоне 1928-1929."
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
            }
        };
        var json = JsonSerializer.Serialize(data);

        // Настройка мок-ответа
        SetupHttpResponse(_requestUrl, json, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(_requestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(json));
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