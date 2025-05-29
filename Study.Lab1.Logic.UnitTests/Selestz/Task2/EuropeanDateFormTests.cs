using Study.Lab1.Logic.kinkiss1.Task2;
using Study.Lab1.Logic.Selestz.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.UnitTests.Selestz.Task2;

public class EuropeanDateFormTests
{
    [Test]
    public void FormatDateTime_ReturnsNonEmptyString()
    {
        // Arrange
        var format = new EuropeanDateForm();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public void FormatDateTime_UsesCorrectDateSeparator()
    {
        // Arrange
        var format = new EuropeanDateForm();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Does.Contain("."));
    }


    [Test]
    public void FormatDateTime_DoesNotUseAMPMFormat()
    {
        // Arrange
        var format = new EuropeanDateForm();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Does.Not.Match(@".*\s(AM|PM)$"));
    }

    [Test]
    public void FormatDateTime_ReturnsValidDateTimeString()
    {
        // Arrange
        var format = new EuropeanDateForm();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.DoesNotThrow(() => DateTime.Parse(result, new CultureInfo("de-DE")));
    }

    [Test]
    public void FormatDateTime_Uses24HourClock()
    {
        // Arrange
        var format = new EuropeanDateForm();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Does.Not.Match(@".*\s(AM|PM)$"));
    }

    [Test]
    public void FormatDateTime_WithPrefixDecorator_ReturnsStringWithPrefix()
    {
        // Arrange
        var formatter = new EuropeanDateForm();
        var decorated = new PrefDecorator(formatter);
        var prefix = "☺☺☺";
        // Act
        var result = decorated.FormatDateTime();

        // Assert
        Assert.That(result, Does.StartWith(prefix));
    }

    [Test]
    public void FormatDateTime_WithPostfixDecorator_ReturnsStringWithPostfix()
    {
        // Arrange
        var formatter = new EuropeanDateForm();
        var decorated = new PostDecorator(formatter);
        var postfix = "☺☺☺";
        // Act
        var result = decorated.FormatDateTime();

        // Assert
        Assert.That(result, Does.EndWith(postfix));
    }

    [Test]
    public void FormatDateTime_WithDec23()
    {
        // Arrange
        var formatter = new EuropeanDateForm();
        var decorated = new Decorator23(formatter);
        var prefix = "ALT + 23: ↨↨↨";
        var postfix = "↨↨↨";
        // Act
        var result = decorated.FormatDateTime();

        // Assert
        Assert.That(result, Does.StartWith(prefix));
        Assert.That(result, Does.EndWith(postfix));
    }
}