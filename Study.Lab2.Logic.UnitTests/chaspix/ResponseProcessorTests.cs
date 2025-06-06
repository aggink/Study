using Moq;
using Study.Lab2.Logic.chaspix;
using Study.Lab2.Logic.Interfaces.chaspix;

namespace Study.Lab2.Logic.UnitTests.chaspix;

[TestFixture]
public class ResponseProcessorTests
{
    private ResponseProcessor _responseProcessor;

    [SetUp]
    public void Setup()
    {
        _responseProcessor = new ResponseProcessor();
    }

    [Test]
    public void FormatJsonResponse_ValidJson_ReturnsFormattedJson()
    {
        // Arrange
        var jsonResponse = "{\"name\":\"Test\",\"id\":123}";

        // Act
        var result = _responseProcessor.FormatJsonResponse(jsonResponse);

        // Assert
        Assert.That(result, Does.Contain("\"name\": \"Test\""));
        Assert.That(result, Does.Contain("\"id\": 123"));
        Assert.That(result.Contains('\n'), Is.True); // Проверяем что JSON отформатирован с отступами
    }

    [Test]
    public void FormatJsonResponse_InvalidJson_ReturnsErrorMessage()
    {
        // Arrange
        var invalidJson = "{invalid json}";

        // Act
        var result = _responseProcessor.FormatJsonResponse(invalidJson);

        // Assert
        Assert.That(result, Does.Contain("Некорректный JSON"));
    }

    [Test]
    public void FormatJsonResponse_EmptyString_ReturnsEmptyMessage()
    {
        // Arrange
        var emptyResponse = "";

        // Act
        var result = _responseProcessor.FormatJsonResponse(emptyResponse);

        // Assert
        Assert.That(result, Is.EqualTo("Пустой ответ"));
    }

    [Test]
    public void HasError_ResponseWithError_ReturnsTrue()
    {
        // Arrange
        var errorResponse = "{\"error\":\"Something went wrong\"}";

        // Act
        var result = _responseProcessor.HasError(errorResponse);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void HasError_ValidResponse_ReturnsFalse()
    {
        // Arrange
        var validResponse = "{\"data\":\"success\",\"status\":\"ok\"}";

        // Act
        var result = _responseProcessor.HasError(validResponse);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void ExtractErrorMessage_ResponseWithErrorField_ReturnsErrorMessage()
    {
        // Arrange
        var errorResponse = "{\"error\":\"Authentication failed\"}";

        // Act
        var result = _responseProcessor.ExtractErrorMessage(errorResponse);

        // Assert
        Assert.That(result, Is.EqualTo("Authentication failed"));
    }
}
