using Moq;
using Study.Lab2.Logic.Interfaces.katty;
using Study.Lab2.Logic.katty;

namespace Study.Lab2.Logic.UnitTests.katty;

[TestFixture]
public class ServerRequestServiceTests
{
    private Mock<IRequestService> _mockRequestService;
    private Mock<IResponseProcessor> _mockResponseProcessor;
    private ServerRequestService _serverRequestService;

    [SetUp]
    public void Setup()
    {
        _mockRequestService = new Mock<IRequestService>();
        _mockResponseProcessor = new Mock<IResponseProcessor>();
        _serverRequestService = new ServerRequestService(_mockRequestService.Object, _mockResponseProcessor.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _serverRequestService.Dispose();
    }

    [Test]
    public void ExecuteRequests_УспешноВыполняетЗапросы_КогдаВсеЗапросыУспешны()
    {
        // Arrange
        _mockRequestService.Setup(x => x.SendRequest(It.IsAny<string>())).Returns("{\"id\": 1}");
        _mockResponseProcessor.Setup(x => x.IsSuccessResponse(It.IsAny<string>())).Returns(true);
        _mockResponseProcessor.Setup(x => x.ProcessResponse(It.IsAny<string>())).Returns("{\n  \"id\": 1\n}");

        // Act & Assert
        Assert.DoesNotThrow(() => _serverRequestService.ExecuteRequests(), "Метод должен выполниться без исключений");
    }

    [Test]
    public void ExecuteRequests_ВыбрасываетИсключение_ПриНеудачномЗапросе()
    {
        // Arrange
        _mockRequestService.Setup(x => x.SendRequest(It.IsAny<string>())).Returns("Error: 404 Not Found");
        _mockResponseProcessor.Setup(x => x.IsSuccessResponse(It.IsAny<string>())).Returns(false);

        // Act & Assert
        Assert.Throws<Exception>(() => _serverRequestService.ExecuteRequests(), "Метод должен выбросить исключение при неудачном запросе");
    }

    [Test]
    public async Task ExecuteRequestsAsync_УспешноВыполняетЗапросы_КогдаВсеЗапросыУспешны()
    {
        // Arrange
        _mockRequestService.Setup(x => x.SendRequestAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("{\"id\": 1}");
        _mockResponseProcessor.Setup(x => x.IsSuccessResponse(It.IsAny<string>())).Returns(true);
        _mockResponseProcessor.Setup(x => x.ProcessResponse(It.IsAny<string>())).Returns("{\n  \"id\": 1\n}");

        // Act & Assert
        await _serverRequestService.ExecuteRequestsAsync();
    }

    [Test]
    public void ExecuteRequestsAsync_ВыбрасываетИсключение_ПриНеудачномЗапросе()
    {
        // Arrange
        _mockRequestService.Setup(x => x.SendRequestAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Error: 404 Not Found");
        _mockResponseProcessor.Setup(x => x.IsSuccessResponse(It.IsAny<string>())).Returns(false);

        // Act & Assert
        Assert.ThrowsAsync<Exception>(async () => await _serverRequestService.ExecuteRequestsAsync(),
            "Метод должен выбросить исключение при неудачном запросе");
    }

    [Test]
    public void ExecuteRequestsAsync_ПрерываетВыполнение_ПриОтмене()
    {
        // Arrange
        var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert
        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await _serverRequestService.ExecuteRequestsAsync(cts.Token),
            "Метод должен выбросить OperationCanceledException при отмене операции");
    }
    [Test]
    public void Dispose_НеВыбрасываетИсключений()
    {
        // Act & Assert
        Assert.DoesNotThrow(() => _serverRequestService.Dispose(), "Метод Dispose не должен выбрасывать исключения");
    }
}
