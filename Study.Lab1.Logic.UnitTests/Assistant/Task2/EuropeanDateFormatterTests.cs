using Study.Lab1.Logic.Assistant.Task2;

namespace Study.Lab1.Logic.UnitTests.Assistant.Task2
{
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

    }
}
