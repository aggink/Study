using Study.Lab1.Logic.Interfaces.katty.Task2;
using Study.Lab1.Logic.katty.Task_2;

namespace Study.Lab1.Logic.UnitTests.katty.Task2;

[TestFixture]
public class DecoratorChainTests
{
    [Test]
    public void MultipleDecorators_ShouldWorkTogether()
    {
        // Arrange
        IDateTimeFormatter formatter = new EuropeanDateTimeFormatter();
        formatter = new StartDecorator(formatter, "Дата: ");
        formatter = new NextDecorator(formatter, " (UTC)");
        var dateTime = new DateTime(2023, 6, 15, 12, 30, 0);

        // Act
        var result = formatter.FormatDateTime(dateTime);

        // Assert
        Assert.That(result, Is.EqualTo("Дата: 15.06.2023 12:30:00 (UTC)"));
    }
}
