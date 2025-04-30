using Study.Lab1.Logic.katty;

namespace Study.Lab1.Logic.UnitTests.katty;

[TestFixture]
public class FractionTests
{
    [Test]
    public void ToStringTest()
    {
        var fraction = new Fraction(1, 1);

        var text = fraction.ToString();

        Assert.That(text, Is.EqualTo("1/1"));
    }

    [Test]
    public void ToStringTest2()
    {
        var fraction = new Fraction(1, 1);

        var text = fraction.ToString();

        Assert.That(text, Is.EqualTo("1/1"));
    }
}
