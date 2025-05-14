using Moq;
using Study.Lab2.Logic.Interfaces.katty;
using Study.Lab2.Logic.katty.Data;

namespace Study.Lab2.Logic.UnitTests.katty;

[TestFixture]
public class RequestServiceTests
{
    private Mock<IRequestService> _mockRequestService;

    [SetUp]
    public void Setup()
    {
        _mockRequestService = new Mock<IRequestService>();
    }

    [Test]
    public void SendRequest_ВозвращаетДанные_КогдаСерверДоступен()
    {
        // Arrange
        string url = KattyTestData.Urls[0];
        _mockRequestService.Setup(x => x.SendRequest(url))
            .Returns(KattyTestData.RawResponses[0]);

        // Act
        var result = _mockRequestService.Object.SendRequest(url);

        // Assert
        Assert.AreEqual(KattyTestData.RawResponses[0], result);
        Assert.IsFalse(result.StartsWith("Error:"), "Ответ не должен содержать ошибку");
        Assert.IsTrue(result.Contains("\"id\":"), "Ответ должен содержать JSON с полем id");
    }

    [Test]
    public void SendRequest_ВозвращаетОшибку_КогдаСерверНедоступен()
    {
        // Arrange
        string url = "https://non-existing-server-123456789.com";
        string expectedError = "Error: Не удалось подключиться к серверу";
        _mockRequestService.Setup(x => x.SendRequest(url))
            .Returns(expectedError);

        // Act
        var result = _mockRequestService.Object.SendRequest(url);

        // Assert
        Assert.AreEqual(expectedError, result);
        Assert.IsTrue(result.StartsWith("Error:"), "Ответ должен содержать сообщение об ошибке");
    }

    [Test]
    public async Task SendRequestAsync_ВозвращаетДанные_КогдаСерверДоступен()
    {
        // Arrange
        string url = KattyTestData.Urls[0];
        _mockRequestService.Setup(x => x.SendRequestAsync(url, It.IsAny<CancellationToken>()))
            .ReturnsAsync(KattyTestData.RawResponses[0]);

        // Act
        var result = await _mockRequestService.Object.SendRequestAsync(url);

        // Assert
        Assert.AreEqual(KattyTestData.RawResponses[0], result);
        Assert.IsFalse(result.StartsWith("Error:"), "Ответ не должен содержать ошибку");
        Assert.IsTrue(result.Contains("\"id\":"), "Ответ должен содержать JSON с полем id");
    }

    [Test]
    public async Task SendRequestAsync_ВозвращаетОшибку_КогдаСерверНедоступен()
    {
        // Arrange
        string url = "https://non-existing-server-123456789.com";
        string expectedError = "Error: Не удалось подключиться к серверу";
        _mockRequestService.Setup(x => x.SendRequestAsync(url, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedError);

        // Act
        var result = await _mockRequestService.Object.SendRequestAsync(url);

        // Assert
        Assert.AreEqual(expectedError, result);
        Assert.IsTrue(result.StartsWith("Error:"), "Ответ должен содержать сообщение об ошибке");
    }
}