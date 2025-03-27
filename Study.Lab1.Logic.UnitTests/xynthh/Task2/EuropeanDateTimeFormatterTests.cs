using System.Globalization;
using Study.Lab1.Logic.xynthh.Task2;

namespace Study.Lab1.Logic.UnitTests.xynthh.Task2;

[TestFixture]
public class EuropeanDateTimeFormatterTests
{
    [Test]
    public void FormatDateTime_ReturnsCorrectGermanFormat()
    {
        // Arrange
        var formatter = new EuropeanDateTimeFormatter();
        var now = DateTime.Now;
        var expected = now.ToString(new CultureInfo("de-DE"));

        // Act
        var result = formatter.FormatDateTime();

        // Assert
        Assert.That(result.Length, Is.GreaterThan(0));
        // Проверяем паттерн немецкого формата: дд.мм.гггг чч:мм:сс
        Assert.That(result, Does.Match(@"\d{2}\.\d{2}\.\d{4} \d{2}:\d{2}:\d{2}"));
    }

    [Test]
    public void FormatDateTime_ReturnsStringWithEuropeanDateSeparator()
    {
        // Arrange
        var formatter = new EuropeanDateTimeFormatter();

        // Act
        var result = formatter.FormatDateTime();

        // Assert
        Assert.That(result, Does.Contain(".")); // Немецкий формат использует точки как разделители даты
    }

    [Test]
    public void FormatDateTime_ReturnsStringWithTimeValue()
    {
        // Arrange
        var formatter = new EuropeanDateTimeFormatter();

        // Act
        var result = formatter.FormatDateTime();

        // Assert
        Assert.That(result, Does.Match(@".*\d{2}:\d{2}:\d{2}.*")); // Содержит время в формате чч:мм:сс
    }

    [Test]
    public void FormatDateTime_WithBracketsDecorator_ReturnsStringWithBrackets()
    {
        // Arrange
        var formatter = new EuropeanDateTimeFormatter();
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
        var formatter = new EuropeanDateTimeFormatter();
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
        var formatter = new EuropeanDateTimeFormatter();
        var suffix = " (CET)";
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
        var formatter = new EuropeanDateTimeFormatter();
        var prefix = "Time: ";
        var suffix = " (Europe)";

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