using System.Net;
using Moq;
using Moq.Protected;
using Study.Lab2.Logic.eduardvafin56;

namespace Study.Lab2.Logic.UnitTests.eduardvafin56;

[TestFixture]
public class RequestServiceTests
{
    private RequestService _requestService;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _requestService = new RequestService(httpClient);
    }

    [TearDown]
    public void Dispose()
    {
        _requestService?.Dispose();
    }
[Test]
    public void FetchData_Success_ReturnsPostResponse()
    {
        // Arrange
        var expectedResponse = """
        {
            "userId": 1,
            "id": 1,
            "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
            "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
        }
        """;
        var requestUrl = "https://jsonplaceholder.typicode.com/posts/1";

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
        Assert.That(result, Does.Contain("userId"));
        Assert.That(result, Does.Contain("title"));
    }

    [Test]
    public void FetchData_Success_ReturnsUserResponse()
    {
        // Arrange
        var expectedResponse = """
        {
            "id": 1,
            "name": "Leanne Graham",
            "username": "Bret",
            "email": "Sincere@april.biz"
        }
        """;
        var requestUrl = "https://jsonplaceholder.typicode.com/users/1";

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
        Assert.That(result, Does.Contain("Leanne Graham"));
        Assert.That(result, Does.Contain("Bret"));
    }

    [Test]
    public void FetchData_Success_ReturnsCommentResponse()
    {
        // Arrange
        var expectedResponse = """
        {
            "postId": 1,
            "id": 1,
            "name": "id labore ex et quam laborum",
            "email": "Eliseo@gardner.biz",
            "body": "laudantium enim quasi est quidem magnam voluptate ipsam eos\ntempora quo necessitatibus\ndolor quam autem quasi\nreiciendis et nam sapiente accusantium"
        }
        """;
        var requestUrl = "https://jsonplaceholder.typicode.com/comments/1";

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = _requestService.FetchData(requestUrl);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
        Assert.That(result, Does.Contain("postId"));
        Assert.That(result, Does.Contain("Eliseo@gardner.biz"));
    }

    [Test]
    public void FetchData_NotFound_ThrowsException()
    {
        // Arrange
        var requestUrl = "https://jsonplaceholder.typicode.com/posts/999999";
        SetupHttpResponse(requestUrl, "Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
        StringAssert.Contains("NotFound", exception.Message);
    }

    [Test]
    public void FetchData_BadRequest_ThrowsException()
    {
        // Arrange
        var requestUrl = "https://jsonplaceholder.typicode.com/invalid";
        SetupHttpResponse(requestUrl, "Bad Request", HttpStatusCode.BadRequest);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _requestService.FetchData(requestUrl));
        StringAssert.Contains("BadRequest", exception.Message);
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsPostResponse()
    {
        // Arrange
        var expectedResponse = """
        {
            "userId": 1,
            "id": 1,
            "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
            "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
        }
        """;
        var requestUrl = "https://jsonplaceholder.typicode.com/posts/1";
        using var cancellationTokenSource = new CancellationTokenSource();

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
        Assert.That(result, Does.Contain("userId"));
    }

    [Test]
    public async Task FetchDataAsync_Success_ReturnsUserResponse()
    {
        // Arrange
        var expectedResponse = """
        {
            "id": 1,
            "name": "Leanne Graham",
            "username": "Bret",
            "email": "Sincere@april.biz"
        }
        """;
        var requestUrl = "https://jsonplaceholder.typicode.com/users/1";
        using var cancellationTokenSource = new CancellationTokenSource();

        SetupHttpResponse(requestUrl, expectedResponse, HttpStatusCode.OK);

        // Act
        var result = await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
        Assert.That(result, Does.Contain("Leanne Graham"));
    }

    [Test]
    public void FetchDataAsync_NotFound_ThrowsException()
    {
        // Arrange
        var requestUrl = "https://jsonplaceholder.typicode.com/posts/999999";
        using var cancellationTokenSource = new CancellationTokenSource();
        SetupHttpResponse(requestUrl, "Not Found", HttpStatusCode.NotFound);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => 
            await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("NotFound", exception.Message);
    }

    [Test]
    public void FetchDataAsync_BadRequest_ThrowsException()
    {
        // Arrange
        var requestUrl = "https://jsonplaceholder.typicode.com/invalid";
        using var cancellationTokenSource = new CancellationTokenSource();
        SetupHttpResponse(requestUrl, "Bad Request", HttpStatusCode.BadRequest);

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => 
            await _requestService.FetchDataAsync(requestUrl, cancellationTokenSource.Token));
        StringAssert.Contains("BadRequest", exception.Message);
    }

    private void SetupHttpResponse(string url, string content, HttpStatusCode statusCode)
    {
        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == url),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });
    }
}
