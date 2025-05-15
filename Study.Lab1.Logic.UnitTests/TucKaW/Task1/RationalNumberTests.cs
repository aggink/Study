using Study.Lab1.Logic.TucKaW.Task1;

namespace Study.Lab1.Logic.UnitTests.TucKaW.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void RationalNumber_CorrectSum()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);

        var result = a + b;

        Assert.That(result.Numerator, Is.EqualTo(5));
        Assert.That(result.Denominator, Is.EqualTo(6));
    }

    [Test]
    public void RationalNumber_CorrectSubtraction()
    {
        var a = new RationalNumber(5, 6);
        var b = new RationalNumber(1, 3);

        var result = a - b;

        Assert.That(result.Numerator, Is.EqualTo(1));
        Assert.That(result.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_CorrectMultiplication()
    {
        var a = new RationalNumber(2, 3);
        var b = new RationalNumber(3, 4);

        var result = a * b;

        Assert.That(result.Numerator, Is.EqualTo(1));
        Assert.That(result.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_CorrectDivision()
    {
        var a = new RationalNumber(2, 3);
        var b = new RationalNumber(3, 4);

        var result = a / b;

        Assert.That(result.Numerator, Is.EqualTo(8));
        Assert.That(result.Denominator, Is.EqualTo(9));
    }

    [Test]
    public void RationalNumber_DivisionByZero_ThrowsException()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(0, 1);


        Assert.Throws<DivideByZeroException>(() =>
        {
            var result = a / b;
        });
    }

    [Test]
    public void RationalNumber_CorrectNegate()
    {
        var a = new RationalNumber(1, 2);
        var b = -a;

        Assert.That(b.Numerator, Is.EqualTo(-1));
        Assert.That(b.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_CorrectEquals()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 2);

        var result = a == b;
        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_CorrectMultiOperation()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(9, 3);

        var c = a * b;
        var d = (a + b) / a;
        c += d;
        c -= b;
        c = -c;

        Assert.That(c.Numerator, Is.EqualTo(-11));
        Assert.That(c.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_CorrectMinusMultiplication()
    {
        var a = new RationalNumber(8, -12);
        var b = new RationalNumber(93, 8);
        var c = a * b;
        Assert.That(c.Numerator, Is.EqualTo(-31));
        Assert.That(c.Denominator, Is.EqualTo(4));
    }

    [Test]
    public void Constructor_DenominatorIsZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void Constructor_NegativeDenominator_NormalizesSign()
    {
        var number = new RationalNumber(1, -2);

        Assert.That(number.Numerator, Is.EqualTo(-1));
        Assert.That(number.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_GreaterThan_ReturnsTrue_WhenLeftIsGreater()
    {
        var a = new RationalNumber(3, 4);
        var b = new RationalNumber(1, 2);

        var result = a > b;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_GreaterThan_ReturnsFalse_WhenLeftIsLess()
    {
        var a = new RationalNumber(1, 3);
        var b = new RationalNumber(1, 2);

        var result = a > b;

        Assert.That(result, Is.False);
    }

    [Test]
    public void RationalNumber_LessThan_ReturnsTrue_WhenLeftIsLess()
    {
        var a = new RationalNumber(1, 3);
        var b = new RationalNumber(1, 2);

        var result = a < b;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_LessThan_ReturnsFalse_WhenLeftIsGreater()
    {
        var a = new RationalNumber(3, 4);
        var b = new RationalNumber(1, 2);

        var result = a < b;

        Assert.That(result, Is.False);
    }

    [Test]
    public void RationalNumber_GreaterThanOrEqual_ReturnsTrue_WhenLeftIsGreater()
    {
        var a = new RationalNumber(3, 4);
        var b = new RationalNumber(1, 2);

        var result = a >= b;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_GreaterThanOrEqual_ReturnsTrue_WhenEqual()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);

        var result = a >= b;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_LessThanOrEqual_ReturnsTrue_WhenLeftIsLess()
    {
        var a = new RationalNumber(1, 3);
        var b = new RationalNumber(1, 2);

        var result = a <= b;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_LessThanOrEqual_ReturnsTrue_WhenEqual()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);

        var result = a <= b;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_ComparisonOperators_WorkWithNegativeNumbers()
    {
        var a = new RationalNumber(-1, 2);
        var b = new RationalNumber(1, 4);

        Assert.That(a < b, Is.True);
        Assert.That(a <= b, Is.True);
        Assert.That(a > b, Is.False);
        Assert.That(a >= b, Is.False);
    }
}