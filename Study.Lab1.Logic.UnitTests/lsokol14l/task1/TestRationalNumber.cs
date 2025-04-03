using Study.Lab1.Logic.lsokol14l.task1;

namespace Study.Lab1.Logic.UnitTests.lsokol14l.Task1;

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

    [Test]
    public void Constructor_ValidInput_ShouldInitializeCorrectly()
    {
        var rationalNumber = new RationalNumber(4, 6);
        Assert.That(rationalNumber.Numerator, Is.EqualTo(2));
        Assert.That(rationalNumber.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void Constructor_DenominatorZero_ShouldThrowDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void Operator_Addition_ShouldReturnCorrectResult()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a + b;
        Assert.That(result, Is.EqualTo(new RationalNumber(5, 6)));
    }

    [Test]
    public void Operator_Subtraction_ShouldReturnCorrectResult()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a - b;
        Assert.That(result, Is.EqualTo(new RationalNumber(1, 6)));
    }

    [Test]
    public void Operator_Multiplication_ShouldReturnCorrectResult()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a * b;
        Assert.That(result, Is.EqualTo(new RationalNumber(1, 6)));
    }

    [Test]
    public void Operator_Division_ShouldReturnCorrectResult()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a / b;
        Assert.That(result, Is.EqualTo(new RationalNumber(3, 2)));
    }

    [Test]
    public void Operator_Equality_ShouldReturnTrueForEqualRationalNumbers()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.IsTrue(a == b);
    }

    [Test]
    public void Operator_Inequality_ShouldReturnTrueForDifferentRationalNumbers()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        Assert.IsTrue(a != b);
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        var rationalNumber = new RationalNumber(1, 2);
        Assert.That(rationalNumber.ToString(), Is.EqualTo("1/2"));
    }

    [Test]
    public void Equals_ShouldReturnTrueForEqualRationalNumbers()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.IsTrue(a.Equals(b));
    }

    [Test]
    public void GetHashCode_ShouldReturnSameHashCodeForEqualRationalNumbers()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
    }
}