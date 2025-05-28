using Study.Lab1.Logic.mariabyrrrrak.Task1;

namespace Study.Lab1.Logic.UnitTests.mariabyrrrrak.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void ToString_Show()
    {
        var n = new RationalNumber(1, 1);

        var tekst = n.ToString();

        Assert.AreEqual("1/1", tekst);
    }

    [Test]
    public void OperatorSumm()
    {
        var n = new RationalNumber(1, 1);
        var m = new RationalNumber(2, 2);

        var tesks = n + m;

        Assert.AreEqual(tesks.Denominator, 2);
        Assert.AreEqual(tesks.Numerator, 4);
    }

    [Test]
    public void OperatorMulti()
    {
        var n = new RationalNumber(1, 1);
        var m = new RationalNumber(2, 2);

        var tesks = n * m;

        Assert.AreEqual(tesks.Denominator, 3);
        Assert.AreEqual(tesks.Numerator, 3);
    }

}