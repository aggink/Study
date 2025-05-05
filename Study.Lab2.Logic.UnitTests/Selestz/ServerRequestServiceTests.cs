using Moq;
using NUnit.Framework;
using Study.Lab2.Logic.Interfaces.Selestz;
using Study.Lab2.Logic.Selestz;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.Selestz;

[TestFixture]
public class ServerRequestServiceTests
{
    private Mock<IRequestService> _requestServiceMock;
    private ServerRequestService _serverRequestService;
    private readonly IResponseProcessor _responseProcessor = new ResponseProcessor();

    // Тестовые данные
    private const string ValidUserJson = "{\"id\":1,\"name\":\"John\",\"email\":\"john@example.com\"}";
    private const string ErrorJson = "{\"error\":\"Not found\"}";

    [SetUp]
    public void Setup()
    {
        _requestServiceMock = new Mock<IRequestService>();
        _serverRequestService = new ServerRequestService(
            _requestServiceMock.Object,
            _responseProcessor);
    }

    [Test]
    public void GetRandomUser_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        SetupRequestMock(ValidUserJson);

        // Act
        var result = _serverRequestService.GetRandomUser();

        // Assert
        AssertValidJsonResponse(result, "John");
    }

    [Test]
    public void GetRandomUser_ErrorResponse_ThrowsException()
    {
        // Arrange
        SetupRequestMock(ErrorJson);

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _serverRequestService.GetRandomUser());
        Assert.AreEqual("Not found", ex.Message);
    }

    [Test]
    public async Task GetRandomUserAsync_ValidResponse_ReturnsFormattedJson()
    {
        // Arrange
        SetupAsyncRequestMock(ValidUserJson);

        // Act
        var result = await _serverRequestService.GetRandomUserAsync();

        // Assert
        AssertValidJsonResponse(result, "John");
    }


    [TearDown]
    public void Cleanup()
    {
        _serverRequestService.Dispose();
    }


    private void SetupRequestMock(string response)
    {
        _requestServiceMock.Setup(x => x.FetchData(
            It.IsAny<string>(),
            It.IsAny<Dictionary<string, string>>()))
            .Returns(response);
    }

    private void SetupAsyncRequestMock(string response)
    {
        _requestServiceMock.Setup(x => x.FetchDataAsync(
            It.IsAny<string>(),
            null,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);
    }

    private static void AssertValidJsonResponse(string result, string expectedContent)
    {
        Assert.IsFalse(string.IsNullOrEmpty(result));
        Assert.DoesNotThrow(() => JsonDocument.Parse(result));
        Assert.IsTrue(result.Contains(expectedContent));
    }
}