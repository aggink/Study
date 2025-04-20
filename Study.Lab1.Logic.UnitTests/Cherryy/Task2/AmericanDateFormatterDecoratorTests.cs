using Study.Lab1.Logic.Cherryy.Task2;
using Study.Lab1.Logic.Interfaces.Cherryy.Task2;

namespace Study.Lab1.Logic.UnitTests.Cherryy.Task2
{
    [TestFixture]
    public class AmericanDateFormatterDecoratorTests
    {
        [Test]
        public void AmericanDecorator()
        {
            var date = new DateTime(2025, 10, 10, 10, 10, 10);

            var formatter = new AmericanDateTimeFormatter();
            var decorator = new AmericanDateFormatterDecorator(formatter);
            var result = decorator.FormatDateTime(date);

            Assert.That(result, Is.EqualTo("American; 10/10/2025 10:10:10 AM"));
        }
    }
}
