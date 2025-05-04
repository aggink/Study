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
        const string mockResponse = "{\"name\":\"John\"}";
        const string formattedResponse = "{\n  \"name\": \"John\"\n}";

        _requestServiceMock.Setup(x => x.FetchData(
            It.IsAny<string>(),
            It.IsAny<Dictionary<string, string>>()))
            .Returns(mockResponse);

        _responseProcessorMock.Setup(x => x.HasError(mockResponse))
            .Returns(false);
        _responseProcessorMock.Setup(x => x.FormatJsonResponse(mockResponse))
            .Returns(formattedResponse);

        // Act
        var result = _serverRequestService.GetRandomUser();

        // Assert
        Assert.AreEqual(formattedResponse, result);
    }

    [Test]
    public void GetRandomUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        const string errorResponse = "{\"error\":\"Not found\"}";

        _requestServiceMock.Setup(x => x.FetchData(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                    .Returns(errorResponse);
        _responseProcessorMock.Setup(x => x.HasError(errorResponse))
            .Returns(true);
        _responseProcessorMock.Setup(x => x.ExtractErrorMessage(errorResponse))
            .Returns("Not found");

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _serverRequestService.GetRandomUser());
        Assert.AreEqual("Not found", ex.Message);
    }

    [Test]
    public async Task GetRandomUserAsync_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        const string mockResponse = "{\"name\":\"John\"}";
        const string formattedResponse = "{\n  \"name\": \"John\"\n}";

        _requestServiceMock.Setup(x => x.FetchDataAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockResponse);
        _responseProcessorMock.Setup(x => x.HasError(mockResponse))
            .Returns(false);
        _responseProcessorMock.Setup(x => x.FormatJsonResponse(mockResponse))
            .Returns(formattedResponse);

        // Act
        var result = await _serverRequestService.GetRandomUserAsync();

        // Assert
        Assert.AreEqual(formattedResponse, result);
    }

    [TearDown]
    public void Cleanup()
    {
        _serverRequestService.Dispose();
    }
}