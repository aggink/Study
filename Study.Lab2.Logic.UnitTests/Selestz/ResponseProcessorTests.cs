using NUnit.Framework;
using Study.Lab2.Logic.Selestz;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.Selestz;

[TestFixture]
public class ResponseProcessorTests
{
    private ResponseProcessor _processor;

    [SetUp]
    public void Setup()
    {
        _processor = new ResponseProcessor();
    }

    [Test]
    public void FormatJsonResponse_ValidJson_ReturnsFormattedJson()
    {
        // Arrange
        const string json = "{\"name\":\"John\",\"age\":30}";

        // Act
        var result = _processor.FormatJsonResponse(json);

        // Assert
        Assert.DoesNotThrow(() => JsonDocument.Parse(result));
        StringAssert.Contains("\"name\": \"John\"", result);
        StringAssert.Contains("\"age\": 30", result);
    }

    [Test]
    public void FormatJsonResponse_InvalidJson_ReturnsErrorMessage()
    {
        // Arrange
        const string invalidJson = "{invalid}";

        // Act
        var result = _processor.FormatJsonResponse(invalidJson);

        // Assert
        StringAssert.StartsWith("Invalid JSON format", result);
    }

    [Test]
    public void HasError_ResponseWithError_ReturnsTrue()
    {
        // Arrange
        const string jsonWithError = "{\"error\":\"Not found\"}";

        // Act & Assert
        Assert.IsTrue(_processor.HasError(jsonWithError));
    }

    [Test]
    public void HasError_ValidResponse_ReturnsFalse()
    {
        // Arrange
        const string validJson = "{\"name\":\"John\"}";

        // Act & Assert
        Assert.IsFalse(_processor.HasError(validJson));
    }

    [Test]
    public void ExtractErrorMessage_ResponseWithError_ReturnsErrorMessage()
    {
        // Arrange
        const string jsonWithError = "{\"error\":\"Not found\"}";

        // Act & Assert
        Assert.AreEqual("Not found", _processor.ExtractErrorMessage(jsonWithError));
    }
}