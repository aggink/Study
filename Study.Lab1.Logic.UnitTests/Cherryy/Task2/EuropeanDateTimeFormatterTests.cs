using Study.Lab1.Logic.Cherryy.Task2;

namespace Study.Lab1.Logic.UnitTests.Cherryy.Task2;

[TestFixture]
public class EuropeanDateTimeFormatterTests
{
    [Test]
    public void EuropeanFormatter()
    {
        var date = new DateTime(2025, 10, 10, 10, 10, 10);

        var formatter = new EuropeanDateTimeFormatter();
        var result = formatter.FormatDateTime(date);

        Assert.That(result, Is.EqualTo("10/10/2025 10:10:10"));
    }
}