﻿using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.KirillPoroshin;
using Study.Lab2.Logic.KirillPoroshin.DtoModels;

namespace Study.Lab2.Logic.UnitTests.KirillPoroshin;

[TestFixture]
public class RequestServiceTests
{
    private const string REQUEST_URL = "http://numbersapi.com/42/trivia?json";

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
        var data = new NumberFactResponseDto
        {
            Text = "42 is the answer to the Ultimate Question of Life, the Universe, and Everything",
            Number = 42,
            Type = "trivia"
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