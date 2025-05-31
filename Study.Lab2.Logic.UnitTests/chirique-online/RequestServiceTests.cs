using Moq;
using Moq.Protected;
using Study.Lab2.Logic.chirique_online;
using Study.Lab2.Logic.UnitTests.chirique_online.DtoModels;
using System.Net;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.chirique_online;

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

    [TearDown]
    public void Dispose()
    {
        _requestService?.Dispose();
    }

    [Test]
    public void FetchData_ReturnsResponse_WhenSuccess()
    {
        var url = "https://example.com/api/test";
        var expectedResponse = new ResponseDto { Message = "Success" };
        var expectedJson = JsonSerializer.Serialize(expectedResponse);

        SetupHttpResponse(url, expectedJson, HttpStatusCode.OK);

        var resultJson = _requestService.FetchData(url);
        var result = JsonSerializer.Deserialize<ResponseDto>(resultJson);

        Assert.That(result?.Message, Is.EqualTo(expectedResponse.Message));
    }

    [Test]
    public async Task FetchDataAsync_ReturnsResponse_WhenSuccess()
    {
        var url = "https://example.com/api/test";
        var expectedResponse = new ResponseDto { Message = "Success" };
        var expectedJson = JsonSerializer.Serialize(expectedResponse);

        SetupHttpResponse(url, expectedJson, HttpStatusCode.OK);

        var resultJson = await _requestService.FetchDataAsync(url, default);
        var result = JsonSerializer.Deserialize<ResponseDto>(resultJson);

        Assert.That(result?.Message, Is.EqualTo(expectedResponse.Message));
    }

    [Test]
    public void FetchData_ThrowsException_WhenRequestFailsWithNotFound()
    {
        var url = "https://example.com/api/fail";
        var errorResponse = new ErrorResponseDto
        {
            Error = "Resource not found",
            ErrorCode = "404"
        };
        var errorJson = JsonSerializer.Serialize(errorResponse);

        SetupHttpResponse(url, errorJson, HttpStatusCode.NotFound);

        var ex = Assert.Throws<Exception>(() => _requestService.FetchData(url));

        StringAssert.Contains("Ошибка: NotFound", ex.Message);

        if (ex.Data.Contains("ResponseContent"))
        {
            var responseContent = ex.Data["ResponseContent"] as string;
            var responseDto = JsonSerializer.Deserialize<ErrorResponseDto>(responseContent);
            Assert.That(responseDto.Error, Is.EqualTo("Resource not found"));
            Assert.That(responseDto.ErrorCode, Is.EqualTo("404"));
        }
    }

    [Test]
    public void FetchData_ThrowsException_WhenNonSuccess()
    {
        var url = "http://test";
        var errorResponse = new ErrorResponseDto { Error = "Internal Server Error" };
        var errorJson = JsonSerializer.Serialize(errorResponse);

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(errorJson)
            });

        var ex = Assert.Throws<Exception>(() => _requestService.FetchData(url));
        StringAssert.Contains("Ошибка: InternalServerError", ex.Message);
    }

    private void SetupHttpResponse(string url, string content, HttpStatusCode status)
    {
        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString().Trim() == url.Trim()),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = status,
                Content = new StringContent(content)
            });
    }
}