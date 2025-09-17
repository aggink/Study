using Moq;
using Study.Lab2.Logic.Interfaces.kinkiss1;
using Study.Lab2.Logic.kinkiss1;

namespace Study.Lab2.Logic.UnitTests.kinkiss1;

[TestFixture]
public class ServerRequestServiceTests
{
    private Mock<IRequestService> _mockRequestService;
    private IResponseProcessor _responseProcessor;
    private IServerRequestService _serverRequestService;

    [SetUp]
    public void Setup()
    {
        _mockRequestService = new Mock<IRequestService>();
        _responseProcessor = new ResponseProcessor(); // Создаём реальный объект
        _serverRequestService = new ServerRequestService(_mockRequestService.Object, _responseProcessor);
    }

    [TearDown]
    public void TearDown()
    {
        _serverRequestService?.Dispose();
    }

    [Test]
    public void CatGetFacts_ErrorResponse_ReturnsFormattedJson()
    {
        var url = ApiTestData.GetCatFactsUrl();
        var rawResponse = ApiTestData.CatFactsResponse;

        _mockRequestService.Setup(s => s.FetchData(url, null)).Returns(rawResponse);

        _mockRequestService
            .Setup(s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com")), null))
            .Throws(new Exception("Translation error"));

        var result = _serverRequestService.CatGetFacts();

        Assert.That(result, Does.Contain("fact"));
        _mockRequestService.Verify(s => s.FetchData(url, null), Times.Once);
    }

    [Test]
    public async Task CatGetFactsAsync_ErrorResponse_ReturnsFormattedJson()
    {
        var url = ApiTestData.GetCatFactsUrl();
        var rawResponse = ApiTestData.CatFactsResponse;

        _mockRequestService
            .Setup(s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);

        _mockRequestService
            .Setup(s => s.FetchDataAsync(
                It.Is<string>(u => u.Contains("translate.googleapis.com")),
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Translation error"));

        var result = await _serverRequestService.CatGetFactsAsync();

        Assert.That(result, Does.Contain("fact"));
        _mockRequestService.Verify(
            s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public void KanyeRest_RequestError_ThrowsException()
    {
        var url = ApiTestData.GetKanyeRestUrl();

        _mockRequestService
            .Setup(s => s.FetchData(url, null))
            .Throws(new HttpRequestException("Error request"));

        var exception = Assert.Throws<HttpRequestException>(() => _serverRequestService.KanyeRest());
        StringAssert.Contains("Error request", exception.Message);
    }

    [Test]
    public async Task CatGetFactsAsync_CancellationRequested_ThrowsOperationCanceledException()
    {
        var url = ApiTestData.GetCatFactsUrl();
        using var cts = new CancellationTokenSource();
        var token = cts.Token;

        _mockRequestService
            .Setup(s => s.FetchDataAsync(url, token))
            .Callback(() => cts.Cancel())
            .ThrowsAsync(new TaskCanceledException("The operation was canceled.", new OperationCanceledException(token)));

        var exception = Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await _serverRequestService.CatGetFactsAsync(token));

        Assert.That(exception.CancellationToken, Is.EqualTo(token));
    }

    [Test]
    public async Task KanyeRestAsync_NetworkError_ThrowsHttpRequestException()
    {
        var url = ApiTestData.GetKanyeRestUrl();

        _mockRequestService
            .Setup(s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new HttpRequestException("Network error API"));

        var exception = Assert.ThrowsAsync<HttpRequestException>(async () =>
            await _serverRequestService.KanyeRestAsync());

        StringAssert.Contains("Network error", exception.Message);
    }
}