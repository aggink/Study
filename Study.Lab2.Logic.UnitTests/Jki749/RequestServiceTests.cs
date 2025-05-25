using Moq;
using Moq.Protected;
using NUnit.Framework;
using Study.Lab2.Logic.Interfaces.Jki749;
using Study.Lab2.Logic.Services.Jki749;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.UnitTests.Jki749;
    [TestFixture]
    public class RequestServiceTests
    {
        private Mock<HttpMessageHandler> _mockHttpHandler;
        private RequestService _requestService;

        [SetUp]
        public void Setup()
        {
            _mockHttpHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockHttpHandler.Object);
            _requestService = new RequestService(httpClient);
        }

        [Test]
        public void FetchData_ValidRequest_ReturnsResponse()
        {
            // Arrange
            var expectedResponse = "{\"id\": 1}";
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

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
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
            Assert.Throws<Exception>(() => _requestService.FetchData(invalidUrl));
        }

        [Test]
        public async Task FetchDataAsync_ValidRequest_ReturnsResponse()
        {
            // Arrange
            var expectedResponse = "{\"name\":\"John\"}";
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

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }

        [TearDown]
        public void Cleanup()
        {
            _requestService.Dispose();
        }
    }