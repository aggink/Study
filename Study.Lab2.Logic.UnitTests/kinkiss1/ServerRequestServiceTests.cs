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

    [Test]
    public void CatGetFacts_SuccessfulResponse_ReturnsTranslatedData()
    {
        // Arrange
        var url = ApiTestData.GetCatFactsUrl();
        var rawResponse = ApiTestData.CatFactsResponse;
        var formattedResponse = ApiTestData.CatFactsWithTranslationFormatted;

        _mockRequestService.Setup(s => s.FetchData(url)).Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.FormatJson(rawResponse)).Returns(rawResponse);

        // Настраиваем мок для TranslateCatsSync
        _mockRequestService
            .Setup(s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com"))))
            .Returns(ApiTestData.GoogleTranslateCatFactResponse);

        // Act
        var result = _serverRequestService.CatGetFacts();

        // Assert
        Assert.That(result, Is.Not.Null);
        _mockRequestService.Verify(s => s.FetchData(url), Times.Once);
        // Проверяем, что был вызван запрос к Google Translate
        _mockRequestService.Verify(
            s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com"))),
            Times.Once);
    }

    [Test]
    public void KanyeRest_SuccessfulResponse_ReturnsTranslatedData()
    {
        // Arrange
        var url = ApiTestData.GetKanyeRestUrl();
        var rawResponse = ApiTestData.KanyeRestResponse;
        var formattedResponse = ApiTestData.KanyeRestWithTranslationFormatted;

        _mockRequestService.Setup(s => s.FetchData(url)).Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.FormatJson(rawResponse)).Returns(rawResponse);

        // Настраиваем мок для TranslateKanyeSync
        _mockRequestService
            .Setup(s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com"))))
            .Returns(ApiTestData.GoogleTranslateKanyeResponse);

        // Act
        var result = _serverRequestService.KanyeRest();

        // Assert
        Assert.That(result, Is.Not.Null);
        _mockRequestService.Verify(s => s.FetchData(url), Times.Once);
        // Проверяем, что был вызван запрос к Google Translate
        _mockRequestService.Verify(
            s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com"))),
            Times.Once);
    }

    [Test]
    public void CatGetFacts_ErrorResponse_ReturnsFormattedJson()
    {
        // Arrange
        var url = ApiTestData.GetCatFactsUrl();
        var rawResponse = ApiTestData.CatFactsResponse;
        var formattedResponse = ApiTestData.CatFactsResponse;  // В случае ошибки возвращается отформатированный исходный JSON

        _mockRequestService.Setup(s => s.FetchData(url)).Returns(rawResponse);
        _mockResponseProcessor.Setup(p => p.FormatJson(rawResponse)).Returns(formattedResponse);

        // Имитируем ошибку при переводе
        _mockRequestService
            .Setup(s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com"))))
            .Throws(new Exception("Translation error"));

        // Act
        var result = _serverRequestService.CatGetFacts();

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(s => s.FetchData(url), Times.Once);
    }

    [Test]
    public async Task CatGetFactsAsync_SuccessfulResponse_ReturnsTranslatedData()
    {
        // Arrange
        var url = ApiTestData.GetCatFactsUrl();
        var rawResponse = ApiTestData.CatFactsResponse;
        var formattedResponse = ApiTestData.CatFactsWithTranslationFormatted;

        _mockRequestService
            .Setup(s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.FormatJson(rawResponse)).Returns(rawResponse);

        // Настраиваем мок для TranslateCatsAsync
        _mockRequestService
            .Setup(s => s.FetchDataAsync(
                It.Is<string>(u => u.Contains("translate.googleapis.com")),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(ApiTestData.GoogleTranslateCatFactResponse);

        // Act
        var result = await _serverRequestService.CatGetFactsAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        _mockRequestService.Verify(
            s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()),
            Times.Once);
        // Проверяем, что был вызван запрос к Google Translate
        _mockRequestService.Verify(
            s => s.FetchDataAsync(
                It.Is<string>(u => u.Contains("translate.googleapis.com")),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task KanyeRestAsync_SuccessfulResponse_ReturnsTranslatedData()
    {
        // Arrange
        var url = ApiTestData.GetKanyeRestUrl();
        var rawResponse = ApiTestData.KanyeRestResponse;
        var formattedResponse = ApiTestData.KanyeRestWithTranslationFormatted;

        _mockRequestService
            .Setup(s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.FormatJson(rawResponse)).Returns(rawResponse);

        // Настраиваем мок для TranslateKanyeAsync
        _mockRequestService
            .Setup(s => s.FetchDataAsync(
                It.Is<string>(u => u.Contains("translate.googleapis.com")),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(ApiTestData.GoogleTranslateKanyeResponse);

        // Act
        var result = await _serverRequestService.KanyeRestAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        _mockRequestService.Verify(
            s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()),
            Times.Once);
        // Проверяем, что был вызван запрос к Google Translate
        _mockRequestService.Verify(
            s => s.FetchDataAsync(
                It.Is<string>(u => u.Contains("translate.googleapis.com")),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task CatGetFactsAsync_ErrorResponse_ReturnsFormattedJson()
    {
        // Arrange
        var url = ApiTestData.GetCatFactsUrl();
        var rawResponse = ApiTestData.CatFactsResponse;
        var formattedResponse = ApiTestData.CatFactsResponse;  // В случае ошибки возвращается отформатированный исходный JSON

        _mockRequestService
            .Setup(s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawResponse);
        _mockResponseProcessor.Setup(p => p.FormatJson(rawResponse)).Returns(formattedResponse);

        // Имитируем ошибку при переводе
        _mockRequestService
            .Setup(s => s.FetchDataAsync(
                It.Is<string>(u => u.Contains("translate.googleapis.com")),
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Translation error"));

        // Act
        var result = await _serverRequestService.CatGetFactsAsync();

        // Assert
        Assert.That(result, Is.EqualTo(formattedResponse));
        _mockRequestService.Verify(
            s => s.FetchDataAsync(url, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public void TranslateCatsSync_ValidJson_ReturnsTranslatedData()
    {
        // Arrange
        var jsonString = ApiTestData.CatFactsResponse;
        var googleTranslateResponse = ApiTestData.GoogleTranslateCatFactResponse;

        _mockRequestService
            .Setup(s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com"))))
            .Returns(googleTranslateResponse);

        // Act
        var result = _serverRequestService.TranslateCatsSync(jsonString);

        // Assert
        Assert.That(result, Does.Contain("перевод"));
        Assert.That(result, Does.Contain(ApiTestData.TranslatedCatFactText));
    }

    [Test]
    public void TranslateKanyeSync_ValidJson_ReturnsTranslatedData()
    {
        // Arrange
        var jsonString = ApiTestData.KanyeRestResponse;
        var googleTranslateResponse = ApiTestData.GoogleTranslateKanyeResponse;

        _mockRequestService
            .Setup(s => s.FetchData(It.Is<string>(u => u.Contains("translate.googleapis.com"))))
            .Returns(googleTranslateResponse);

        // Act
        var result = _serverRequestService.TranslateKanyeSync(jsonString);

        // Assert
        Assert.That(result, Does.Contain("перевод"));
        Assert.That(result, Does.Contain(ApiTestData.TranslatedKanyeQuoteText));
    }
}

