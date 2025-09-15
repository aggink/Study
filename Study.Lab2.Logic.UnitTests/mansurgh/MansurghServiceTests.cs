using Moq;
using Study.Lab2.Logic.mansurgh;
using Study.Lab2.Logic.Interfaces.mansurgh;

namespace Study.Lab2.Logic.UnitTests.mansurgh
{
    [TestFixture]
    public class MansurghServiceTests
    {
        private MansurghService _mansurghService;
        private Mock<IRequestService> _requestServiceMock;

        [SetUp]
        public void Setup()
        {
            _requestServiceMock = new Mock<IRequestService>();
            // Для тестирования используем моковый сервис
            // В реальном коде сервис создается через конструктор без параметров
        }

        /// <summary>
        /// Тест проверяет, что синхронный метод RunTask корректно обрабатывает успешные ответы от всех трех серверов
        /// </summary>
        [Test]
        public void RunTask_AllRequestsSuccessful_CompletesSuccessfully()
        {
            // Arrange
            var responses = new[]
            {
                "{\"id\": 1, \"title\": \"Post 1\", \"body\": \"Body 1\"}",
                "{\"message\": \"HTTPBin response\"}",
                "{\"login\": \"octocat\", \"id\": 1}"
            };

            _requestServiceMock.SetupSequence(x => x.FetchData(It.IsAny<string>()))
                .Returns(responses[0])
                .Returns(responses[1])
                .Returns(responses[2]);

            // Создаем сервис с моковым RequestService через рефлексию
            _mansurghService = new MansurghService();
            var field = typeof(MansurghService).GetField("_requestService", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field?.SetValue(_mansurghService, _requestServiceMock.Object);

            // Act & Assert - проверяем, что метод выполняется без исключений
            Assert.DoesNotThrow(() => _mansurghService.RunTask());
            
            // Проверяем, что все три запроса были выполнены
            _requestServiceMock.Verify(x => x.FetchData(It.IsAny<string>()), Times.Exactly(3));
        }

        /// <summary>
        /// Тест проверяет, что асинхронный метод RunTaskAsync корректно обрабатывает успешные ответы от всех трех серверов
        /// </summary>
        [Test]
        public async Task RunTaskAsync_AllRequestsSuccessful_CompletesSuccessfully()
        {
            using var cancellationTokenSource = new CancellationTokenSource();
            
            // Arrange
            var responses = new[]
            {
                "{\"id\": 1, \"title\": \"Post 1\", \"body\": \"Body 1\"}",
                "{\"message\": \"HTTPBin response\"}",
                "{\"login\": \"octocat\", \"id\": 1}"
            };

            _requestServiceMock.Setup(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((string url, CancellationToken token) =>
                {
                    if (url.Contains("posts/1")) return responses[0];
                    if (url.Contains("httpbin")) return responses[1];
                    if (url.Contains("github")) return responses[2];
                    return "{}";
                });

            // Создаем сервис с моковым RequestService
            _mansurghService = new MansurghService();
            var field = typeof(MansurghService).GetField("_requestService", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field?.SetValue(_mansurghService, _requestServiceMock.Object);

            // Act & Assert - проверяем, что метод выполняется без исключений
            Assert.DoesNotThrowAsync(async () => await _mansurghService.RunTaskAsync(cancellationTokenSource.Token));
            
            // Проверяем, что все три асинхронных запроса были выполнены
            _requestServiceMock.Verify(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Exactly(3));
        }

        /// <summary>
        /// Тест проверяет, что синхронный метод корректно обрабатывает ошибку от одного из серверов
        /// </summary>
        [Test]
        public void RunTask_RequestFails_HandlesExceptionGracefully()
        {
            // Arrange
            _requestServiceMock.Setup(x => x.FetchData(It.IsAny<string>()))
                .Throws(new Exception("Ошибка: NotFound - Not Found"));

            _mansurghService = new MansurghService();
            var field = typeof(MansurghService).GetField("_requestService", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field?.SetValue(_mansurghService, _requestServiceMock.Object);

            // Act & Assert - проверяем, что метод не выбрасывает исключение, а обрабатывает его
            Assert.DoesNotThrow(() => _mansurghService.RunTask());
            
            // Проверяем, что запрос был выполнен (хотя бы попытка)
            _requestServiceMock.Verify(x => x.FetchData(It.IsAny<string>()), Times.AtLeastOnce);
        }

        /// <summary>
        /// Тест проверяет, что асинхронный метод корректно обрабатывает ошибку от одного из серверов
        /// </summary>
        [Test]
        public async Task RunTaskAsync_RequestFails_HandlesExceptionGracefully()
        {
            using var cancellationTokenSource = new CancellationTokenSource();
            
            // Arrange
            _requestServiceMock.Setup(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Ошибка: InternalServerError - Internal Server Error"));

            _mansurghService = new MansurghService();
            var field = typeof(MansurghService).GetField("_requestService", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field?.SetValue(_mansurghService, _requestServiceMock.Object);

            // Act & Assert - проверяем, что метод не выбрасывает исключение, а обрабатывает его
            Assert.DoesNotThrowAsync(async () => await _mansurghService.RunTaskAsync(cancellationTokenSource.Token));
            
            // Проверяем, что запрос был выполнен (хотя бы попытка)
            _requestServiceMock.Verify(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.AtLeastOnce);
        }

        /// <summary>
        /// Тест проверяет корректность освобождения ресурсов
        /// </summary>
        [Test]
        public void Dispose_CallsRequestServiceDispose()
        {
            // Arrange
            _mansurghService = new MansurghService();
            var field = typeof(MansurghService).GetField("_requestService", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field?.SetValue(_mansurghService, _requestServiceMock.Object);

            // Act
            _mansurghService.Dispose();

            // Assert
            _requestServiceMock.Verify(x => x.Dispose(), Times.Once);
        }

        [TearDown]
        public void TearDown()
        {
            _mansurghService?.Dispose();
        }
    }
}
