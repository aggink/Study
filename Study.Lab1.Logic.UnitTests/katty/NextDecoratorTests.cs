using Study.Lab1.Logic.katty.Task_2;

namespace Study.Lab1.Logic.UnitTests.katty;

[TestFixture]
public class NextDecoratorTests
{
    [Test]
    public void FormatDateTime_ShouldAdd_SuffixToFormattedDate()
    {
        // Arrange
        var baseFormatter = new AmericanDateTimeFormatter();
        var decorator = new NextDecorator(baseFormatter, " (конец)");
        var dateTime = new DateTime(2023, 1, 1);

        // Act
        var result = decorator.FormatDateTime(dateTime);

        // Assert
        Assert.That(result, Is.EqualTo("1/1/2023 12:00:00 AM (конец)"));
    }
}
