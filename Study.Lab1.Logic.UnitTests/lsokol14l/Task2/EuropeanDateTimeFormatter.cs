using System.Globalization;
using Study.Lab1.Logic.lsokol14l.Task2;

namespace Study.Lab1.Logic.UnitTests.lsokol14l.Task2;

[TestFixture]
public class EuropeanDateTimeFormatterTests
{
    [Test]
    public void FormatDateTime_ReturnsCorrectEuropeanFormat()
    {
        // Arrange
        var formatter = new EuropeanDateFormatter();
        var now = DateTime.Now;
        var expected = now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        // Act
        var result = formatter.FormatDate(now) + " " + formatter.FormatTime(now);

        // Проверяем паттерн американского формата: MM/dd/yyyy hh:mm:ss tt
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatDateTime_ReturnsStringWithEuropeanDateSeparator()
    {
        var now = DateTime.Now;
        // Arrange
        var formatter = new EuropeanDateFormatter();

        // Act
        var result = formatter.FormatDate(now) + formatter.FormatTime(now);

        // Assert
        Assert.That(result, Does.Contain("/"));
    }

    [Test]
    public void FormatDateTime_ReturnsStringWithTimeValue()
    {
        var now = DateTime.Now;
        // Arrange
        var formatter = new EuropeanDateFormatter();

        // Act
        var result = formatter.FormatDate(now) + formatter.FormatTime(now);

        // Assert
        Assert.That(result, Does.Match(@".*\d{1,2}:\d{2}:\d{2}.*")); // Содержит время в формате чч:мм:сс
    }

    [Test]
    public void FormatDateTime_WithBracketsDecorator_ReturnsStringWithBrackets()
    {
        var now = DateTime.Now;
        // Arrange
        var formatter = new EuropeanDateFormatter();
        var decoratedFormatter = new AddBracketsDecorator(formatter);

        // Act
        var result = decoratedFormatter.FormatDate(now) + " " + decoratedFormatter.FormatTime(now);

        var excepted = "[" + formatter.FormatDate(DateTime.Now) + "] [" + formatter.FormatTime(DateTime.Now) + "]";
        // Assert
        Assert.That(excepted, Is.EqualTo(result));
    }

    [Test]
    public void FormatDateTime_WithPrefixDecorator_ReturnsStringWithPrefix()
    {
        // Arrange
        var formatter = new EuropeanDateFormatter();
        var prefix = "Current time: ";
        var decoratedFormatter = new AddPrefixDecorator(formatter, prefix);

        var now = DateTime.Now;

        // Act
        var result = decoratedFormatter.FormatDate(now) + formatter.FormatTime(now);

        // Assert
        Assert.That(result, Does.StartWith(prefix));
    }

    [Test]
    public void FormatDateTime_WithSuffixDecorator_ReturnsStringWithSuffix()
    {
        var now = DateTime.Now;
        // Arrange
        var formatter = new EuropeanDateFormatter();
        var postfix = " (EST)";
        var decoratedFormatter = new AddPostfixDecorator(formatter, postfix);

        // Act
        var result = formatter.FormatDate(now) + decoratedFormatter.FormatTime(now);

        // Assert
        Assert.That(result, Does.EndWith(postfix));
    }

    [Test]
    public void FormatDateTime_WithMultipleDecorators_AppliesDecorationsInCorrectOrder()
    {
        // Arrange
        var formatter = new EuropeanDateFormatter();
        var prefix = "Time: ";
        var postfix = " (USA)";

        var decorated = new AddPrefixDecorator(
            new AddBracketsDecorator(
                new AddPostfixDecorator(formatter, postfix)),
            prefix);

        // Act
        var result = decorated.FormatTime(DateTime.Now);
        var excepted = "Time: [" + formatter.FormatTime(DateTime.Now) + " (USA)]";

        // Assert
        Assert.That(excepted, Is.EqualTo(result));
    }
}