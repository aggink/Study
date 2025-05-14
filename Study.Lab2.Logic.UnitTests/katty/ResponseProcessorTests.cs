using Study.Lab2.Logic.katty;
using Study.Lab2.Logic.katty.Data;
using Study.Lab2.Logic.katty.DtoModels;
using System.Text.Json;

namespace Study.Lab2.Logic.UnitTests.katty;

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
    public void IsSuccessResponse_ReturnsTrueIfJSONIsValid()
    {
        // Arrange
        string response = KattyTestData.RawResponses[0];

        // Act
        bool result = _responseProcessor.IsSuccessResponse<TodoDto>(response);

        // Assert
        Assert.IsTrue(result, "Корректный JSON должен считаться успешным ответом");
    }

    [Test]
    public void IsSuccessResponse_ReturnsFalseIfJSONIsInvalid()
    {
        // Arrange
        string response = "This is not a JSON";

        // Act
        bool result = _responseProcessor.IsSuccessResponse<TodoDto>(response);

        // Assert
        Assert.IsFalse(result, "Некорректный JSON должен считаться неуспешным ответом");
    }

    [Test]
    public void IsSuccessResponse_ReturnsFalseOnErrorInAnswerе()
    {
        // Arrange
        string response = KattyTestData.ErrorResponse;

        // Act
        bool result = _responseProcessor.IsSuccessResponse<TodoDto>(response);

        // Assert
        Assert.IsFalse(result, "Ответ с ошибкой должен считаться неуспешным");
    }

    [Test]
    public void ProcessResponse_FormatJSONWithCorrectJSON()
    {
        // Arrange
        string response = KattyTestData.RawResponses[0];

        var expectedDto = new TodoDto(1, 1, "Test", false);
        string expected = JsonSerializer.Serialize(expectedDto, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        });

        // Act
        string result = _responseProcessor.ProcessResponse<TodoDto>(response);

        // Assert
        Assert.AreEqual(expected, result, "JSON должен быть правильно отформатирован");
    }

    [Test]
    public void ProcessResponse_ReturnsErrorMessageWhenJSONIsInvalid()
    {
        // Arrange
        string response = "This is not a JSON";

        // Act
        string result = _responseProcessor.ProcessResponse<TodoDto>(response);

        // Assert
        Assert.IsTrue(result.Contains("Error: Неверный формат JSON"), "Должно вернуться сообщение об ошибке формата JSON");
    }

    [Test]
    public void ProcessResponse_SavesErrorMessageFromResponse()
    {
        // Arrange
        string response = KattyTestData.ErrorResponse;

        // Act
        string result = _responseProcessor.ProcessResponse<TodoDto>(response);

        // Assert
        Assert.AreEqual(response, result, "Сообщение об ошибке должно остаться неизменным");
    }
}