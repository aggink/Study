using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq.Protected;
using Moq;
using Study.Lab2.Logic.Taipano;
using Study.Lab2.Logic.Taipano.DtoModels;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.Taipano;

    public class RequestServiceTests
    {
    private const string REQUEST_URL = "https://dummyjson.com/products/1";

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
    public void FetchData_Success_ReturnsResponse()
    {
        var data = new PoductFactResponseDto
        {
            Id = 1,
            Title = "Essence Mascara Lash Princess",
            Category ="beauty",
            Price = 9.99
        };

        var json = JsonSerializer.Serialize(data);
        SetupHttpResponse(REQUEST_URL, json, HttpStatusCode.OK);

        var result = _requestService.FetchData(REQUEST_URL);

        Assert.That(result, Is.EqualTo(json));
    }

    [Test]
    public void FetchDataAsync_Failure_ThrowsException()
    {
        SetupHttpResponse(REQUEST_URL, "Not Found", HttpStatusCode.NotFound);

        var exception = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(REQUEST_URL, CancellationToken.None));

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
}

