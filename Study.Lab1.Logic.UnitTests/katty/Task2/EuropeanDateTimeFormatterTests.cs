using Study.Lab1.Logic.katty.Task2;

namespace Study.Lab1.Logic.UnitTests.katty.Task2;

[TestFixture]
public class EuropeanDateTimeFormatterTests1
{
    [Test]
    public void FormatDateTime_ShouldReturn_CorrectEuropeanFormat()
    {
        // Arrange
        var formatter = new EuropeanDateTimeFormatter();
        var dateTime = new DateTime(2023, 12, 31, 23, 59, 59);

        // Act
        var result = formatter.FormatDateTime(dateTime);

        // Assert
        Assert.That(result, Is.EqualTo("31.12.2023 23:59:59"));
    }
}
