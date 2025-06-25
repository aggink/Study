using Study.Lab1.Logic.Kotsutaki.Task1;

namespace Study.Lab1.Logic.UnitTests.Kotsutaki.Task1;

[TestFixture]

public class RationalNumberTests
{
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
        Assert.That(a == b, Is.True);
    }

    [Test]
    public void Operator_Inequality_ShouldReturnTrueForDifferentRationalNumbers()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        Assert.That(a != b, Is.True);
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
        Assert.That(a.Equals(b), Is.True);
    }

    [Test]
    public void GetHashCode_ShouldReturnSameHashCodeForEqualRationalNumbers()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
    }
}