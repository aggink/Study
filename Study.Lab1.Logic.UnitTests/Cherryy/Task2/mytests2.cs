using System.Globalization;
using Study.Lab1.Logic.Interfaces.Cherryy.Task2;

namespace Study.Lab1.Logic.UnitTests.Cherryy.Task2
{
    class mytests2
    {
     private readonly DateTime _testDate = new DateTime(2025, 04, 08, 23, 50, 0);

     [Test]
     public void EuropeanFormatter()
     {
            var formatter = new EuropeanDateTimeFormatter();
            var result = formatter.FormatDateTime();
            Assert.That(result, Is.EqualTo("08.04.2025 23:50"));
        }

     [Test]
     public void AmericanFormatter()
     {
            var formatter = new AmericanDateTimeFormatter();
            var result = formatter.FormatDateTime();
            Assert.That(result, Is.EqualTo("04/08/2025 11:50 PM"));
     }
    }
}
