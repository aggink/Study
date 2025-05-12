using Study.Lab1.Logic.katty.Task_2;

namespace Study.Lab1.Logic.UnitTests.katty;

[TestFixture]
public class AmericanDateTimeFormatterTests
{
    [Test]
    public void FormatDateTime_ShouldReturn_CorrectAmericanFormat()
    {
        // Arrange
        var formatter = new AmericanDateTimeFormatter();
        var dateTime = new DateTime(2023, 12, 31, 23, 59, 59);

        // Act
        var result = formatter.FormatDateTime(dateTime);

        // Assert
        Assert.That(result, Is.EqualTo("12/31/2023 11:59:59 PM"));
    }
}
