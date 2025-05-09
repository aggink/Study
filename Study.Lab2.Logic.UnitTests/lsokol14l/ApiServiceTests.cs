using System.Net;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.Interfaces.lsokol14l;
using Study.Lab2.Logic.lsokol14l;

namespace Study.Lab2.Logic.UnitTests.lsokol14l
{
    [TestFixture]
    public class RequestServiceTests
    {
        private RequestService _requestService;
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private Mock<IJsonResponseProcessor> _responseProcessorMock;

        [SetUp]
        public void Setup()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _responseProcessorMock = new Mock<IJsonResponseProcessor>();

            var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _requestService = new RequestService(httpClient);
        }

        [Test]
        public void FetchData_Success_ReturnsResponse()
        {
            // Arrange
            var expectedResponse = "{\"message\": \"Success\"}";
            var requestUrl = "https://example.com/api/test";

            SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

            // Act
            var result = _requestService.FetchData(requestUrl);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }

        [Test]
        public async Task FetchDataAsync_Success_ReturnsResponse()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            // Arrange
            var expectedResponse = "{\"message\": \"Success\"}";
            var requestUrl = "https://example.com/api/test";

            SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

            // Act
            var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }

        [Test]
        public void FetchData_Failure_ThrowsException()
        {
            // Arrange
            var requestUrl = "https://example.com/api/fail";

            SetupHttpResponse(requestUrl, "Not Found", HttpStatusCode.NotFound);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
            StringAssert.Contains("Ошибка: NotFound", exception.Message);
        }

        [Test]
        public void PerformRequestsSync_ProcessesResponsesCorrectly()
        {
            // Arrange
            var urls = new[] { "https://example.com/api/1", "https://example.com/api/2" };
            var responseContent = "{\"message\": \"Success\"}";
            var processedResponse = new { Message = "Processed" };

            SetupHttpResponse(urls[0], responseContent, HttpStatusCode.OK);
            SetupHttpResponse(urls[1], responseContent, HttpStatusCode.OK);

            _responseProcessorMock
                .Setup(processor => processor.ProcessResponse(responseContent))
                .Returns(processedResponse);

            // Act
            _requestService.PerformRequestsSync(urls, _responseProcessorMock.Object);

            // Assert
            _responseProcessorMock.Verify(processor => processor.ProcessResponse(responseContent), Times.Exactly(urls.Length));
        }

        [Test]
        public async Task PerformRequestsAsync_ProcessesResponsesCorrectly()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            // Arrange
            var urls = new[] { "https://example.com/api/1", "https://example.com/api/2" };
            var responseContent = "{\"message\": \"Success\"}";
            var processedResponse = new { Message = "Processed" };

            SetupHttpResponse(urls[0], responseContent, HttpStatusCode.OK);
            SetupHttpResponse(urls[1], responseContent, HttpStatusCode.OK);

            _responseProcessorMock
                .Setup(processor => processor.ProcessResponse(responseContent))
                .Returns(processedResponse);

            // Act
            await _requestService.PerformRequestsAsync(urls, _responseProcessorMock.Object, cancellationTokenSource.Token);

            // Assert
            _responseProcessorMock.Verify(processor => processor.ProcessResponse(responseContent), Times.Exactly(urls.Length));
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

        [TearDown]
        public void Dispose()
        {
            _requestService?.Dispose();
        }
    }
}
