using System.Net;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.neijrr;

namespace Study.Lab2.Logic.UnitTests.neijrr;

[TestFixture]
public class RequestServiceTests
{
    private Mock<HttpMessageHandler> _httpMessageHandler;
    private RequestService _requestService;

    [SetUp]
    public void Setup()
    {
        _httpMessageHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandler.Object);
        _requestService = new RequestService(httpClient);
    }

    [TearDown]
    public void TearDown()
    {
        _requestService?.Dispose();
    }

    [Test]
    public void FetchDataSuccess()
    {
        // Условие
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.RequestService_TestResponse);

        // Действие
        var result = _requestService.FetchData(ApiTestData.RequestService_TestUrl);

        // Проверка
        Assert.That(result, Is.EqualTo(ApiTestData.RequestService_TestResponse), "FetchData возвращает неправильный результат");
    }

    [Test]
    public async Task FetchDataAsyncSuccess()
    {
        // Условие
        SetupMockResponse(HttpStatusCode.OK, ApiTestData.RequestService_TestResponse);

        // Действие
        var result = await _requestService.FetchDataAsync(ApiTestData.RequestService_TestUrl);

        // Проверка
        Assert.That(result, Is.EqualTo(ApiTestData.RequestService_TestResponse), "FetchDataAsync возвращает неправильный результат");
    }

    [Test]
    public void FetchDataError()
    {
        // Условие
        SetupMockResponse(HttpStatusCode.InternalServerError, "Error");

        // Действие / Проверка
        var exception = Assert.Throws<Exception>(
            () => _requestService.FetchData(ApiTestData.RequestService_TestUrl),
            "Функция FetchData не выдала ошибку"
        );

        Assert.Multiple(() =>
        {
            Assert.That(exception.Message, Does.Contain("Ошибка HTTP"), "Не указан тип ошибки");
            Assert.That(exception.Message, Does.Match("\\d{3}"), "Нет кода ошибки HTTP");
            Assert.That(exception.Message, Does.Contain("Internal Server Error"), "Нет сообщения об ошибке");
        });
    }

    [Test]
    public void FetchDataAsyncError()
    {
        // Условие
        SetupMockResponse(HttpStatusCode.InternalServerError, "Error");

        // Действие / Проверка
        var exception = Assert.ThrowsAsync<Exception>(
            async () => { await _requestService.FetchDataAsync(ApiTestData.RequestService_TestUrl); },
            "Функция FetchData не выдала ошибку"
        );

        Assert.Multiple(() =>
        {
            Assert.That(exception.Message, Does.Contain("Ошибка HTTP"), "Не указан тип ошибки");
            Assert.That(exception.Message, Does.Match("\\d{3}"), "Нет кода ошибки HTTP");
            Assert.That(exception.Message, Does.Contain("Internal Server Error"), "Нет сообщения об ошибке");
        });
    }

    private void SetupMockResponse(
        HttpStatusCode statusCode,
        string content,
        Dictionary<string, string> expectedHeaders = null)
    {
        _httpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString() == ApiTestData.RequestService_TestUrl &&
                    (expectedHeaders == null || CheckHeaders(req, expectedHeaders))),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });
    }

    private static bool CheckHeaders(HttpRequestMessage request, Dictionary<string, string> expectedHeaders)
    {
        foreach (var header in expectedHeaders)
            if (!request.Headers.Contains(header.Key) ||
                !request.Headers.GetValues(header.Key).Contains(header.Value))
                return false;

        return true;
    }
}
