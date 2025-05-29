using Study.Lab1.Logic.Selestz.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.UnitTests.Selestz.Task2;

public class AmericanDateFormTests
{
    [Test]
    public void FormatDateTime_ReturnsNonEmptyString()
    {
        // Arrange
        var format = new AmericanDateForm();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public void FormatDateTime_UsesCorrectDateSeparator()
    {
        // Arrange
        var format = new AmericanDateForm();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Does.Contain("/")); // Проверяем, что используется "/" как разделитель даты
    }

    [Test]
    public void FormatDateTime_ReturnsValidDateTimeString()
    {
        // Arrange
        var format = new AmericanDateForm();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.DoesNotThrow(() => DateTime.Parse(result, new CultureInfo("en-US")));
    }

    [Test]
    public void FormatDateTime_ReturnsCorrectAmericanFormat()
    {
        // Arrange
        var formatter = new AmericanDateForm();

        // Act
        var result = formatter.FormatDateTime();

        // Assert
        Assert.That(result.Length, Is.GreaterThan(0));
        // Проверяем паттерн американского формата: мм/дд/гггг чч:мм:сс
        Assert.That(result, Does.Match(@"\d{1,2}/\d{1,2}/\d{4} \d{1,2}:\d{2}"));
    }

    [Test]
    public void FormatDateTime_ReturnsStringWithAmericanDateSeparator()
    {
        // Arrange
        var formatter = new AmericanDateForm();

        // Act
        var result = formatter.FormatDateTime();

        // Assert
        Assert.That(result, Does.Contain("/"));
    }

    [Test]
    public void FormatDateTime_WithPrefixDecorator_ReturnsStringWithPrefix()
    {
        // Arrange
        var formatter = new AmericanDateForm();
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
        var formatter = new AmericanDateForm();
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
        var formatter = new AmericanDateForm();
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