using Moq;
using NUnit.Framework;
using Study.Lab2.Logic.Interfaces.Selestz;
using Study.Lab2.Logic.Selestz;

namespace Study.Lab2.Logic.UnitTests.Selestz;

[TestFixture]
public class ServerRequestServiceTests
{
    private Mock<IRequestService> _requestServiceMock;
    private Mock<IResponseProcessor> _responseProcessorMock;
    private ServerRequestService _serverRequestService;

    // Общие тестовые данные
    private const string MockResponse = "{\"name\":\"John\"}";
    private const string FormattedResponse = "{\n  \"name\": \"John\"\n}";
    private const string ErrorResponse = "{\"error\":\"Not found\"}";

    [SetUp]
    public void Setup()
    {
        _requestServiceMock = new Mock<IRequestService>();
        _responseProcessorMock = new Mock<IResponseProcessor>();
        _serverRequestService = new ServerRequestService(
            _requestServiceMock.Object,
            _responseProcessorMock.Object);
    }

    [Test]
    public void GetRandomUser_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        SetupMocksForSuccessResponse(MockResponse, FormattedResponse);

        // Act
        var result = _serverRequestService.GetRandomUser();

        // Assert
        Assert.AreEqual(FormattedResponse, result);
    }

    [Test]
    public void GetRandomUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        SetupMocksForErrorResponse(ErrorResponse, "Not found");

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _serverRequestService.GetRandomUser());
        Assert.AreEqual("Not found", ex.Message);
    }

    [Test]
    public async Task GetRandomUserAsync_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        SetupMocksForSuccessResponseAsync(MockResponse, FormattedResponse);

        // Act
        var result = await _serverRequestService.GetRandomUserAsync();

        // Assert
        Assert.AreEqual(FormattedResponse, result);
    }

    [Test]
    public async Task GetRandomUserAsync_ErrorResponse_ThrowsException()
    {
        // Arrange
        SetupMocksForErrorResponseAsync(ErrorResponse, "Not found");

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(async () =>
            await _serverRequestService.GetRandomUserAsync());
        Assert.AreEqual("Not found", ex.Message);
    }

    [TearDown]
    public void Cleanup()
    {
        _serverRequestService.Dispose();
    }


    private void SetupMocksForSuccessResponse(string response, string formattedResponse)
    {
        _requestServiceMock.Setup(x => x.FetchData(
            It.IsAny<string>(),
            It.IsAny<Dictionary<string, string>>()))
            .Returns(response);

        _responseProcessorMock.Setup(x => x.HasError(response))
            .Returns(false);
        _responseProcessorMock.Setup(x => x.FormatJsonResponse(response))
            .Returns(formattedResponse);
    }

    private void SetupMocksForSuccessResponseAsync(string response, string formattedResponse)
    {
        _requestServiceMock.Setup(x => x.FetchDataAsync(
            It.IsAny<string>(),
            null,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        _responseProcessorMock.Setup(x => x.HasError(response))
            .Returns(false);
        _responseProcessorMock.Setup(x => x.FormatJsonResponse(response))
            .Returns(formattedResponse);
    }

    private void SetupMocksForErrorResponse(string errorResponse, string errorMessage)
    {
        _requestServiceMock.Setup(x => x.FetchData(
            It.IsAny<string>(),
            It.IsAny<Dictionary<string, string>>()))
            .Returns(errorResponse);

        _responseProcessorMock.Setup(x => x.HasError(errorResponse))
            .Returns(true);
        _responseProcessorMock.Setup(x => x.ExtractErrorMessage(errorResponse))
            .Returns(errorMessage);
    }

    private void SetupMocksForErrorResponseAsync(string errorResponse, string errorMessage)
    {
        _requestServiceMock.Setup(x => x.FetchDataAsync(
            It.IsAny<string>(),
            null,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(errorResponse);

        _responseProcessorMock.Setup(x => x.HasError(errorResponse))
            .Returns(true);
        _responseProcessorMock.Setup(x => x.ExtractErrorMessage(errorResponse))
            .Returns(errorMessage);
    }
}