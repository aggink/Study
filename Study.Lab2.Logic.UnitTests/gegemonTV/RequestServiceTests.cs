using Moq;
using Moq.Protected;
using Study.Lab2.Logic.gegemonTV;
using System.Net;

namespace Study.Lab2.Logic.UnitTests.gegemonTV
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
        /// Тест для синхронного метода на проверку корректности вывода JSON формата
        /// </summary>
        [Test]
        public void FetchData_CheckJson()
        {
            var expectedJson = "[\r\n\t{\r\n\t\t\"domains\": [\r\n\t\t\t\"technion.ac.il\"\r\n\t\t],\r\n\t\t\"web_pages\": [\r\n\t\t\t\"http://www.technion.ac.il/\"\r\n\t\t],\r\n\t\t\"state-province\": null,\r\n\t\t\"alpha_two_code\": \"IL\",\r\n\t\t\"name\": \"Technion - Israel Institute of Technology\",\r\n\t\t\"country\": \"Israel\"\r\n\t}\r\n]";
            var requestUrl = "http://universities.hipolabs.com/search?name=Technion&country=israel";

            // Настройка мок-ответа
            SetupHttpResponse(requestUrl, expectedJson, HttpStatusCode.OK);

            var result = _requestService.FetchData(requestUrl).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\t", string.Empty);

            Assert.That(JsonHelper.FormatJson(result), Is.EqualTo(expectedJson));
        }

        /// <summary>
        /// Тест для асинхронного метода на проверку корректности вывода JSON формата
        /// </summary>
        [Test]
        public async Task FetchDataAsync_CheckJson()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            var expectedJson = "[\r\n\t{\r\n\t\t\"domains\": [\r\n\t\t\t\"technion.ac.il\"\r\n\t\t],\r\n\t\t\"web_pages\": [\r\n\t\t\t\"http://www.technion.ac.il/\"\r\n\t\t],\r\n\t\t\"state-province\": null,\r\n\t\t\"alpha_two_code\": \"IL\",\r\n\t\t\"name\": \"Technion - Israel Institute of Technology\",\r\n\t\t\"country\": \"Israel\"\r\n\t}\r\n]";
            var requestUrl = "http://universities.hipolabs.com/search?name=Technion&country=israel";

            // Настройка мок-ответа
            SetupHttpResponse(requestUrl, expectedJson, HttpStatusCode.OK);

            var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);
            result = result.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\t", string.Empty);

            Assert.That(JsonHelper.FormatJson(result), Is.EqualTo(expectedJson));
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
            StringAssert.Contains("[ERROR]: NotFound - Not Found", exception.Message);
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
            StringAssert.Contains("[ERROR]: NotFound - Not Found", exception.Message);
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
