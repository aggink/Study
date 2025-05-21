using NUnit.Framework;
using Study.Lab2.Logic.Selestz;
using Study.Lab2.Logic.Selestz.DtoModels;
using System;
using System.Text.Json;
using Study.Lab2.Logic.UnitTests.Selestz.DtoModels;

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
    public void FormatJsonResponse_ValidJson_ReturnsDeserializedObject()
    {
        // Arrange
        const string json = """{"Name":"John","Age":30}""";

        // Act
        var result = _processor.FormatJsonResponse<ApiTestDto>(json);

        // Assert
        Assert.That(result.Name, Is.EqualTo("John"));
        Assert.That(result.Age, Is.EqualTo(30));
    }

    [Test]
    public void FormatJsonResponse_InvalidJson_ThrowsException()
    {
        // Arrange
        const string invalidJson = "{invalid}";

        // Act & Assert
        Assert.Throws<Exception>(() => _processor.FormatJsonResponse<ApiTestDto>(invalidJson));
    }

    [Test]
    public void FormatJsonResponse_EmptyResponse_ThrowsException()
    {
        // Arrange
        const string emptyJson = "";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _processor.FormatJsonResponse<ApiTestDto>(emptyJson));
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