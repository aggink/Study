using Study.Lab2.Logic.katty;

namespace Study.Lab2.Logic.UnitTests.katty;

[TestFixture]
public class RequestServiceTests
{
    private RequestService _requestService;

    [SetUp]
    public void Setup()
    {
        _requestService = new RequestService();
    }

    [Test]
    public void SendRequest_ВозвращаетДанные_КогдаСерверДоступен()
    {
        // Arrange
        string url = "https://jsonplaceholder.typicode.com/todos/1";

        // Act
        var result = _requestService.SendRequest(url);

        // Assert
        Assert.IsFalse(result.StartsWith("Error:"), "Ответ не должен содержать ошибку");
        Assert.IsTrue(result.Contains("\"id\":"), "Ответ должен содержать JSON с полем id");
    }

    [Test]
    public void SendRequest_ВозвращаетОшибку_КогдаСерверНедоступен()
    {
        // Arrange
        string url = "https://non-existing-server-123456789.com";

        // Act
        var result = _requestService.SendRequest(url);

        // Assert
        Assert.IsTrue(result.StartsWith("Error:"), "Ответ должен содержать сообщение об ошибке");
    }

    [Test]
    public async Task SendRequestAsync_ВозвращаетДанные_КогдаСерверДоступен()
    {
        // Arrange
        string url = "https://jsonplaceholder.typicode.com/todos/1";
        CancellationToken cancellationToken = CancellationToken.None;

        // Act
        var result = await _requestService.SendRequestAsync(url, cancellationToken);

        // Assert
        Assert.IsFalse(result.StartsWith("Error:"), "Ответ не должен содержать ошибку");
        Assert.IsTrue(result.Contains("\"id\":"), "Ответ должен содержать JSON с полем id");
    }

    [Test]
    public async Task SendRequestAsync_ВозвращаетОшибку_КогдаСерверНедоступен()
    {
        // Arrange
        string url = "https://non-existing-server-123456789.com";
        CancellationToken cancellationToken = CancellationToken.None;

        // Act
        var result = await _requestService.SendRequestAsync(url, cancellationToken);

        // Assert
        Assert.IsTrue(result.StartsWith("Error:"), "Ответ должен содержать сообщение об ошибке");
    }
}
