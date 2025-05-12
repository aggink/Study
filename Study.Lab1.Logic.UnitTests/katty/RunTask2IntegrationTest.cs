using Study.Lab1.Logic.Interfaces.katty.Task2;
using Study.Lab1.Logic.katty.Task_2;

namespace Study.Lab1.Logic.UnitTests.katty;

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
