using Moq;
using Study.Lab2.Logic.Interfaces.kinkiss1;
using Study.Lab2.Logic.kinkiss1;

namespace Study.Lab2.Logic.UnitTests.kinkiss1;

[TestFixture]
public class ServerRequestServiceTests
{
    private Mock<IRequestService>    _mockRequestService;
    private Mock<IResponseProcessor> _mockResponseProcessor;
    private ServerRequestService     _serverRequestService;

    [SetUp]
    public void Setup()
    {
        _mockRequestService = new Mock<IRequestService>();
        _mockResponseProcessor = new Mock<IResponseProcessor>();
        _serverRequestService = new ServerRequestService(_mockRequestService.Object, _mockResponseProcessor.Object);
    }
    
    [Test]
    public void GetJsonPlaceholderUser_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = ApiTestData.JsonPlaceholderTestUserId;
        const string rawResponse = ApiTestData.JsonPlaceholderUserResponse;
        const string formattedResponse = ApiTestData.JsonPlaceholderUserFormatted;
        var expectedUrl = ApiTestData.GetJsonPlaceholderUserUrl(userId);

        _mockRequestService.Setup(s => s.FetchSync(expectedUrl, null))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.Error(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonAnswers(rawResponse)).Returns(formattedResponse);

        // Act
        var result = _serverRequestService.JsonGetUser(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchSync(expectedUrl, null), Times.Once);
    }

    [Test]
    public void GetJsonPlaceholderUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        const int userId = ApiTestData.NonExistentUserId;
        const string rawResponse = ApiTestData.NotFoundErrorResponseJson;
        const string errorMessage = ApiTestData.NotFoundErrorMessage;
        var expectedUrl = ApiTestData.GetJsonPlaceholderUserUrl(userId);

        _mockRequestService.Setup(s => s.FetchSync(expectedUrl, null))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.Error(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.CocnlusionErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.JsonGetUser(userId));
        if (exception != null) Assert.That(exception.Message, Is.EqualTo(errorMessage));
        _mockRequestService.Verify(s => s.FetchSync(expectedUrl, null), Times.Once);
    }

    [Test]
    public void GetReqResUser_UsesCorrectApiKey_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = ApiTestData.ReqResTestUserId;
        const string rawResponse = ApiTestData.ReqResUserResponseRaw;
        const string formattedResponse = ApiTestData.ReqResUserFormatted;
        var expectedUrl = ApiTestData.GetReqResUserUrl(userId);
        var expectedHeaders = ApiTestData.ReqResHeaders;

        _mockRequestService.Setup(s => s.FetchSync(expectedUrl, expectedHeaders))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.Error(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonAnswers(rawResponse)).Returns(formattedResponse);

        // Act
        var result = _serverRequestService.ReqresGetUser(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchSync(expectedUrl, expectedHeaders), Times.Once);
    }

    [Test]
    public void CatGetFacts_ErrorResponse_ThrowsException()
    {
        // Arrange
        const string rawResponse = "{\"error\":\"Invalid request\"}";
        const string errorMessage = "Invalid request";
        var url = "https://catfact.ninja/fact";

        _mockRequestService.Setup(s => s.FetchSync(url, null)).Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.Error(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.CocnlusionErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.CatGetFacts());
        Assert.AreEqual(errorMessage, exception.Message);
        _mockRequestService.Verify(s => s.FetchSync(url, null), Times.Once);
    }
    
    [Test]
    public void GetReqResUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        const int userId = ApiTestData.NonExistentUserId;
        const string rawResponse = ApiTestData.UserNotFoundErrorResponseJson;
        const string errorMessage = ApiTestData.UserNotFoundErrorMessage;
        var expectedUrl = ApiTestData.GetReqResUserUrl(userId);
        var expectedHeaders = ApiTestData.ReqResHeaders;

        _mockRequestService.Setup(s => s.FetchSync(expectedUrl, expectedHeaders))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.Error(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.CocnlusionErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.ReqresGetUser(userId));
        if (exception != null) Assert.That(exception.Message, Is.EqualTo(errorMessage));
        _mockRequestService.Verify(s => s.FetchSync(expectedUrl, expectedHeaders), Times.Once);
    }
    
    [Test]
    public async Task GetReqResUserAsync_UsesCorrectApiKey_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = ApiTestData.ReqResTestUserId;
        const string rawResponse = ApiTestData.ReqResUserResponseRaw;
        const string formattedResponse = ApiTestData.ReqResUserFormatted;
        var expectedUrl = ApiTestData.GetReqResUserUrl(userId);
        var expectedHeaders = ApiTestData.ReqResHeaders;

        _mockRequestService.Setup(s => s.FetchAsync(
                expectedUrl,
                expectedHeaders,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.Error(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonAnswers(rawResponse)).Returns(formattedResponse);

        // Act
        var result = await _serverRequestService.ReqresGetUserAsync(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchAsync(
                expectedUrl,
                expectedHeaders,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
    
    [Test]
    public async Task CatGetFactsAsync_ErrorResponse_ThrowsException()
    {
        // Arrange
        const string rawResponse = "{\"error\":\"Invalid request\"}";
        const string errorMessage = "Invalid request";
        var url = "https://catfact.ninja/fact";

        _mockRequestService.Setup(s => s.FetchAsync(url, It.IsAny<Dictionary<string, string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.Error(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.CocnlusionErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => await _serverRequestService.CatGetFactsAsync());
        Assert.AreEqual(errorMessage, exception.Message);
        _mockRequestService.Verify(s => s.FetchAsync(url, It.IsAny<Dictionary<string, string>>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [TearDown]
    public void TearDown()
    {
        _serverRequestService?.Dispose();
    }
}