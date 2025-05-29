using Moq.Protected;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Study.Lab2.Logic.SuperSalad007;


namespace Study.Lab2.Logic.UnitTests.SuperSalad007
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
            var expectedResponse = "{\"message\": \"Success\"}";
            var requestUrl = "https://example.com/api/test";

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
            var expectedResponse = "{\"message\": \"Success\"}";
            var requestUrl = "https://example.com/api/test";

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
            var requestUrl = "https://example.com/api/fail";

            // Настройка мок-ответа с кодом ошибки
            SetupHttpResponse(requestUrl, "Not Found", HttpStatusCode.NotFound);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
            StringAssert.Contains("Ошибка: NotFound", exception.Message);
        }

        /// <summary>
        /// Тест для асинхронного метода FetchDataAsync. Проверяет, что метод выбрасывает исключение при неуспешном запросе (404 Not Found).
        /// </summary>
        [Test]
        public void FetchDataAsync_Failure_ThrowsException()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            // Arrange
            var requestUrl = "https://example.com/api/fail";

            // Настройка мок-ответа с кодом ошибки
            SetupHttpResponse(requestUrl, "Not Found", HttpStatusCode.NotFound);

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
            StringAssert.Contains("Ошибка: NotFound", exception.Message);
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
