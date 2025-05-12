using Study.Lab1.Logic.Interfaces.katty.Task2;
using Study.Lab1.Logic.katty.Task_2;
using NUnit.Framework;
using System;
using System.Globalization;

namespace Study.Lab1.Logic.UnitTests.katty
{
    [TestFixture]
    public class EuropeanDateTimeFormatterTests
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

    [TestFixture]
    public class StartDecoratorTests
    {
        [Test]
        public void FormatDateTime_ShouldAdd_PrefixToFormattedDate()
        {
            // Arrange
            var baseFormatter = new EuropeanDateTimeFormatter();
            var decorator = new StartDecorator(baseFormatter, "Начало: ");
            var dateTime = new DateTime(2023, 1, 1);

            // Act
            var result = decorator.FormatDateTime(dateTime);

            // Assert
            // Либо принимаем оба варианта (с нулем и без)
            Assert.That(result, Is.EqualTo("Начало: 01.01.2023 00:00:00").Or.EqualTo("Начало: 01.01.2023 0:00:00"));

            // Либо проверяем только начало строки
            Assert.That(result, Does.StartWith("Начало: 01.01.2023"));
            Assert.That(result, Does.EndWith(":00:00"));
        }
    }

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

    [TestFixture]
    public class DecoratorChainTests
    {
        [Test]
        public void MultipleDecorators_ShouldWorkTogether()
        {
            // Arrange
            IDateTimeFormatter formatter = new EuropeanDateTimeFormatter();
            formatter = new StartDecorator(formatter, "Дата: ");
            formatter = new NextDecorator(formatter, " (UTC)");
            var dateTime = new DateTime(2023, 6, 15, 12, 30, 0);

            // Act
            var result = formatter.FormatDateTime(dateTime);

            // Assert
            Assert.That(result, Is.EqualTo("Дата: 15.06.2023 12:30:00 (UTC)"));
        }
    }

    [TestFixture]
    public class RunTask2IntegrationTest
    {
        [Test]
        public void RunTask2_ShouldProduce_ExpectedOutput()
        {
            // Arrange
            IDateTimeFormatter europeanFormatter = new EuropeanDateTimeFormatter();
            IDateTimeFormatter americanFormatter = new AmericanDateTimeFormatter();

            europeanFormatter = new StartDecorator(europeanFormatter, "Европейский формат: ");
            europeanFormatter = new NextDecorator(europeanFormatter, " (UTC)");

            americanFormatter = new StartDecorator(americanFormatter, "Американский формат: ");
            americanFormatter = new NextDecorator(americanFormatter, " (UTC)");

            var testDateTime = new DateTime(2023, 4, 5, 15, 30, 45);

            // Act
            string europeanDateTime = europeanFormatter.FormatDateTime(testDateTime);
            string americanDateTime = americanFormatter.FormatDateTime(testDateTime);

            // Assert
            Assert.That(europeanDateTime, Is.EqualTo("Европейский формат: 05.04.2023 15:30:45 (UTC)"));
            Assert.That(americanDateTime, Is.EqualTo("Американский формат: 4/5/2023 3:30:45 PM (UTC)"));
        }
    }
}