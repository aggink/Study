using Moq.Protected;
using Moq;
using Study.Lab2.Logic.Maxtir23.DtoModels;
using Study.Lab2.Logic.Maxtir23;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.Maxtir23;

[TestFixture]
public class UnitTests
{
    private const string REQUEST_URL = "https://petstore.swagger.io/v2/user/Andrew23";

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
        var userDto = new RecipeDTO.Root
        {
            Id = 1,
            Username = "Valera23",
            FirstName = "Valera",
            LastName = "Bull",
            Email = "wasd23@gmail.com",
            Password = "Valera23",
            Phone = "89239232323",
            UserStatus = 0
        };

        var json = JsonSerializer.Serialize(userDto);
        SetupHttpResponse(REQUEST_URL, json, HttpStatusCode.OK);

        var result = _requestService.FetchData(REQUEST_URL);

        Assert.That(result, Is.EqualTo(json));
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsJsonResponse()
    {
        var userDto = new RecipeDTO.Root
        {
            Id = 2,
            Username = "Andrew23",
            FirstName = "Andrew",
            LastName = "Shelly",
            Email = "Andrew23@gmail.com",
            Password = "Andrew23",
            Phone = "89999323232",
            UserStatus = 0
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
