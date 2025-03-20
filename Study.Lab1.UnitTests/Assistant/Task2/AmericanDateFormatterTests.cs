using Study.Lab1.Logic.Assistant.Task2;

namespace Study.Lab1.UnitTests.Assistant.Task2
{
    [TestFixture]
    public class AmericanDateFormatterTests
    {
        [Test]
        public void FormatDate_ShouldReturnCorrectDateFormat()
        {
            // Arrange
            var formatter = new AmericanDateFormatter();
            var testDate = new DateTime(2025, 3, 20);

            // Act
            var result = formatter.FormatDate(testDate);

            // Assert
            Assert.That(result, Is.EqualTo("03/20/2025"));
        }

        [Test]
        public void FormatTime_ShouldReturnCorrectTimeFormat()
        {
            // Arrange
            var formatter = new AmericanDateFormatter();
            var testTime = new DateTime(2025, 3, 20, 14, 30, 45);

            // Act
            var result = formatter.FormatTime(testTime);

            // Assert
            Assert.That(result, Is.EqualTo("02:30 PM"));
        }
    }
}
