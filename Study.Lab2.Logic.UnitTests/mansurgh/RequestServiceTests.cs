using Moq;
using Moq.Protected;
using Study.Lab2.Logic.mansurgh;
using System.Net;

namespace Study.Lab2.Logic.UnitTests.mansurgh
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

        /// <summary>
        /// Тест для синхронного метода FetchData. Проверяет, что метод возвращает правильный ответ при успешном запросе.
        /// </summary>
        [Test]
        public void FetchData_Success_ReturnsResponse()
        {
            // Arrange
            var expectedResponse = "{\"id\": 1, \"title\": \"Test Post\", \"body\": \"Test Body\"}";
            var requestUrl = "https://jsonplaceholder.typicode.com/posts/1";

            // Настройка мок-ответа
            SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

            // Act
            var result = _requestService.FetchData(requestUrl);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }

        /// <summary>
        /// Тест для асинхронного метода FetchDataAsync. Проверяет, что метод возвращает правильный ответ при успешном запросе.
        /// </summary>
        [Test]
        public async Task FetchDataAsync_Success_ReturnsResponse()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            // Arrange
            var expectedResponse = "{\"login\": \"octocat\", \"id\": 1, \"name\": \"The Octocat\"}";
            var requestUrl = "https://api.github.com/users/octocat";

            // Настройка мок-ответа
            SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

            // Act
            var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }

        /// <summary>
        /// Тест для синхронного метода FetchData. Проверяет, что метод выбрасывает исключение при неуспешном запросе (404 Not Found).
        /// </summary>
        [Test]
        public void FetchData_Failure_ThrowsException()
        {
            // Arrange
            var requestUrl = "https://httpbin.org/status/404";

            // Настройка мок-ответа с кодом ошибки
            SetupHttpResponse(requestUrl, "Not Found", HttpStatusCode.NotFound);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
            StringAssert.Contains("Ошибка: NotFound", exception.Message);
        }

        /// <summary>
        /// Тест для асинхронного метода FetchDataAsync. Проверяет, что метод выбрасывает исключение при неуспешном запросе (500 Internal Server Error).
        /// </summary>
        [Test]
        public void FetchDataAsync_ServerError_ThrowsException()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            // Arrange
            var requestUrl = "https://httpbin.org/status/500";

            // Настройка мок-ответа с кодом ошибки
            SetupHttpResponse(requestUrl, "Internal Server Error", HttpStatusCode.InternalServerError);

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => 
                await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
            StringAssert.Contains("Ошибка: InternalServerError", exception.Message);
        }

        /// <summary>
        /// Тест для проверки отмены операции через CancellationToken
        /// </summary>
        [Test]
        public void FetchDataAsync_Cancelled_ThrowsOperationCancelledException()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            // Arrange
            var requestUrl = "https://httpbin.org/delay/5";
            cancellationTokenSource.Cancel(); // Отменяем операцию

            // Настройка мок-ответа
            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new OperationCanceledException());

            // Act & Assert
            Assert.ThrowsAsync<OperationCanceledException>(async () => 
                await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        }

        /// <summary>
        /// Настройка мок-ответа для HTTP-запроса.
        /// </summary>
        /// <param name="url">URL запроса</param>
        /// <param name="content">Тело ответа</param>
        /// <param name="statusCode">Код ответа HTTP</param>
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

        /// <summary>
        /// Освобождение ресурсов, реализует IDisposable.
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _requestService?.Dispose();
        }
    }
}
