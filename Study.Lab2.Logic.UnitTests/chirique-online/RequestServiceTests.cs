using Moq;
using Moq.Protected;
using Study.Lab2.Logic.chirique_online;
using System.Net;

namespace Study.Lab2.Logic.UnitTests.chirique_online
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

        [Test]
        public void FetchData_ReturnsResponse_WhenSuccess()
        {
            var url = "https://example.com/api/test ";
            var expected = "{\"message\": \"Success\"}";

            SetupHttpResponse(url, expected, HttpStatusCode.OK);

            var result = _requestService.FetchData(url);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public async Task FetchDataAsync_ReturnsResponse_WhenSuccess()
        {
            var url = "https://example.com/api/test ";
            var expected = "{\"message\": \"Success\"}";

            SetupHttpResponse(url, expected, HttpStatusCode.OK);

            var result = await _requestService.FetchDataAsync(url, default);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void FetchData_ThrowsException_WhenRequestFailsWithNotFound()
        {
            var url = "https://example.com/api/fail ";

            SetupHttpResponse(url, "Not Found", HttpStatusCode.NotFound);

            var ex = Assert.Throws<Exception>(() => _requestService.FetchData(url));
            StringAssert.Contains("Ошибка: NotFound", ex.Message);
        }

        [Test]
        public void FetchData_ThrowsException_WhenNonSuccess()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        ReasonPhrase = "Fail",
                    }
                );

            var httpClient = new HttpClient(handlerMock.Object);
            using var svc = new RequestService(httpClient);

            Assert.Throws<Exception>(() => svc.FetchData("http://test"));
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

        [TearDown]
        public void Dispose()
        {
            _requestService?.Dispose();
        }
    }
}