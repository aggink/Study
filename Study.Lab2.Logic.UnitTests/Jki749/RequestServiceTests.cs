﻿using Moq;
using Moq.Protected;
using Study.Lab2.Logic.Interfaces.Jki749;
using Study.Lab2.Logic.Jki749;
using Study.Lab2.Logic.UnitTests.Jki749.DtoModels;
using System.Net;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.Jki749;

[TestFixture]
public class RequestServiceTests
{
    private Mock<HttpMessageHandler> _mockHttpHandler;
    private IRequestService _requestService;

    [SetUp]
    public void Setup()
    {
        _mockHttpHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_mockHttpHandler.Object);
        _requestService = new RequestService(httpClient);
    }

    [TearDown]
    public void Cleanup()
    {
        _requestService.Dispose();
    }

    [Test]
    public void FetchData_ValidRequest_ReturnsResponse()
    {
        // Arrange
        var testData = new TestDataDto { Id = 1 };
        var expectedResponse = JsonSerializer.Serialize(testData);
        var testUrl = "https://api.example.com/data";

        _mockHttpHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == testUrl),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedResponse)
            });

        // Act
        var result = _requestService.FetchData(testUrl);
        var deserializedResult = JsonSerializer.Deserialize<TestDataDto>(result);

        // Assert
        Assert.That(deserializedResult.Id, Is.EqualTo(testData.Id));
    }

    [Test]
    public void FetchData_InvalidRequest_ThrowsException()
    {
        // Arrange
        var invalidUrl = "https://api.example.com/error";

        _mockHttpHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Network error"));

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _requestService.FetchData(invalidUrl));

        Assert.True(ex.Message.StartsWith("Ошибка при запросе к"));
    }

    [Test]
    public async Task FetchDataAsync_ValidRequest_ReturnsResponse()
    {
        // Arrange
        var testUser = new TestUserDto { Name = "John" };
        var expectedResponse = JsonSerializer.Serialize(testUser);
        var testUrl = "https://api.example.com/user";

        _mockHttpHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == testUrl),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedResponse)
            });

        // Act
        var result = await _requestService.FetchDataAsync(testUrl);
        var deserializedResult = JsonSerializer.Deserialize<TestUserDto>(result);

        // Assert
        Assert.That(deserializedResult.Name, Is.EqualTo(testUser.Name));
    }
}