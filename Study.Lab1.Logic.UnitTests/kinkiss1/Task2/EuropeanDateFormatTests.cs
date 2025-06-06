﻿using Study.Lab1.Logic.kinkiss1.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.UnitTests.kinkiss1.Task2;

public class EuropeanDateFormatTests
{
    [Test]
    public void FormatDateTime_ReturnsNonEmptyString()
    {
        // Arrange
        var format = new EuropeanDateFormat();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public void FormatDateTime_UsesCorrectDateSeparator()
    {
        // Arrange
        var format = new EuropeanDateFormat();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Does.Contain("/")); // Проверяем, что используется "/" как разделитель даты
    }


    [Test]
    public void FormatDateTime_DoesNotUseAMPMFormat()
    {
        // Arrange
        var format = new EuropeanDateFormat();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Does.Not.Match(@".*\s(AM|PM)$")); // Проверяем, что формат времени не содержит AM/PM
    }

    [Test]
    public void FormatDateTime_ReturnsValidDateTimeString()
    {
        // Arrange
        var format = new EuropeanDateFormat();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.DoesNotThrow(() => DateTime.Parse(result, new CultureInfo("fr-FR"))); // Проверяем, что строка корректно парсится
    }

    [Test]
    public void FormatDateTime_Uses24HourClock()
    {
        // Arrange
        var format = new EuropeanDateFormat();

        // Act
        var result = format.FormatDateTime();

        // Assert
        Assert.That(result, Does.Not.Match(@".*\s(AM|PM)$")); // Проверяем, что не используется AM/PM
    }
}