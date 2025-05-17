using Moq;
using Moq.Protected;
using Study.Lab2.Logic.brnvika;
using Study.Lab2.Logic.UnitTests.brnvika.DtoModels;
using System.Net;
using System.Text.Json;

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
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=test&q=Москва";

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
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=test&q=Москва";

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
        var requestUrl = "https://api.nasa.gov/planetary/apod?api_key=test=22-05-2005";

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
        var requestUrl = "https://api.nasa.gov/planetary/apod?api_key=test=22-05-2005";

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
        result = result.Replace(System.Environment.NewLine, string.Empty);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void FetchData_Failure_ThrowsException()
    {
        // Arrange
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=test&q=Stankin";

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
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=test&q=Stankin";

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
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=test&q=Stankin";

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
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=test&q=Stankin";

        // Настройка мок-ответа с кодом ошибки
        SetupHttpResponse(requestUrl, "400 - Bad Request", HttpStatusCode.BadRequest);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("400 - Bad Request", exception.Message);
    }

    [Test]
    public void FetchData_Test_SecondResponse()
    {
        var requestUrl = "https://api.nasa.gov/planetary/apod?api_key=test=2005-05-22";
        var secondResponse = new SecondRequestDto
        {
            Copyright = "\nJohn Gleason \n(Celestial Images)\n",
            Date = "2005-05-22",
            Explanation = "Tomorrow's picture: wavemaker around saturn  < | Archive | Index | Search | Calendar | Glossary | Education | About APOD | >  Authors & editors: Robert Nemiroff (MTU) & Jerry Bonnell (USRA) NASA Web Site Statements, Warnings, and Disclaimers NASA Official: Jay Norris. Specific rights apply. A service of: EUD at NASA / GSFC & Michigan Tech. U.",
            Hdurl = "https://apod.nasa.gov/apod/image/0012/halebopp_gleason_big.jpg",
            MediaType = "image",
            ServiceVersion = "v1",
            Title = "The Dust and Ion Tails of Comet Hale-Bopp",
            Url = "https://apod.nasa.gov/apod/image/0012/halebopp_gleason.jpg"
        };

        SetupHttpResponse<SecondRequestDto>(requestUrl, secondResponse, HttpStatusCode.OK);

        string result = _requestService.FetchData(requestUrl);
        var res = JsonSerializer.Deserialize<SecondRequestDto>(result);

        Assert.That(res.Copyright, Is.EqualTo(secondResponse.Copyright));
    }

    [Test]
    public void FetchData_Test_ThirdResponse()
    {
        var requestUrl = "http://universities.hipolabs.com/search?country=Russian Federation&name=Lomonosov Moscow State University";
        var thirdResponse = new ThirdRequestDto
        {
            Name = "Lomonosov Moscow State University",
            StateProvince = null,
            Country = "Russian Federation",
            AlphaTwoCode = "RU",
            WebPages = new List<string>() { "https://www.msu.ru/" },
            Domains = new List<string>() { "msu.ru" }
        };

        SetupHttpResponse<ThirdRequestDto>(requestUrl, thirdResponse, HttpStatusCode.OK);

        string result = _requestService.FetchData(requestUrl);
        var res = JsonSerializer.Deserialize<ThirdRequestDto>(result);

        Assert.That(res.Name, Is.EqualTo(thirdResponse.Name));
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

    private void SetupHttpResponse<T>(string url, T content, HttpStatusCode statusCode)
        where T : class
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
                Content = new StringContent(JsonSerializer.Serialize(content))
            });
    }
}