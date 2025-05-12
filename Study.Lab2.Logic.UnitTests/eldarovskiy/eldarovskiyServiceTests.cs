using System;
using System.IO; // ← добавь в using
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Study.Lab2.Logic.eldarovskiy;
using Study.Lab2.Logic.Interfaces.eldarovskiy;

namespace Study.Lab2.Logic.UnitTests.eldarovskiy;

[TestFixture]
public class eldarovskiyServiceTests
{
    private Mock<IRequestService> _requestMock;
    private eldarovskiyService _service;
    private readonly string[] _urls = new[]
    {
        "http://mock.weather.api",
        "http://mock.nasa.api",
        "http://mock.university.api",
    };

    [SetUp]
    public void Setup()
    {
        _requestMock = new Mock<IRequestService>();
        _service = (eldarovskiyService)
            System.Runtime.Serialization.FormatterServices.GetUninitializedObject(
                typeof(eldarovskiyService)
            );

        SetPrivateField("_requestHandler", _requestMock.Object);
        SetPrivateField("_apiUrls", _urls);
    }

    [TearDown]
    public void TearDown()
    {
        _service.Dispose();
    }

    [Test]
    public void RunTask_Calls_FetchData_3_Times()
    {
        _requestMock.Setup(x => x.FetchData(It.IsAny<string>())).Returns("{ \"ok\": true }");
        _service.RunTask();

        foreach (var url in _urls)
        {
            _requestMock.Verify(x => x.FetchData(url), Times.Once);
        }
    }

    [Test]
    public async Task RunTaskAsync_Calls_FetchDataAsync_3_Times()
    {
        _requestMock
            .Setup(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("{ \"ok\": true }");

        await _service.RunTaskAsync();

        foreach (var url in _urls)
        {
            _requestMock.Verify(
                x => x.FetchDataAsync(url, It.IsAny<CancellationToken>()),
                Times.Once
            );
        }
    }

    [Test]
    public void RunTask_Throws_Exception_On_One_Request()
    {
        _requestMock.Setup(x => x.FetchData(_urls[0])).Returns("{ \"ok\": true }");
        _requestMock.Setup(x => x.FetchData(_urls[1])).Throws(new Exception("Network error"));
        _requestMock.Setup(x => x.FetchData(_urls[2])).Returns("{ \"ok\": true }");

        Assert.DoesNotThrow(() => _service.RunTask());
    }

    [Test]
    public async Task RunTaskAsync_Throws_Exception_On_One_Request()
    {
        _requestMock
            .Setup(x => x.FetchDataAsync(_urls[0], It.IsAny<CancellationToken>()))
            .ReturnsAsync("{ \"ok\": true }");

        _requestMock
            .Setup(x => x.FetchDataAsync(_urls[1], It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Timeout"));

        _requestMock
            .Setup(x => x.FetchDataAsync(_urls[2], It.IsAny<CancellationToken>()))
            .ReturnsAsync("{ \"ok\": true }");

        Assert.DoesNotThrowAsync(() => _service.RunTaskAsync());
    }

    [Test]
    public void RunTask_Handles_Empty_Responses()
    {
        _requestMock.Setup(x => x.FetchData(It.IsAny<string>())).Returns(string.Empty);
        _service.RunTask();

        foreach (var url in _urls)
        {
            _requestMock.Verify(x => x.FetchData(url), Times.Once);
        }
    }

    [Test]
    public async Task RunTaskAsync_Handles_Empty_Responses()
    {
        _requestMock
            .Setup(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);

        await _service.RunTaskAsync();

        foreach (var url in _urls)
        {
            _requestMock.Verify(
                x => x.FetchDataAsync(url, It.IsAny<CancellationToken>()),
                Times.Once
            );
        }
    }

    [Test]
    public async Task RunTaskAsync_Respects_CancellationToken()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        _requestMock
            .Setup(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new TaskCanceledException());

        Assert.DoesNotThrowAsync(async () => await _service.RunTaskAsync(cts.Token));
    }

    [Test]
    public void RunTask_Exception_Should_Not_Stop_Dispose()
    {
        _requestMock.Setup(x => x.FetchData(It.IsAny<string>())).Throws(new Exception("error"));

        Assert.DoesNotThrow(() => _service.RunTask());
        Assert.DoesNotThrow(() => _service.Dispose());
    }

    private void SetPrivateField(string name, object value)
    {
        var field = typeof(eldarovskiyService).GetField(
            name,
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
        );

        field?.SetValue(_service, value);
    }
}
