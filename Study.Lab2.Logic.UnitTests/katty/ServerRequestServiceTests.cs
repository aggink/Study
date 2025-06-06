﻿using Moq;
using Study.Lab2.Logic.Interfaces.katty;
using Study.Lab2.Logic.katty;
using Study.Lab2.Logic.katty.DtoModels;

namespace Study.Lab2.Logic.UnitTests.katty;

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
        _serverRequestService.Dispose();
    }

    [Test]
    public void ExecuteRequests_SuccessfullyFulfilsRequestsWhenAllRequestsAreSuccessful()
    {
        // Arrange
        var urls = new[]
        {
            "https://jsonplaceholder.typicode.com/todos/1",
            "https://jsonplaceholder.typicode.com/posts/1",
            "https://jsonplaceholder.typicode.com/users/1"
        };

        var responses = new[]
        {
            @"{""userId"": 1, ""id"": 1, ""title"": ""Test"", ""completed"": false}",
            @"{""userId"": 1, ""id"": 1, ""title"": ""Post"", ""body"": ""Body""}",
            @"{""id"": 1, ""name"": ""User"", ""username"": ""User1"", ""email"": ""user@example.com""}"
        };

        var processedResponses = new[]
        {
            "{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"Test\",\n  \"completed\": false\n}",
            "{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"Post\",\n  \"body\": \"Body\"\n}",
            "{\n  \"id\": 1,\n  \"name\": \"User\",\n  \"username\": \"User1\",\n  \"email\": \"user@example.com\"\n}"
        };

        for (int i = 0; i < urls.Length; i++)
        {
            var url = urls[i];
            var response = responses[i];
            var processed = processedResponses[i];

            _mockRequestService.Setup(x => x.SendRequest(url)).Returns(response);

            switch (url)
            {
                case "https://jsonplaceholder.typicode.com/todos/1":
                    _mockResponseProcessor.Setup(x => x.IsSuccessResponse<TodoDto>(response)).Returns(true);
                    _mockResponseProcessor.Setup(x => x.ProcessResponse<TodoDto>(response)).Returns(processed);
                    break;
                case "https://jsonplaceholder.typicode.com/posts/1":
                    _mockResponseProcessor.Setup(x => x.IsSuccessResponse<PostDto>(response)).Returns(true);
                    _mockResponseProcessor.Setup(x => x.ProcessResponse<PostDto>(response)).Returns(processed);
                    break;
                case "https://jsonplaceholder.typicode.com/users/1":
                    _mockResponseProcessor.Setup(x => x.IsSuccessResponse<UserDto>(response)).Returns(true);
                    _mockResponseProcessor.Setup(x => x.ProcessResponse<UserDto>(response)).Returns(processed);
                    break;
            }
        }

        // Act
        var (responses1, _) = _serverRequestService.ExecuteRequests();

        // Assert
        Assert.AreEqual(urls.Length, responses1.Count, "Должно быть возвращено правильное количество ответов");
        for (int i = 0; i < urls.Length; i++)
        {
            Assert.IsTrue(responses1[i].Contains(processedResponses[i]), $"Ответ для {urls[i]} должен содержать отформатированный JSON");
        }

        // Verify
        foreach (var url in urls)
        {
            _mockRequestService.Verify(x => x.SendRequest(url), Times.Once());
            switch (url)
            {
                case "https://jsonplaceholder.typicode.com/todos/1":
                    _mockResponseProcessor.Verify(x => x.IsSuccessResponse<TodoDto>(It.IsAny<string>()), Times.Once());
                    _mockResponseProcessor.Verify(x => x.ProcessResponse<TodoDto>(It.IsAny<string>()), Times.Once());
                    break;
                case "https://jsonplaceholder.typicode.com/posts/1":
                    _mockResponseProcessor.Verify(x => x.IsSuccessResponse<PostDto>(It.IsAny<string>()), Times.Once());
                    _mockResponseProcessor.Verify(x => x.ProcessResponse<PostDto>(It.IsAny<string>()), Times.Once());
                    break;
                case "https://jsonplaceholder.typicode.com/users/1":
                    _mockResponseProcessor.Verify(x => x.IsSuccessResponse<UserDto>(It.IsAny<string>()), Times.Once());
                    _mockResponseProcessor.Verify(x => x.ProcessResponse<UserDto>(It.IsAny<string>()), Times.Once());
                    break;
            }
        }
    }

    [Test]
    public void ExecuteRequests_ThrowsExceptionWhenRequestFailed()
    {
        // Arrange
        var url = "https://jsonplaceholder.typicode.com/todos/1";
        var errorResponse = "Error: 404 Not Found";
        _mockRequestService.Setup(x => x.SendRequest(url)).Returns(errorResponse);
        _mockResponseProcessor.Setup(x => x.IsSuccessResponse<TodoDto>(errorResponse)).Returns(false);

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _serverRequestService.ExecuteRequests());
        Assert.That(ex.Message, Contains.Substring("Ошибка при выполнении запроса"));

        // Verify
        _mockRequestService.Verify(x => x.SendRequest(url), Times.Once());
        _mockResponseProcessor.Verify(x => x.IsSuccessResponse<TodoDto>(errorResponse), Times.Once());
        _mockResponseProcessor.Verify(x => x.ProcessResponse<TodoDto>(It.IsAny<string>()), Times.Never());
    }

    [Test]
    public async Task ExecuteRequestsAsync_SuccessfullyFulfilsRequestsWhenAllRequestsAreSuccessful()
    {
        // Arrange
        var urls = new[]
        {
            "https://jsonplaceholder.typicode.com/todos/1",
            "https://jsonplaceholder.typicode.com/posts/1",
            "https://jsonplaceholder.typicode.com/users/1"
        };

        var responses = new[]
        {
            @"{""userId"": 1, ""id"": 1, ""title"": ""Test"", ""completed"": false}",
            @"{""userId"": 1, ""id"": 1, ""title"": ""Post"", ""body"": ""Body""}",
            @"{""id"": 1, ""name"": ""User"", ""username"": ""User1"", ""email"": ""user@example.com""}"
        };

        var processedResponses = new[]
        {
            "{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"Test\",\n  \"completed\": false\n}",
            "{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"Post\",\n  \"body\": \"Body\"\n}",
            "{\n  \"id\": 1,\n  \"name\": \"User\",\n  \"username\": \"User1\",\n  \"email\": \"user@example.com\"\n}"
        };

        for (int i = 0; i < urls.Length; i++)
        {
            var url = urls[i];
            var response = responses[i];
            var processed = processedResponses[i];

            _mockRequestService.Setup(x => x.SendRequestAsync(url, It.IsAny<CancellationToken>())).ReturnsAsync(response);

            switch (url)
            {
                case "https://jsonplaceholder.typicode.com/todos/1":
                    _mockResponseProcessor.Setup(x => x.IsSuccessResponse<TodoDto>(response)).Returns(true);
                    _mockResponseProcessor.Setup(x => x.ProcessResponse<TodoDto>(response)).Returns(processed);
                    break;
                case "https://jsonplaceholder.typicode.com/posts/1":
                    _mockResponseProcessor.Setup(x => x.IsSuccessResponse<PostDto>(response)).Returns(true);
                    _mockResponseProcessor.Setup(x => x.ProcessResponse<PostDto>(response)).Returns(processed);
                    break;
                case "https://jsonplaceholder.typicode.com/users/1":
                    _mockResponseProcessor.Setup(x => x.IsSuccessResponse<UserDto>(response)).Returns(true);
                    _mockResponseProcessor.Setup(x => x.ProcessResponse<UserDto>(response)).Returns(processed);
                    break;
            }
        }

        // Act
        var (responsesResult, _) = await _serverRequestService.ExecuteRequestsAsync();

        // Assert
        Assert.AreEqual(urls.Length, responsesResult.Count, "Должно быть возвращено правильное количество ответов");
        for (int i = 0; i < urls.Length; i++)
        {
            Assert.IsTrue(responsesResult[i].Contains(processedResponses[i]), $"Ответ для {urls[i]} должен содержать отформатированный JSON");
        }

        // Verify
        foreach (var url in urls)
        {
            _mockRequestService.Verify(x => x.SendRequestAsync(url, It.IsAny<CancellationToken>()), Times.Once());
            switch (url)
            {
                case "https://jsonplaceholder.typicode.com/todos/1":
                    _mockResponseProcessor.Verify(x => x.IsSuccessResponse<TodoDto>(It.IsAny<string>()), Times.Once());
                    _mockResponseProcessor.Verify(x => x.ProcessResponse<TodoDto>(It.IsAny<string>()), Times.Once());
                    break;
                case "https://jsonplaceholder.typicode.com/posts/1":
                    _mockResponseProcessor.Verify(x => x.IsSuccessResponse<PostDto>(It.IsAny<string>()), Times.Once());
                    _mockResponseProcessor.Verify(x => x.ProcessResponse<PostDto>(It.IsAny<string>()), Times.Once());
                    break;
                case "https://jsonplaceholder.typicode.com/users/1":
                    _mockResponseProcessor.Verify(x => x.IsSuccessResponse<UserDto>(It.IsAny<string>()), Times.Once());
                    _mockResponseProcessor.Verify(x => x.ProcessResponse<UserDto>(It.IsAny<string>()), Times.Once());
                    break;
            }
        }
    }

    [Test]
    public void Dispose_OneTime()
    {
        // Act
        _serverRequestService.Dispose();

        // Assert & Verify
        Assert.DoesNotThrow(() => _serverRequestService.Dispose());
    }

    [Test]
    public void Constructor_ThrowExceptionWithNullValue()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new ServerRequestService(null, _mockResponseProcessor.Object));
        Assert.Throws<ArgumentNullException>(() => new ServerRequestService(_mockRequestService.Object, null));
    }
}