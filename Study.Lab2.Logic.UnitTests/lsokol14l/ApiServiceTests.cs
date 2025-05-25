using System.Net;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.lsokol14l;

namespace Study.Lab2.Logic.UnitTests.lsokol14l
{
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
}
