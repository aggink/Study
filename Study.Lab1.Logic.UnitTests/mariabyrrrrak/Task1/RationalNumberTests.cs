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

        Assert.AreEqual(tesks.Denominator, 2);
        Assert.AreEqual(tesks.Numerator, 2);
    }

    [Test]
    public void OperatorMinus()
    {
        var A = new RationalNumber(4, 6);
        var B = new RationalNumber(2, 8);
        var tesks = A - B;
        Assert.AreEqual(tesks.Denominator, 48);
        Assert.AreEqual(tesks.Numerator, 20);
    }

    [Test]
    public void OperatorDelen()
    {
        var A = new RationalNumber(4, 6);
        var B = new RationalNumber(2, 8);
        var tesks = A / B;
        Assert.AreEqual(tesks.Numerator, 32);
        Assert.AreEqual(tesks.Denominator, 12);

    }

    [Test]
    public void OperatorYnarnMinus()
    {
        var A = new RationalNumber(5, 7);
        var tesks = -A;
        Assert.AreEqual(tesks.Numerator, -5);
        Assert.AreEqual(tesks.Denominator, 7);
    }

    [Test]
    public void OperatorRAvenstvo()
    {
        var A = new RationalNumber(4, 6);
        var B = new RationalNumber(2, 3);
        Assert.IsTrue(A == B);
    }

    [Test]
    public void OperatorNeRavno()
    {
        var A = new RationalNumber(4, 6);
        var B = new RationalNumber(2, 8);
        Assert.IsTrue(A != B);
    }

    [Test]
    public void RationalNumber_ComparisonOperators()
    {
        var A = new RationalNumber(4, 6);
        var B = new RationalNumber(2, 8);

        Assert.That(B < A, Is.True);
        Assert.That(B <= A, Is.True);
        Assert.That(B > A, Is.False);
        Assert.That(B >= A, Is.False);
    }

}