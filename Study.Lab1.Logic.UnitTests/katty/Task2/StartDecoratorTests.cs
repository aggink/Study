using Study.Lab1.Logic.Interfaces.katty.Task2;
using Study.Lab1.Logic.katty.Task2;

namespace Study.Lab1.Logic.UnitTests.katty.Task2;

[TestFixture]
public class StartDecoratorTests
{
    [Test]
    public void StartDecorator_ShouldAddPrefixToEuropeanFormatter()
    {
        // Arrange
        IDateTimeFormatter formatter = new EuropeanDateTimeFormatter();
        formatter = new StartDecorator(formatter, "Европейский формат: ");
        var testDateTime = new DateTime(2023, 4, 5, 15, 30, 45);

        // Act
        string result = formatter.FormatDateTime(testDateTime);

        // Assert
        Assert.That(result, Is.EqualTo("Европейский формат: 05.04.2023 15:30:45"));
    }

    [Test]
    public void StartDecorator_ShouldAddPrefixToAmericanFormatter()
    {
        // Arrange
        IDateTimeFormatter formatter = new AmericanDateTimeFormatter();
        formatter = new StartDecorator(formatter, "Американский формат: ");
        var testDateTime = new DateTime(2023, 4, 5, 15, 30, 45);

        // Act
        string result = formatter.FormatDateTime(testDateTime);

        // Assert
        Assert.That(result, Is.EqualTo("Американский формат: 4/5/2023 3:30:45 PM"));
    }
}