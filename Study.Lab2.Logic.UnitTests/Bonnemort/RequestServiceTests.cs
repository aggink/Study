using Moq;
using Moq.Protected;
using Study.Lab2.Logic.Bonnemort;
using Study.Lab2.Logic.UnitTests.Bonnemort.DtoModels;
using System.Net;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.Bonnemort;

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
    public void FetchData_Success_ReturnsMoonPhaseResponse()
    {
        var moonPhase = new MoonPhaseDto
        {
            Error = 0,
            ErrorMsg = "success",
            TargetDate = "1107292800",
            Moon = new List<string> { "Snow Moon" },
            Index = 21,
            Age = 21.73,
            Phase = "Waning Gibbous",
            Distance = 376999.11,
            Illumination = 0.54,
            AngularDiameter = 0.528,
            DistanceToSun = 147434008.05,
            SunAngularDiameter = 0.540
        };
        var expectedResponse = JsonSerializer.Serialize(new List<MoonPhaseDto> { moonPhase });
        var requestUrl = "https://api.farmsense.net/v1/moonphases/?d=1107292800";

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        var result = _requestService.FetchData(requestUrl);
        var moonPhases = JsonSerializer.Deserialize<List<MoonPhaseDto>>(result);

        Assert.That(moonPhases[0].Phase, Is.EqualTo(moonPhase.Phase));
    }


    [Test]
    public void FetchData_Failure_ThrowsException()
    {
        var requestUrl = "https://ohmanda.com/api/horoscope/unknownsign/";
        SetupHttpResponse(requestUrl, "404 - Not Found", HttpStatusCode.NotFound);

        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
        StringAssert.Contains("404 - Not Found", exception.Message);
    }

    [Test]
    public void FetchDataAsync_Failure_ThrowsException()
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        var requestUrl = "https://ohmanda.com/api/horoscope/unknownsign/";

        SetupHttpResponse(requestUrl, "404 - Not Found", HttpStatusCode.NotFound);

        var exception = Assert.ThrowsAsync<Exception>(async () => await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("404 - Not Found", exception.Message);
    }

    [Test]
    public void FetchData_BadRequest_ThrowsException()
    {
        var requestUrl = "https://ohmanda.com/api/horoscope/aries/";

        SetupHttpResponse(requestUrl, "400 - Bad Request", HttpStatusCode.BadRequest);

        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
        StringAssert.Contains("400 - Bad Request", exception.Message);
    }

    [Test]
    public void FetchDataAsync_BadRequest_ThrowsException()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        var requestUrl = "https://ohmanda.com/api/horoscope/aries/";

        SetupHttpResponse(requestUrl, "400 - Bad Request", HttpStatusCode.BadRequest);

        var exception = Assert.ThrowsAsync<Exception>(async () => await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("400 - Bad Request", exception.Message);
    }

    [TearDown]
    public void Dispose()
    {
        _requestService?.Dispose();
    }
    [Test]
    public void FetchData_Success_ReturnsNasaApodResponse()
    {
        var apodResponse = new NasaApodDto
        {
            date = "2024-06-09",
            explanation = "A beautiful image of space...",
            url = "https://apod.nasa.gov/apod/image/example.jpg",
            title = "Astronomy Picture of the Day",
            media_type = "image"
        };
        var expectedResponse = JsonSerializer.Serialize(apodResponse);
        var requestUrl = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        var result = _requestService.FetchData(requestUrl);

        // Десериализуй оба (ожидаемый и фактический) и сравнивай их поля
        var expectedApod = JsonSerializer.Deserialize<NasaApodDto>(expectedResponse);
        var actualApod = JsonSerializer.Deserialize<NasaApodDto>(result);

        Assert.That(actualApod.date, Is.EqualTo(expectedApod.date));
        Assert.That(actualApod.explanation, Is.EqualTo(expectedApod.explanation));
        Assert.That(actualApod.url, Is.EqualTo(expectedApod.url));
        Assert.That(actualApod.title, Is.EqualTo(expectedApod.title));
        Assert.That(actualApod.media_type, Is.EqualTo(expectedApod.media_type));
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
