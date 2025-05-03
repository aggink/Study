using Moq;
using Study.Lab2.Logic.Interfaces.xynthh;
using Study.Lab2.Logic.xynthh;

namespace Study.Lab2.Logic.UnitTests.xynthh;

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
        const int userId = TestData.JsonPlaceholderTestUserId;
        const string rawResponse = TestData.JsonPlaceholderUserResponse;
        const string formattedResponse = TestData.JsonPlaceholderUserFormatted;
        var expectedUrl = TestData.GetJsonPlaceholderUserUrl(userId);

        _mockRequestService.Setup(s => s.FetchData(expectedUrl, null))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = _serverRequestService.GetJsonPlaceholderUser(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchData(expectedUrl, null), Times.Once);
    }

    [Test]
    public void GetJsonPlaceholderUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        const int userId = TestData.NonExistentUserId;
        const string rawResponse = TestData.NotFoundErrorResponseJson;
        const string errorMessage = TestData.NotFoundErrorMessage;
        var expectedUrl = TestData.GetJsonPlaceholderUserUrl(userId);

        _mockRequestService.Setup(s => s.FetchData(expectedUrl, null))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.ExtractErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.GetJsonPlaceholderUser(userId));
        if (exception != null) Assert.That(exception.Message, Is.EqualTo(errorMessage));
        _mockRequestService.Verify(s => s.FetchData(expectedUrl, null), Times.Once);
    }

    [Test]
    public void GetReqResUser_UsesCorrectApiKey_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = TestData.ReqResTestUserId;
        const string rawResponse = TestData.ReqResUserResponseRaw;
        const string formattedResponse = TestData.ReqResUserFormatted;
        var expectedUrl = TestData.GetReqResUserUrl(userId);
        var expectedHeaders = TestData.ReqResHeaders;

        _mockRequestService.Setup(s => s.FetchData(expectedUrl, expectedHeaders))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = _serverRequestService.GetReqResUser(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchData(expectedUrl, expectedHeaders), Times.Once);
    }

    [Test]
    public void GetReqResUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        const int userId = TestData.NonExistentUserId;
        const string rawResponse = TestData.UserNotFoundErrorResponseJson;
        const string errorMessage = TestData.UserNotFoundErrorMessage;
        var expectedUrl = TestData.GetReqResUserUrl(userId);
        var expectedHeaders = TestData.ReqResHeaders;

        _mockRequestService.Setup(s => s.FetchData(expectedUrl, expectedHeaders))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.ExtractErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.GetReqResUser(userId));
        if (exception != null) Assert.That(exception.Message, Is.EqualTo(errorMessage));
        _mockRequestService.Verify(s => s.FetchData(expectedUrl, expectedHeaders), Times.Once);
    }

    [Test]
    public void GetJsonPlaceholderPost_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        const int postId = TestData.JsonPlaceholderTestPostId;
        const string rawResponse = TestData.JsonPlaceholderPostResponse;
        const string formattedResponse = TestData.JsonPlaceholderPostFormatted;
        var expectedUrl = TestData.GetJsonPlaceholderPostUrl(postId);

        _mockRequestService.Setup(s => s.FetchData(expectedUrl, null))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = _serverRequestService.GetJsonPlaceholderPost(postId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchData(expectedUrl, null), Times.Once);
    }

    [Test]
    public async Task GetJsonPlaceholderUserAsync_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = TestData.JsonPlaceholderTestUserId;
        const string rawResponse = TestData.JsonPlaceholderUserResponse;
        const string formattedResponse = TestData.JsonPlaceholderUserFormatted;
        var expectedUrl = TestData.GetJsonPlaceholderUserUrl(userId);

        _mockRequestService.Setup(s => s.FetchDataAsync(
                expectedUrl,
                null,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = await _serverRequestService.GetJsonPlaceholderUserAsync(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchDataAsync(
                expectedUrl,
                null,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task GetReqResUserAsync_UsesCorrectApiKey_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = TestData.ReqResTestUserId;
        const string rawResponse = TestData.ReqResUserResponseRaw;
        const string formattedResponse = TestData.ReqResUserFormatted;
        var expectedUrl = TestData.GetReqResUserUrl(userId);
        var expectedHeaders = TestData.ReqResHeaders;

        _mockRequestService.Setup(s => s.FetchDataAsync(
                expectedUrl,
                expectedHeaders,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = await _serverRequestService.GetReqResUserAsync(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchDataAsync(
                expectedUrl,
                expectedHeaders,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task GetJsonPlaceholderPostAsync_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        const int postId = TestData.JsonPlaceholderTestPostId;
        const string rawResponse = TestData.JsonPlaceholderPostResponse;
        const string formattedResponse = TestData.JsonPlaceholderPostFormatted;
        var expectedUrl = TestData.GetJsonPlaceholderPostUrl(postId);

        _mockRequestService.Setup(s => s.FetchDataAsync(
                expectedUrl,
                null,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = await _serverRequestService.GetJsonPlaceholderPostAsync(postId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchDataAsync(
                expectedUrl,
                null,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task GetJsonPlaceholderUserAsync_ErrorResponse_ThrowsException() // Пример для async ошибки
    {
        // Arrange
        const int userId = TestData.NonExistentUserId;
        const string rawResponse = TestData.NotFoundErrorResponseJson;
        const string errorMessage = TestData.NotFoundErrorMessage;
        var expectedUrl = TestData.GetJsonPlaceholderUserUrl(userId);

        _mockRequestService.Setup(s => s.FetchDataAsync(
                expectedUrl,
                null,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.ExtractErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () =>
            await _serverRequestService.GetJsonPlaceholderUserAsync(userId));
        if (exception != null) Assert.That(exception.Message, Is.EqualTo(errorMessage));
        _mockRequestService.Verify(s => s.FetchDataAsync(
                expectedUrl,
                null,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [TearDown]
    public void TearDown()
    {
        _serverRequestService?.Dispose();
    }
}