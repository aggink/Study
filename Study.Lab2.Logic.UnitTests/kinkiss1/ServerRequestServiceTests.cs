using Moq;
using Study.Lab2.Logic.Interfaces.kinkiss1;
using Study.Lab2.Logic.kinkiss1;

namespace Study.Lab2.Logic.UnitTests.kinkiss1;

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
        _serverRequestService?.Dispose();
    }

    [Test]
    public void CatGetFacts_ErrorResponse_ReturnsFormattedJson()
    {
        var url = ApiTestData.GetCatFactsUrl();
        var rawResponse = ApiTestData.CatFactsResponse;
        var formattedResponse = ApiTestData.CatFactsResponse;

        _mockRequestService.Setup(s => s.FetchData(url)).Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.FormatJson(rawResponse)).Returns(formattedResponse);

        _mockRequestService
            .Setup(s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com"))))
            .Throws(new Exception("Translation error"));

        var result = _serverRequestService.CatGetFacts();

        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchData(url), Times.Once);
    }

    [Test]
    public async Task CatGetFactsAsync_ErrorResponse_ReturnsFormattedJson()
    {
        var url = ApiTestData.GetCatFactsUrl();
        var rawResponse = ApiTestData.CatFactsResponse;
        var formattedResponse = ApiTestData.CatFactsResponse; 

        _mockRequestService
            .Setup(s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.FormatJson(rawResponse)).Returns(formattedResponse);

        _mockRequestService
            .Setup(s => s.FetchDataAsync(
                It.Is<string>(u => u.Contains("translate.googleapis.com")),
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Translation error"));

        var result = await _serverRequestService.CatGetFactsAsync();

        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(
            s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public void KanyeRest_RequestError_ThrowsException()
    {
        var url = ApiTestData.GetKanyeRestUrl();

        _mockRequestService
            .Setup(s => s.FetchData(url))
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
            .ThrowsAsync(new OperationCanceledException(token));

        var exception = Assert.ThrowsAsync<OperationCanceledException>(async () =>
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