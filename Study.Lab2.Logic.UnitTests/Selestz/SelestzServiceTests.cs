using Moq;
using NUnit.Framework;
using Study.Lab2.Logic.Interfaces.Selestz;
using Study.Lab2.Logic.Selestz;

namespace Study.Lab2.Logic.UnitTests.Selestz;

[TestFixture]
public class SelestzServiceTests
{
    private Mock<IServerRequestService> _serverRequestServiceMock;
    private SelestzService _selestzService;

    [SetUp]
    public void Setup()
    {
        _serverRequestServiceMock = new Mock<IServerRequestService>();

        // Используем реальные зависимости для интеграционного тестирования
        var requestService = new RequestService(new HttpClient());
        var responseProcessor = new ResponseProcessor();
        var serverRequestService = new ServerRequestService(requestService, responseProcessor);

        _selestzService = new SelestzService();
    }

    [Test]
    public void RunTask_ExecutesWithoutExceptions()
    {
        // Act
        TestDelegate action = () => _selestzService.RunTask();

        // Assert
        Assert.DoesNotThrow(action);
    }

    [Test]
    public async Task RunTaskAsync_ExecutesWithoutExceptions()
    {
        // Act
        AsyncTestDelegate action = async () => await _selestzService.RunTaskAsync();

        // Assert
        Assert.DoesNotThrowAsync(action);
    }

    [TearDown]
    public void Cleanup()
    {
        _selestzService.Dispose();
    }
}