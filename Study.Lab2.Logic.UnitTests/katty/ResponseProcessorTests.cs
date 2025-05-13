using Study.Lab2.Logic.katty;
using Study.Lab2.Logic.katty.DTO;
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
    public void IsSuccessResponse_ВозвращаетTrue_ПриКорректномJSON()
    {
        // Arrange
        string response = @"{""userId"": 1, ""id"": 1, ""title"": ""Test"", ""completed"": false}";

        // Act
        bool result = _responseProcessor.IsSuccessResponse<TodoDto>(response);

        // Assert
        Assert.IsTrue(result, "Корректный JSON должен считаться успешным ответом");
    }

    [Test]
    public void IsSuccessResponse_ВозвращаетFalse_ПриНекорректномJSON()
    {
        // Arrange
        string response = "This is not a JSON";

        // Act
        bool result = _responseProcessor.IsSuccessResponse<TodoDto>(response);

        // Assert
        Assert.IsFalse(result, "Некорректный JSON должен считаться неуспешным ответом");
    }

    [Test]
    public void IsSuccessResponse_ВозвращаетFalse_ПриОшибкеВОтвете()
    {
        // Arrange
        string response = "Error: 404 - Not Found";

        // Act
        bool result = _responseProcessor.IsSuccessResponse<TodoDto>(response);

        // Assert
        Assert.IsFalse(result, "Ответ с ошибкой должен считаться неуспешным");
    }

    [Test]
    public void ProcessResponse_ФорматируетJSON_ПриКорректномJSON()
    {
        // Arrange
        string response = @"{""userId"": 1, ""id"": 1, ""title"": ""Test"", ""completed"": false}";
        var expectedDto = new TodoDto { UserId = 1, Id = 1, Title = "Test", Completed = false };
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
    public void ProcessResponse_ВозвращаетСообщениеОбОшибке_ПриНекорректномJSON()
    {
        // Arrange
        string response = "This is not a JSON";

        // Act
        string result = _responseProcessor.ProcessResponse<TodoDto>(response);

        // Assert
        Assert.IsTrue(result.Contains("Error: Неверный формат JSON"), "Должно вернуться сообщение об ошибке формата JSON");
    }

    [Test]
    public void ProcessResponse_СохраняетСообщениеОбОшибке_ИзОтвета()
    {
        // Arrange
        string response = "Error: 404 - Not Found";

        // Act
        string result = _responseProcessor.ProcessResponse<TodoDto>(response);

        // Assert
        Assert.AreEqual(response, result, "Сообщение об ошибке должно остаться неизменным");
    }
}