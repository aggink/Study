using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.poigko;
using Study.Lab2.Logic.poigko.DtoModel;

namespace Study.Lab2.Logic.UnitTests.poigko;

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

    /// <summary>
    /// Тест для синхронного метода FetchData. Проверяет, что метод возвращает правильный ответ при успешном запросе.
    /// </summary>
    [Test]
    public void FetchData_Success_ReturnsResponse()
    {
        // Arrange
        var data = new CatFactResponseDto
        {
            Data = new List<string>
            {
                "The way you treat kittens in the early stages of it's life will render it's personality traits later in life."
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

    /// <summary>
    /// Тест для асинхронного метода FetchDataAsync. Проверяет, что метод выбрасывает исключение при неуспешном запросе (404 Not Found).
    /// </summary>
    [Test]
    public void FetchDataAsync_Failure_ThrowsException()
    {
        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(_requestUrl, "Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => await _requestService.FetchDataAsync(_requestUrl, CancellationToken.None));
        StringAssert.Contains("Ошибка: NotFound", exception.Message);
    }

    /// <summary>
    /// Настройка мок-ответа для HTTP-запроса.
    /// </summary>
    /// <param name="url">URL запроса</param>
    /// <param name="content">Тело ответа</param>
    /// <param name="statusCode">Код ответа HTTP</param>
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

    /// <summary>
    /// Освобождение ресурсов, реализует IDisposable.
    /// </summary>
    [TearDown]
    public void Dispose()
    {
        _requestService?.Dispose();
    }
}
