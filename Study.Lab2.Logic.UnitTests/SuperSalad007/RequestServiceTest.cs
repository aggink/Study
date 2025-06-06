using Moq.Protected;
using Moq;
using Study.Lab2.Logic.UnitTests.SuperSalad007.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Study.Lab2.Logic.SuperSalad007;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.SuperSalad007;

[TestFixture]
public class RequestServiceTests : IDisposable
{
    private const string SuccessUrl = "https://example.com/api/test";
    private const string ErrorUrl = "https://example.com/api/fail";

    private readonly RequestService _requestService;
    private readonly Mock<HttpMessageHandler> _handlerMock;

    public RequestServiceTests()
    {
        _handlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_handlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [Test]
    public void FetchData_WhenSuccessful_ReturnsExpectedContent()
    {
        var expectedResponse = new ResponseDto { Message = "Success" };
        var jsonResponse = JsonSerializer.Serialize(expectedResponse);
        SetupMockResponse(SuccessUrl, jsonResponse, HttpStatusCode.OK);

        var result = _requestService.FetchData(SuccessUrl);

        var resultDto = JsonSerializer.Deserialize<ResponseDto>(result);
        Assert.That(resultDto?.Message, Is.EqualTo(expectedResponse.Message));
    }

    [Test]
    public async Task FetchDataAsync_WhenSuccessful_ReturnsExpectedContent()
    {
        using var cts = new CancellationTokenSource();

        var expectedResponse = new ResponseDto { Message = "Success" };
        var jsonResponse = JsonSerializer.Serialize(expectedResponse);
        SetupMockResponse(SuccessUrl, jsonResponse, HttpStatusCode.OK);

        var result = await _requestService.FetchDataAsync(SuccessUrl, cts.Token);

        var resultDto = JsonSerializer.Deserialize<ResponseDto>(result);
        Assert.That(resultDto?.Message, Is.EqualTo(expectedResponse.Message));
    }

    [Test]
    public void FetchData_WhenFails_ThrowsWithStatusCode()
    {
        var errorResponse = new ErrorResponseDto
        {
            Message = "Not Found",
            StatusCode = (int)HttpStatusCode.NotFound
        };
        var jsonResponse = JsonSerializer.Serialize(errorResponse);
        SetupMockResponse(ErrorUrl, jsonResponse, HttpStatusCode.NotFound);

        var ex = Assert.Throws<Exception>(() => _requestService.FetchData(ErrorUrl));
        Assert.That(ex.Message, Does.Contain("Ошибка: NotFound"));
    }

    [Test]
    public void FetchDataAsync_WhenFails_ThrowsWithStatusCode()
    {
        using var cts = new CancellationTokenSource();

        var errorResponse = new ErrorResponseDto
        {
            Message = "Not Found",
            StatusCode = (int)HttpStatusCode.NotFound
        };
        var jsonResponse = JsonSerializer.Serialize(errorResponse);
        SetupMockResponse(ErrorUrl, jsonResponse, HttpStatusCode.NotFound);

        var ex = Assert.ThrowsAsync<Exception>(async () =>
            await _requestService.FetchDataAsync(ErrorUrl, cts.Token));
        Assert.That(ex.Message, Does.Contain("Ошибка: NotFound"));
    }

    private void SetupMockResponse(string url, string content, HttpStatusCode statusCode)
    {
        _handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri.ToString() == url),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });
    }

    public void Dispose()
    {
        _requestService?.Dispose();
        _handlerMock.Reset();
    }
}
