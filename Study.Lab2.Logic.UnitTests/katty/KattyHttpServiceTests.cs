using Moq;
using Study.Lab2.Logic.Interfaces.katty;
using Study.Lab2.Logic.katty;

namespace Study.Lab2.Logic.UnitTests.katty;

[TestFixture]
public class KattyHttpServiceTests
{
    private Mock<IServerRequestService> _mockServerRequestService;
    private KattyHttpService _kattyHttpService;

    [SetUp]
    public void Setup()
    {
        _mockServerRequestService = new Mock<IServerRequestService>();

        var service = new KattyHttpService();
        var field = typeof(KattyHttpService).GetField("_serverRequestService",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        field.SetValue(service, _mockServerRequestService.Object);

        _kattyHttpService = service;
    }

    [Test]
    public void RunTask_УспешноВыполняетСинхронныеЗапросы()
    {
        // Arrange
        _mockServerRequestService.Setup(x => x.ExecuteRequests());

        // Act & Assert
        Assert.DoesNotThrow(() => _kattyHttpService.RunTask(), "Метод RunTask должен успешно завершаться");
        _mockServerRequestService.Verify(x => x.ExecuteRequests(), Times.Once(), "Метод ExecuteRequests должен вызываться один раз");
    }

    [Test]
    public void RunTask_ОбрабатываетИсключения_ПриОшибке()
    {
        // Arrange
        _mockServerRequestService.Setup(x => x.ExecuteRequests()).Throws(new Exception("Test error"));

        // Act & Assert
        Assert.DoesNotThrow(() => _kattyHttpService.RunTask(), "Метод RunTask должен перехватывать исключения");
    }

    [Test]
    public async Task RunTaskAsync_УспешноВыполняетАсинхронныеЗапросы()
    {
        // Arrange
        var expectedResponses = new List<string> { "test response" };
        var expectedElapsedTime = 100L;

        _mockServerRequestService
            .Setup(x => x.ExecuteRequestsAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((expectedResponses, expectedElapsedTime));

        // Act & Assert
        await _kattyHttpService.RunTaskAsync();

        // Verify
        _mockServerRequestService.Verify(
            x => x.ExecuteRequestsAsync(It.IsAny<CancellationToken>()),
            Times.Once(),
            "Метод ExecuteRequestsAsync должен вызываться один раз"
        );
    }

    [Test]
    public async Task RunTaskAsync_ОбрабатываетОтмену_ПриПрерывании()
    {
        // Arrange
        _mockServerRequestService.Setup(x => x.ExecuteRequestsAsync(It.IsAny<CancellationToken>()))
            .Throws(new OperationCanceledException());

        // Act
        await _kattyHttpService.RunTaskAsync();
    }

    [Test]
    public async Task RunTaskAsync_ОбрабатываетОбщиеИсключения()
    {
        // Arrange
        _mockServerRequestService.Setup(x => x.ExecuteRequestsAsync(It.IsAny<CancellationToken>()))
            .Throws(new Exception("Test error"));

        // Act
        await _kattyHttpService.RunTaskAsync();
    }
}
