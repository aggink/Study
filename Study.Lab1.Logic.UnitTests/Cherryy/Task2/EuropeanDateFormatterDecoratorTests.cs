using Study.Lab1.Logic.Cherryy.Task2;
using Study.Lab1.Logic.Interfaces.Cherryy.Task2;

namespace Study.Lab1.Logic.UnitTests.Cherryy.Task2
{
    [TestFixture]
    public class EuropeanDateFormatterDecoratorTests
    {
        [Test]
        public void EuropeanDecorator()
        {
            var date = new DateTime(2025, 10, 10, 10, 10, 10);

            var formatter = new EuropeanDateTimeFormatter();
            var decorator = new EuropeanDateFormatterDecorator(formatter);
            var result = decorator.FormatDateTime(date);

            Assert.That(result, Is.EqualTo("European; 10/10/2025 10:10:10"));
        }
    }
}
