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
        const int userId = 1;
        const string rawResponse = "{\"id\":1,\"name\":\"User\"}";
        const string formattedResponse = "{\n  \"id\": 1,\n  \"name\": \"User\"\n}";

        _mockRequestService.Setup(s => s.FetchData(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = _serverRequestService.GetJsonPlaceholderUser(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchData(
                It.Is<string>(url => url.Contains("/users/1")),
                null),
            Times.Once);
    }

    [Test]
    public void GetJsonPlaceholderUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        const int userId = 1;
        const string rawResponse = "{\"error\":\"Not found\"}";
        const string errorMessage = "Not found";

        _mockRequestService.Setup(s => s.FetchData(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.ExtractErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.GetJsonPlaceholderUser(userId));
        if (exception != null) Assert.That(exception.Message, Is.EqualTo(errorMessage));
    }

    [Test]
    public void GetReqResUser_UsesCorrectApiKey_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = 2;
        const string rawResponse = "{\"data\":{\"id\":2,\"name\":\"Janet\"}}";
        const string formattedResponse = "{\n  \"data\": {\n    \"id\": 2,\n    \"name\": \"Janet\"\n  }\n}";

        _mockRequestService.Setup(s => s.FetchData(
            It.IsAny<string>(),
            It.Is<Dictionary<string, string>>(d =>
                d != null && d.ContainsKey("x-api-key") && d["x-api-key"] == "reqres-free-v1")
        )).Returns(rawResponse);

        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = _serverRequestService.GetReqResUser(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchData(
                It.Is<string>(url => url.Contains("/users/2")),
                It.Is<Dictionary<string, string>>(d =>
                    d != null && d.ContainsKey("x-api-key") && d["x-api-key"] == "reqres-free-v1")),
            Times.Once);
    }

    [Test]
    public void GetReqResUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        const int userId = 999; // Несуществующий ID
        const string rawResponse = "{\"error\":\"User not found\"}";
        const string errorMessage = "User not found";

        _mockRequestService.Setup(s => s.FetchData(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.ExtractErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _serverRequestService.GetReqResUser(userId));
        if (exception != null) Assert.That(exception.Message, Is.EqualTo(errorMessage));
    }

    [Test]
    public void GetJsonPlaceholderPost_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        const int postId = 1;
        const string rawResponse = "{\"id\":1,\"title\":\"Post Title\",\"body\":\"Post body\"}";
        const string formattedResponse = "{\n  \"id\": 1,\n  \"title\": \"Post Title\",\n  \"body\": \"Post body\"\n}";

        _mockRequestService.Setup(s => s.FetchData(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
            .Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = _serverRequestService.GetJsonPlaceholderPost(postId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchData(
                It.Is<string>(url => url.Contains("/posts/1")),
                null),
            Times.Once);
    }

    [Test]
    public async Task GetJsonPlaceholderUserAsync_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = 1;
        const string rawResponse = "{\"id\":1,\"name\":\"User\"}";
        const string formattedResponse = "{\n  \"id\": 1,\n  \"name\": \"User\"\n}";

        _mockRequestService.Setup(s => s.FetchDataAsync(
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);

        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = await _serverRequestService.GetJsonPlaceholderUserAsync(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchDataAsync(
                It.Is<string>(url => url.Contains("/users/1")),
                null,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task GetReqResUserAsync_UsesCorrectApiKey_ReturnsFormattedJson()
    {
        // Arrange
        const int userId = 2;
        const string rawResponse = "{\"data\":{\"id\":2,\"name\":\"Janet\"}}";
        const string formattedResponse = "{\n  \"data\": {\n    \"id\": 2,\n    \"name\": \"Janet\"\n  }\n}";

        _mockRequestService.Setup(s => s.FetchDataAsync(
                It.IsAny<string>(),
                It.Is<Dictionary<string, string>>(d =>
                    d != null && d.ContainsKey("x-api-key") && d["x-api-key"] == "reqres-free-v1"),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);

        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = await _serverRequestService.GetReqResUserAsync(userId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchDataAsync(
                It.Is<string>(url => url.Contains("/users/2")),
                It.Is<Dictionary<string, string>>(d =>
                    d != null && d.ContainsKey("x-api-key") && d["x-api-key"] == "reqres-free-v1"),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task GetJsonPlaceholderPostAsync_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        const int postId = 1;
        const string rawResponse = "{\"id\":1,\"title\":\"Post Title\",\"body\":\"Post body\"}";
        const string formattedResponse = "{\n  \"id\": 1,\n  \"title\": \"Post Title\",\n  \"body\": \"Post body\"\n}";

        _mockRequestService.Setup(s => s.FetchDataAsync(
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);

        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(false);
        _mockResponseProcessor.Setup(p => p.FormatJsonResponse(rawResponse)).Returns(formattedResponse);

        // Act
        var result = await _serverRequestService.GetJsonPlaceholderPostAsync(postId);

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchDataAsync(
                It.Is<string>(url => url.Contains("/posts/1")),
                null,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public Task GetJsonPlaceholderUserAsync_ErrorResponse_ThrowsException()
    {
        // Arrange
        const int userId = 999; // Несуществующий ID
        const string rawResponse = "{\"error\":\"User not found\"}";
        const string errorMessage = "User not found";

        _mockRequestService.Setup(s => s.FetchDataAsync(
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);

        _mockResponseProcessor.Setup(p => p.HasError(rawResponse)).Returns(true);
        _mockResponseProcessor.Setup(p => p.ExtractErrorMessage(rawResponse)).Returns(errorMessage);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () =>
            await _serverRequestService.GetJsonPlaceholderUserAsync(userId));
        if (exception != null) Assert.That(exception.Message, Is.EqualTo(errorMessage));
        return Task.CompletedTask;
    }

    [TearDown]
    public void TearDown()
    {
        _serverRequestService?.Dispose();
    }
}