using Study.Lab1.Logic.brnvika.Task2;
using Study.Lab1.Logic.Interfaces.brnvika.Task2;

namespace Study.Lab1.Logic.UnitTests.brnvika.Task2;

[TestFixture]
public class EuropeanDateFormatterTests
{
    [Test]
    public void FormatDate_ShouldReturnCorrectDateFormat()
    {
        // Arrange
        var formatter = new EuropeanDateFormatter();
        var testDate = new DateTime(2025, 3, 20);

        // Act
        var result = formatter.FormatDate(testDate);

        // Assert
        Assert.That(result, Is.EqualTo("20.03.2025"));
    }

    [Test]
    public void FormatDate_ShouldReturnCorrectDateFormat2()
    {
        // Arrange
        var formatter = new EuropeanDateFormatter();
        var testDate = new DateTime(2025, 3, 21);

        // Act
        var result = formatter.FormatDate(testDate);

        // Assert
        Assert.That(result, Is.EqualTo("21.03.2025"));
    }

    [Test]
    public void FormatTime_ShouldReturnCorrectTimeFormat()
    {
        // Arrange
        var formatter = new EuropeanDateFormatter();
        var testTime = new DateTime(2025, 3, 20, 14, 30, 45);

        // Act
        var result = formatter.FormatTime(testTime);

        // Assert
        Assert.That(result, Is.EqualTo("14:30:45"));
    }

    [Test]
    public void FormatDate_ShouldReturnCorrectFormatAddSeparator()
    {
        // Arrange
        IDateFormatter formatter = new EuropeanDateFormatter();
        var testDate = new DateTime(2025, 4, 22, 14, 30, 45);
        formatter = new AddNewSeparator(formatter, '*');

        // Act
        var result = formatter.FormatDate(testDate);

        // Assert
        Assert.That(result, Is.EqualTo("22*04*2025"));
    }

    [Test]
    public void FormatTime_ShouldReturnCorrectFormatAddSeparator()
    {
        // Arrange
        IDateFormatter formatter = new EuropeanDateFormatter();
        var testTime = new DateTime(2025, 4, 22, 14, 30, 45);
        formatter = new AddNewSeparator(formatter, '*');

        // Act
        var result = formatter.FormatTime(testTime);

        // Assert
        Assert.That(result, Is.EqualTo("14*30*45"));
    }

    [Test]
    public void FormatDate_ShouldReturnCorrectFormatIsolateLine()
    {
        // Arrange
        IDateFormatter formatter = new EuropeanDateFormatter();
        var testDate = new DateTime(2025, 4, 22, 14, 30, 45);
        formatter = new IsolateLine(formatter, "##");

        // Act
        var result = formatter.FormatDate(testDate);

        // Assert
        Assert.That(result, Is.EqualTo("##22.04.2025##"));
    }

    [Test]
    public void FormatTime_ShouldReturnCorrectFormatIsolateLine()
    {
        // Arrange
        IDateFormatter formatter = new EuropeanDateFormatter();
        var testTime = new DateTime(2025, 4, 22, 14, 30, 45);
        formatter = new IsolateLine(formatter, "##");

        // Act
        var result = formatter.FormatTime(testTime);

        // Assert
        Assert.That(result, Is.EqualTo("##14:30:45##"));
    }
}
