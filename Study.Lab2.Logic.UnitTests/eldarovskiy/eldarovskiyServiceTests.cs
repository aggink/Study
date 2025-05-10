using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Study.Lab2.Logic.eldarovskiy;
using Study.Lab2.Logic.Interfaces.eldarovskiy;

namespace Study.Lab2.Logic.UnitTests.eldarovskiy
{
    [TestFixture]
    public class eldarovskiyServiceTests
    {
        private Mock<IRequestService> _mockRequest;
        private StringWriter _output;
        private StringReader _input;

        [SetUp]
        public void SetUp()
        {
            _output = new StringWriter();
            Console.SetOut(_output);
        }

        [TearDown]
        public void TearDown()
        {
            _output.Dispose();
            _input?.Dispose();
        }

        private void PrepareConsoleInput(params string[] lines)
        {
            _input = new StringReader(string.Join(Environment.NewLine, lines));
            Console.SetIn(_input);
        }

        [Test]
        public void RunTask_PrintsAllResponses_WhenAllSuccess()
        {
            _mockRequest = new Mock<IRequestService>();
            _mockRequest
                .SetupSequence(x => x.FetchData(It.IsAny<string>()))
                .Returns("A").Returns("B").Returns("C");

            PrepareConsoleInput("City","2025","05","10","USA","UniName");
            var svc = new eldarovskiyServiceProxy(_mockRequest.Object);

            svc.RunTask();

            var txt = _output.ToString();
            Assert.That(txt, Does.Contain("Все ответы получены!"));
            Assert.That(txt.Split("Ответ").Length, Is.EqualTo(4));
        }

        [Test]
        public void RunTask_PrintsError_WhenFetchThrows()
        {
            _mockRequest = new Mock<IRequestService>();
            _mockRequest.Setup(x => x.FetchData(It.IsAny<string>()))
                        .Throws(new Exception("fail"));

            PrepareConsoleInput("City","2025","05","10","USA","UniName");
            var svc = new eldarovskiyServiceProxy(_mockRequest.Object);

            svc.RunTask();

            var txt = _output.ToString();
            Assert.That(txt, Does.Contain("Ошибка: fail"));
        }

        [Test]
        public void RunTask_PrintsExecutionTime_OnSuccess()
        {
            _mockRequest = new Mock<IRequestService>();
            _mockRequest
                .SetupSequence(x => x.FetchData(It.IsAny<string>()))
                .Returns("X").Returns("Y").Returns("Z");

            PrepareConsoleInput("City","2025","05","10","USA","UniName");
            var svc = new eldarovskiyServiceProxy(_mockRequest.Object);

            svc.RunTask();

            var txt = _output.ToString();
            // проверяем, что время выводится
            Assert.That(txt, Does.Contain("Время выполнения:"));
        }

        [Test]
        public void RunTask_PrintsCorrectUrls_BasedOnInput()
        {
            _mockRequest = new Mock<IRequestService>();
            _mockRequest
                .SetupSequence(x => x.FetchData(It.IsAny<string>()))
                .Returns("X").Returns("Y").Returns("Z");

            // в качестве примера вводим "Msk" для города, "2000-01-01" для даты и т.д.
            PrepareConsoleInput("Msk","2000","01","01","France","MyUni");
            var svc = new eldarovskiyServiceProxy(_mockRequest.Object);

            svc.RunTask();

            var txt = _output.ToString();
            // проверяем, что URL первого и второго запросов содержат наши параметры
            StringAssert.Contains("Запрос 1: http://api.weatherapi.com/v1/current.json?key=", txt);
            StringAssert.Contains("q=Msk", txt);
            StringAssert.Contains("Запрос 2: https://api.nasa.gov/planetary/apod?api_key=", txt);
            StringAssert.Contains("date=2000-01-01", txt);
        }

        [Test]
        public async Task RunTaskAsync_PrintsAllResponses_WhenAllSuccessAsync()
        {
            _mockRequest = new Mock<IRequestService>();
            _mockRequest
                .SetupSequence(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("X").ReturnsAsync("Y").ReturnsAsync("Z");

            PrepareConsoleInput("City","2025","05","10","USA","UniName");
            var svc = new eldarovskiyServiceProxy(_mockRequest.Object);

            await svc.RunTaskAsync();

            var txt = _output.ToString();
            Assert.That(txt, Does.Contain("Все ответы получены!"));
            Assert.That(txt.Split("Ответ").Length, Is.EqualTo(4));
        }

        [Test]
        public async Task RunTaskAsync_PrintsError_WhenFetchAsyncThrows()
        {
            _mockRequest = new Mock<IRequestService>();
            _mockRequest
                .Setup(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("boom"));

            PrepareConsoleInput("City","2025","05","10","USA","UniName");
            var svc = new eldarovskiyServiceProxy(_mockRequest.Object);

            await svc.RunTaskAsync();

            var txt = _output.ToString();
            Assert.That(txt, Does.Contain("Ошибка: boom"));
        }

        [Test]
        public async Task RunTaskAsync_PrintsExecutionTime_OnSuccessAsync()
        {
            _mockRequest = new Mock<IRequestService>();
            _mockRequest
                .SetupSequence(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("1").ReturnsAsync("2").ReturnsAsync("3");

            PrepareConsoleInput("C","2025","05","10","C","U");
            var svc = new eldarovskiyServiceProxy(_mockRequest.Object);

            await svc.RunTaskAsync();

            var txt = _output.ToString();
            Assert.That(txt, Does.Contain("Время выполнения:"));
        }

        [Test]
        public async Task RunTaskAsync_PrintsError_OnCanceled()
        {
            _mockRequest = new Mock<IRequestService>();
            _mockRequest
                .Setup(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new TaskCanceledException("cancelled"));

            PrepareConsoleInput("C","2025","05","10","C","U");
            var svc = new eldarovskiyServiceProxy(_mockRequest.Object);

            await svc.RunTaskAsync();

            var txt = _output.ToString();
            Assert.That(txt, Does.Contain("Ошибка: cancelled"));
        }
    }

    // Прокси-класс для внедрения мок-объекта
    public class eldarovskiyServiceProxy : eldarovskiyService
    {
        public eldarovskiyServiceProxy(IRequestService mockRequest)
        {
            var field = typeof(eldarovskiyService)
                .GetField("_requestHandler",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
            field.SetValue(this, mockRequest);
        }
    }
}
