using Moq;
using Study.Lab2.Logic.chaspix;
using Study.Lab2.Logic.Interfaces.chaspix;

namespace Study.Lab2.Logic.UnitTests.chaspix;

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
        _serverRequestService?.Dispose();
    }

    [Test]
    public void GetRandomPost_ErrorResponse_ThrowsException()
    {
        // Arrange
        var errorResponse = "{\"error\":\"Post not found\"}";
        _mockRequestService.Setup(x => x.FetchData(It.IsAny<string>(), null))
            .Returns(errorResponse);
        _mockResponseProcessor.Setup(x => x.HasError(errorResponse))
            .Returns(true);
        _mockResponseProcessor.Setup(x => x.ExtractErrorMessage(errorResponse))
            .Returns("Post not found");

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.GetRandomPost());
        Assert.That(exception.Message, Is.EqualTo("Post not found"));
    }
    
    [Test]
    public void GetRandomPost_DeserializationError_ReturnsFormattedJsonResponse()
    {
        // Arrange
        var invalidJsonResponse = "{\"invalid_json_structure\"}";
        _mockRequestService.Setup(x => x.FetchData(It.IsAny<string>(), null))
            .Returns(invalidJsonResponse);
        _mockResponseProcessor.Setup(x => x.HasError(invalidJsonResponse)).Returns(false);
        _mockResponseProcessor.Setup(x => x.FormatJsonResponse(invalidJsonResponse))
            .Returns("Formatted error: " + invalidJsonResponse);

        // Act
        var result = _serverRequestService.GetRandomPost();

        // Assert
        Assert.That(result, Is.EqualTo("Formatted error: " + invalidJsonResponse));
    }
    
    [Test]
    public void GetCatFact_ErrorResponse_ThrowsException()
    {
        // Arrange
        var errorResponse = "{\"error\":\"Fact not found\"}";
        _mockRequestService.Setup(x => x.FetchData(It.IsAny<string>(), null))
            .Returns(errorResponse);
        _mockResponseProcessor.Setup(x => x.HasError(errorResponse))
            .Returns(true);
        _mockResponseProcessor.Setup(x => x.ExtractErrorMessage(errorResponse))
            .Returns("Fact not found");

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.GetCatFact());
        Assert.That(exception.Message, Is.EqualTo("Fact not found"));
    }
    
    [Test]
    public void GetRandomPostAsync_ErrorResponse_ThrowsException()
    {
        // Arrange
        var errorResponse = "{\"error\":\"Async Post not found\"}";
        _mockRequestService.Setup(x => x.FetchDataAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
            .ReturnsAsync(errorResponse);
        _mockResponseProcessor.Setup(x => x.HasError(errorResponse)).Returns(true);
        _mockResponseProcessor.Setup(x => x.ExtractErrorMessage(errorResponse)).Returns("Async Post error");

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(async () => await _serverRequestService.GetRandomPostAsync());
        Assert.That(ex.Message, Is.EqualTo("Async Post error"));
    }
    
    [Test]
    public void GetCatFactAsync_ErrorResponse_ThrowsException()
    {
        // Arrange
        var errorResponse = "{\"error\":\"Async Fact not found\"}";
        _mockRequestService.Setup(x => x.FetchDataAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
            .ReturnsAsync(errorResponse);
        _mockResponseProcessor.Setup(x => x.HasError(errorResponse)).Returns(true);
        _mockResponseProcessor.Setup(x => x.ExtractErrorMessage(errorResponse)).Returns("Async Fact error");

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(async () => await _serverRequestService.GetCatFactAsync());
        Assert.That(ex.Message, Is.EqualTo("Async Fact error"));
    }


    [Test]
    public async Task GetCatFactAsync_CancellationRequested_ThrowsOperationCanceledException()
    {
        // Arrange
        using var cts = new CancellationTokenSource();
        
        _mockRequestService.Setup(x => x.FetchDataAsync(It.IsAny<string>(), null, cts.Token))
            .ThrowsAsync(new OperationCanceledException(cts.Token));

        cts.Cancel();

        // Act & Assert
        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await _serverRequestService.GetCatFactAsync(cts.Token));
    }


    [Test]
    public async Task GetWeatherInfoAsync_CancellationRequested_ThrowsOperationCanceledException()
    {
        // Arrange
        var city = "CancelledCity";
        using var cts = new CancellationTokenSource();

        _mockRequestService.Setup(x => x.FetchDataAsync(
                It.Is<string>(s => s.Contains($"q={city}")), null, cts.Token))
            .ThrowsAsync(new OperationCanceledException(cts.Token));

        cts.Cancel();

        // Act & Assert
        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await _serverRequestService.GetWeatherInfoAsync(city, cts.Token));
    }
}