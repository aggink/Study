using System.Globalization;
using Study.Lab1.Logic.poroshok.Task2;

namespace Study.Lab1.Logic.UnitTests.poroshok.Task2;

[TestFixture]
public class AmericanDateTimeFormatterTests
{
    [Test]
    public void FormatDateTime_ReturnsCorrectAmericanFormat()
    {
        // Arrange
        var formatter = new AmericanDateTimeFormatter();
        var now = DateTime.Now;
        var expected = now.ToString(new CultureInfo("en-US"));

        // Act
        var result = formatter.FormatDateTime();

        // Assert
        Assert.That(result.Length, Is.GreaterThan(0));
        // Проверяем паттерн американского формата: мм/дд/гггг чч:мм:сс
        Assert.That(result, Does.Match(@"\d{1,2}/\d{1,2}/\d{4} \d{1,2}:\d{2}:\d{2}"));
    }

    [Test]
    public void FormatDateTime_ReturnsStringWithAmericanDateSeparator()
    {
        // Arrange
        var formatter = new AmericanDateTimeFormatter();

        // Act
        var result = formatter.FormatDateTime();

        // Assert
        Assert.That(result, Does.Contain("/")); // Американский формат использует слэши как разделители даты
    }

    [Test]
    public void FormatDateTime_ReturnsStringWithTimeValue()
    {
        // Arrange
        var formatter = new AmericanDateTimeFormatter();

        // Act
        var result = formatter.FormatDateTime();

        // Assert
        Assert.That(result, Does.Match(@".*\d{1,2}:\d{2}:\d{2}.*")); // Содержит время в формате чч:мм:сс
    }

    [Test]
    public void FormatDateTime_WithBracketsDecorator_ReturnsStringWithBrackets()
    {
        // Arrange
        var formatter = new AmericanDateTimeFormatter();
        var decoratedFormatter = new AddBracketsDecorator(formatter);

        // Act
        var result = decoratedFormatter.FormatDateTime();

        // Assert
        Assert.That(result, Does.StartWith("["));
        Assert.That(result, Does.EndWith("]"));
    }

    [Test]
    public void FormatDateTime_WithPrefixDecorator_ReturnsStringWithPrefix()
    {
        // Arrange
        var formatter = new AmericanDateTimeFormatter();
        var prefix = "Current time: ";
        var decoratedFormatter = new AddPrefixDecorator(formatter, prefix);

        // Act
        var result = decoratedFormatter.FormatDateTime();

        // Assert
        Assert.That(result, Does.StartWith(prefix));
    }

    [Test]
    public void FormatDateTime_WithSuffixDecorator_ReturnsStringWithSuffix()
    {
        // Arrange
        var formatter = new AmericanDateTimeFormatter();
        var suffix = " (EST)";
        var decoratedFormatter = new AddSuffixDecorator(formatter, suffix);

        // Act
        var result = decoratedFormatter.FormatDateTime();

        // Assert
        Assert.That(result, Does.EndWith(suffix));
    }

    [Test]
    public void FormatDateTime_WithMultipleDecorators_AppliesDecorationsInCorrectOrder()
    {
        // Arrange
        var formatter = new AmericanDateTimeFormatter();
        var prefix = "Time: ";
        var suffix = " (USA)";

        var decorated = new AddPrefixDecorator(
            new AddBracketsDecorator(
                new AddSuffixDecorator(formatter, suffix)),
            prefix);

        // Act
        var result = decorated.FormatDateTime();

        // Assert
        Assert.That(result, Does.StartWith(prefix + "["));
        Assert.That(result, Does.EndWith(suffix + "]"));
    }
}