using Study.Lab1.Logic.Interfaces.katty.Task2;
using Study.Lab1.Logic.katty.Task_2;

namespace Study.Lab1.Logic.UnitTests.katty.Task2;

[TestFixture]
public class NextDecoratorTests
{
    [Test]
    public void NextDecorator_ShouldAddSuffixToEuropeanFormatter()
    {
        // Arrange
        IDateTimeFormatter formatter = new EuropeanDateTimeFormatter();
        formatter = new NextDecorator(formatter, " (UTC)");
        var testDateTime = new DateTime(2023, 4, 5, 15, 30, 45);

        // Act
        string result = formatter.FormatDateTime(testDateTime);

        // Assert
        Assert.That(result, Is.EqualTo("05.04.2023 15:30:45 (UTC)"));
    }

    [Test]
    public void NextDecorator_ShouldAddSuffixToAmericanFormatter()
    {
        // Arrange
        IDateTimeFormatter formatter = new AmericanDateTimeFormatter();
        formatter = new NextDecorator(formatter, " (UTC)");
        var testDateTime = new DateTime(2023, 4, 5, 15, 30, 45);

        // Act
        string result = formatter.FormatDateTime(testDateTime);

        // Assert
        Assert.That(result, Is.EqualTo("4/5/2023 3:30:45 PM (UTC)"));
    }
}
