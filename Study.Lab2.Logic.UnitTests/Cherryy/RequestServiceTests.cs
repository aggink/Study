using Moq;
using Moq.Protected;
using Study.Lab2.Logic.Cherryy;
using Study.Lab2.Logic.Cherryy.DtoModels;
using Study.Lab2.Logic.Interfaces.Cherryy;
using System.Net;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.Cherryy;

[TestFixture]
public class RequestServiceTests
{
    private IRequestService _requestService;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;

    private const string REQUEST_URL = "https://api.github.com/users/octocat";

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [TearDown]
    public void TearDown()
    {
        _requestService?.Dispose();
    }

    [Test]
    public void FetchData_Success_ReturnsResponse()
    {
        // Arrange
        var user = GetUser();
        var json = JsonSerializer.Serialize(user);

        SetupMockResponse(HttpStatusCode.OK, REQUEST_URL, json);

        // Act
        var result = _requestService.FetchData(REQUEST_URL);

        // Assert
        Assert.AreEqual(json, result);

    }

    [Test]
    public void FetchData_HttpError_ThrowsException()
    {
        // Arrange
        var user = GetUser();
        var json = JsonSerializer.Serialize(user);

        SetupMockResponse(HttpStatusCode.BadRequest, REQUEST_URL, json);

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _requestService.FetchData(REQUEST_URL));
        Assert.That(ex.Message, Does.Contain("Ошибка при выполнении запроса к"));
    }

    private UserDto GetUser()
    {
        return new UserDto
        {
            Login = "student"
        };
    }

    private void SetupMockResponse(
        HttpStatusCode statusCode,
        string url,
        string content)
    {
        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == url),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });
    }
}