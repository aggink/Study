using Study.Lab1.Logic.mansurgh.Task1;

namespace Study.Lab1.Logic.UnitTests.mansurgh.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void CorrectAddition()
    {
        var a = new RationalNumber(1, 1);
        var b = new RationalNumber(5, 10);
        var result = a + b;

        Assert.AreEqual(3, result.Numerator);
        Assert.AreEqual(2, result.Denominator);
    }

    [Test]
    public void CorrectSubtraction()
    {
        var a = new RationalNumber(5, 1);

        var b = new RationalNumber(5, 10);
        var result = a - b;

        Assert.AreEqual(9, result.Numerator);
        Assert.AreEqual(2, result.Denominator);
    }

    [Test]
    public void CorrectMultiplication()
    {
        var a = new RationalNumber(-3, 4);
        var b = new RationalNumber(1, -3);
        var result = a * b;

        Assert.AreEqual(1, result.Numerator);
        Assert.AreEqual(4, result.Denominator);
    }

    [Test]
    public void CorrectMinus()
    {
        var a = new RationalNumber(-1, 3);
        var result = -a;

        Assert.AreEqual(1, result.Numerator);
        Assert.AreEqual(3, result.Denominator);
    }

    [Test]
    public void DenominatorZeroByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(7, 0));
    }

    [Test]
    public void CorrectReductionNumbers()
    {
        var a = new RationalNumber(4, 6);
        Assert.AreEqual(2, a.Numerator);
        Assert.AreEqual(3, a.Denominator);
    }

    [Test]
    public void CorrectStringRepresentation()
    {
        var a = new RationalNumber(3, 5);
        Assert.AreEqual("3/5", a.ToString());
    }

    [Test]
    public void CorrectLogicalOperators()
    {
        var a = new RationalNumber(3, 2);
        var b = new RationalNumber(2, 6);

        Assert.That(a < b, Is.False, "Неверно <");
        Assert.That(a <= b, Is.False, "Неверно <=");
        Assert.That(a > b, Is.True, "Неверно >");
        Assert.That(a >= b, Is.True, "Неверно >=");
        Assert.That(a == b, Is.False, "Неверно ==");
        Assert.That(a != b, Is.True, "Неверно !=");
    }
}
