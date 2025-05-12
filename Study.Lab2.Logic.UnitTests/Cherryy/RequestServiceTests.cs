using Moq;
using Moq.Protected;
using Study.Lab2.Logic.Cherryy;
using Study.Lab2.Logic.Interfaces.Cherryy;
using System.Net;

namespace Study.Lab2.Logic.UnitTests.Cherryy
{
    [TestFixture]
    public class RequestServiceTests
    {
        private RequestService _requestService;
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private Mock<IRequestService> _requestServiceMock;

        [SetUp]
        public void Setup()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _requestService = new RequestService(httpClient);
        }

        [Test]
        public void FetchData_Success_ReturnsResponse()
        {
            // Arrange
            var expectedResponse = "{\"message\":\"Success\"}";
            var requestUrl = "https://example.com/api/test";
            SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

            // Act
            var result = _requestService.FetchData(requestUrl);

            // Assert
            Assert.AreEqual(expectedResponse, result);
        }

        [Test]
        public void FetchData_HttpError_ThrowsException()
        {
            // Arrange
            var requestUrl = "https://example.com/api/error";
            SetupHttpResponse(requestUrl, "Error", HttpStatusCode.BadRequest);

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
            Assert.That(ex.Message, Does.Contain("Ошибка при выполнении запроса"));
        }

        [Test]
        public async Task FetchDataAsync_Success_ReturnsResponse()
        {
            // Arrange
            var expectedResponse = "{\"message\":\"Success\"}";
            var requestUrl = "https://example.com/api/test";
            SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

            // Act
            var result = await _requestService.FetchDataAsync(requestUrl, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResponse, result);
        }

        [Test]
        public void FetchDataAsync_HttpError_ThrowsException()
        {
            // Arrange
            var requestUrl = "https://example.com/api/error";
            SetupHttpResponse(requestUrl, "Error", HttpStatusCode.InternalServerError);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () =>
                await _requestService.FetchDataAsync(requestUrl, CancellationToken.None));
            Assert.That(ex.Message, Does.Contain("Ошибка при выполнении запроса"));
        }

        [Test]
        public void FetchDataAsync_Cancelled_ThrowsOperationCanceled()
        {
            // Arrange
            var requestUrl = "https://example.com/api/test";
            var cts = new CancellationTokenSource();
            cts.Cancel();

            // Act & Assert
            Assert.ThrowsAsync<OperationCanceledException>(async () =>
                await _requestService.FetchDataAsync(requestUrl, cts.Token));
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
        public void TearDown()
        {
            _requestService?.Dispose();
        }
    }
}