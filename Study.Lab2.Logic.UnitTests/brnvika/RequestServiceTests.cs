using Moq;
using Moq.Protected;
using Study.Lab2.Logic.brnvika;
using System.Net;

namespace Study.Lab2.Logic.UnitTests.brnvika;

[TestFixture]
public class RequestServiceTests
{
    private RequestService _requestService;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [Test]
    public void FetchData_Success_ReturnsFirstResponse()
    {
        // Arrange
        var expectedResponse = "{  \"message\": \"Success\"}";
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=88770810754346f699491514250305&q=Москва";

        // Настройка мок-ответа
        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl).Replace(System.Environment.NewLine, "");

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsFirstResponse()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        // Arrange
        var expectedResponse = "{  \"message\": \"Success\"}";
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=88770810754346f699491514250305&q=Москва";

        // Настройка мок-ответа
        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);
        result = result.Replace(System.Environment.NewLine, "");

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void FetchData_Success_ReturnsSecondResponse()
    {
        // Arrange
        var expectedResponse = "{  \"message\": \"Success\"}";
        var requestUrl = "https://api.nasa.gov/planetary/apod?api_key=mIqheAgtIaufWvsTJuGyPbb27O3oCCRtFDikN3eH&date=22-05-2005";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl).Replace(System.Environment.NewLine, "");

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsSecondResponse()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        // Arrange
        var expectedResponse = "{  \"message\": \"Success\"}";
        var requestUrl = "https://api.nasa.gov/planetary/apod?api_key=mIqheAgtIaufWvsTJuGyPbb27O3oCCRtFDikN3eH&date=22-05-2005";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);
        result = result.Replace(System.Environment.NewLine, "");

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void FetchData_Success_ReturnsThirdResponse()
    {
        // Arrange
        var expectedResponse = "{  \"message\": \"Success\"}";
        var requestUrl = "http://universities.hipolabs.com/search?country=Russian Federation&name=Lomonosov Moscow State University";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl).Replace(System.Environment.NewLine, "");

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsThirdResponse()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        // Arrange
        var expectedResponse = "{  \"message\": \"Success\"}";
        var requestUrl = "http://universities.hipolabs.com/search?country=Russian Federation&name=Lomonosov Moscow State University";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);
        result = result.Replace(System.Environment.NewLine, "");

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void FetchData_Failure_ThrowsException()
    {
        // Arrange
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=88770810754346f699491514250305&q=Stankin";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, "404 - Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
        StringAssert.Contains("404 - Not Found", exception.Message);
    }

    [Test]
    public void FetchDataAsync_Failure_ThrowsException()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        // Arrange
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=88770810754346f699491514250305&q=Stankin";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, "404 - Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("404 - Not Found", exception.Message);
    }

    [Test]
    public void FetchData_BadRequest_ThrowsException()
    {
        // Arrange
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=88770810754346f699491514250305&q=Stankin";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, "400 - Bad Request", HttpStatusCode.BadRequest);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
        StringAssert.Contains("400 - Bad Request", exception.Message);
    }

    [Test]
    public void FetchDataAsync_BadRequest_ThrowsException()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        // Arrange
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=88770810754346f699491514250305&q=Stankin";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, "400 - Bad Request", HttpStatusCode.BadRequest);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("400 - Bad Request", exception.Message);
    }

    [TearDown]
    public void Dispose()
    {
        _requestService?.Dispose();
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
}