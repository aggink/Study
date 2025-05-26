using Moq;
using Moq.Protected;
using Study.Lab2.Logic.love100rubb;
using Study.Lab2.Logic.love100rubb.DtoModel;
using System.Net;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.love100rubb;

[TestFixture]
public class RequestServiceTests
{
    private const string REQUEST_URL = "https://petstore.swagger.io/v2/user/love100rubb";

    private RequestService _requestService;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;

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
    public void FetchData_Success_ReturnsJsonResponse()
    {
        // Подготовка DTO пользователя (пример)
        var userDto = new PetStoreUsersInfoResponseDto.Root
        {
            Id = 1,
            Username = "love100rubb",
            FirstName = "Daniil",
            LastName = "Buntin",
            Email = "love100rubb@gmail.com",
            Password = "12345",
            Phone = "893123213213",
            UserStatus = 1
        };

        var json = JsonSerializer.Serialize(userDto);
        SetupHttpResponse(REQUEST_URL, json, HttpStatusCode.OK);

        var result = _requestService.FetchData(REQUEST_URL);

        Assert.That(result, Is.EqualTo(json));
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsJsonResponse()
    {
        var userDto = new PetStoreUsersInfoResponseDto.Root
        {
            Id = 2,
            Username = "doter",
            FirstName = "Leha",
            LastName = "Abobkin",
            Email = "doter@gmail.com",
            Password = "89012",
            Phone = "8976867856743",
            UserStatus = 1
        };

        var json = JsonSerializer.Serialize(userDto);
        SetupHttpResponse(REQUEST_URL, json, HttpStatusCode.OK);

        var result = await _requestService.FetchDataAsync(REQUEST_URL, CancellationToken.None);

        Assert.That(result, Is.EqualTo(json));
    }

    [Test]
    public void FetchData_Failure_ThrowsException()
    {
        SetupHttpResponse(REQUEST_URL, "Mistake", HttpStatusCode.NotFound);

        var ex = Assert.Throws<Exception>(() => _requestService.FetchData(REQUEST_URL));

        StringAssert.Contains("Mistake", ex.Message);
    }

    [Test]
    public void FetchDataAsync_Failure_ThrowsException()
    {
        SetupHttpResponse(REQUEST_URL, "Mistake", HttpStatusCode.NotFound);

        var ex = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(REQUEST_URL, CancellationToken.None));

        StringAssert.Contains("Mistake", ex.Message);
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

