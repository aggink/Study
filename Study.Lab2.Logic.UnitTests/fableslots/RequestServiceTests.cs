using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.fableslots;
using Study.Lab2.Logic.fableslots.DtoModels;

namespace Study.Lab2.Logic.UnitTests.fableslots;

[TestFixture]
public class RequestServiceTests
{
    private RequestService _requestService;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [TearDown]
    public void Dispose()
    {
        _requestService?.Dispose();
    }

    [Test]
    public void FetchData_Success_ReturnsPostResponse()
    {
        // Arrange
        var postDto = new WeatherData
        {
           Location = new Location
           {
               Name = "Moscow",
               Country = "Russia",
               Lat = 55.7522,
               Lon = 37.6156,
               
           }
        };
        var expectedResponse = JsonSerializer.Serialize(postDto, _jsonOptions);
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Moscow";

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
       
    }

    [Test]
    public void FetchData_Success_ReturnsUserResponse()
    {
        // Arrange
        var postDto = new WeatherData
        {
            Location = new Location
            {
                Name = "Minsk",
                Country = "Belarus",
                Lat = 53.9,
                Lon = 27.5667,

            }
        };
        var expectedResponse = JsonSerializer.Serialize(postDto, _jsonOptions);
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Minsk";

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
     
    }

    [Test]
    public void FetchData_Success_ReturnsCommentResponse()
    {
        // Arrange
        var postDto = new WeatherData
        {
            Location = new Location
            {
                Name = "Manchester",
                Country = "United Kingdom",
                Lat = 53.483,
                Lon = -2.2501,

            }
        };
        var expectedResponse = JsonSerializer.Serialize(postDto, _jsonOptions);
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Manchester";

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
        
    }

    [Test]
    public void FetchData_NotFound_ThrowsException()
    {
        // Arrange
        var requestUrl = "https://jsonplaceholder.typicode.com/posts/999999";
        SetupHttpResponse(requestUrl, "Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
        StringAssert.Contains("NotFound", exception.Message);
    }

    [Test]
    public void FetchData_BadRequest_ThrowsException()
    {
        // Arrange
        var requestUrl = "https://jsonplaceholder.typicode.com/invalid";
        SetupHttpResponse(requestUrl, "Bad Request", HttpStatusCode.BadRequest);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
        StringAssert.Contains("BadRequest", exception.Message);
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsPostResponse()
    {
        // Arrange
        var postDto = new WeatherData
        {
            Location = new Location
            {
                Name = "Moscow",
                Country = "Russia",
                Lat = 55.7522,
                Lon = 37.6156,

            }
        };
        var expectedResponse = JsonSerializer.Serialize(postDto, _jsonOptions);
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Moscow";
        using var cancellationTokenSource = new CancellationTokenSource();

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
  
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsUserResponse()
    {
        // Arrange
        var postDto = new WeatherData
        {
            Location = new Location
            {
                Name = "Minsk",
                Country = "Belarus",
                Lat = 53.9,
                Lon = 27.5667,

            }
        };
        var expectedResponse = JsonSerializer.Serialize(postDto, _jsonOptions);
        var requestUrl = "http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Minsk";
        using var cancellationTokenSource = new CancellationTokenSource();

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
     
    }

    [Test]
    public void FetchDataAsync_NotFound_ThrowsException()
    {
        // Arrange
        var requestUrl = "https://jsonplaceholder.typicode.com/posts/999999";
        using var cancellationTokenSource = new CancellationTokenSource();
        SetupHttpResponse(requestUrl, "Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("NotFound", exception.Message);
    }

    [Test]
    public void FetchDataAsync_BadRequest_ThrowsException()
    {
        // Arrange
        var requestUrl = "https://jsonplaceholder.typicode.com/invalid";
        using var cancellationTokenSource = new CancellationTokenSource();
        SetupHttpResponse(requestUrl, "Bad Request", HttpStatusCode.BadRequest);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("BadRequest", exception.Message);
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
}