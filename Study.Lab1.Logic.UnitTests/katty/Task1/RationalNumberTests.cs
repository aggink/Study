using Study.Lab1.Logic.katty.Task1;

namespace Study.Lab1.Logic.UnitTests.katty.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void Constructor_WithDenominatorZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void Constructor_NormalizesFraction()
    {
        var fraction = new RationalNumber(2, 4);
        Assert.That(fraction.Numerator, Is.EqualTo(1));
        Assert.That(fraction.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void Constructor_HandlesNegativeDenominator()
    {
        var fraction = new RationalNumber(1, -2);
        Assert.That(fraction.Numerator, Is.EqualTo(-1));
        Assert.That(fraction.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void ToString_ReturnsCorrectFormat()
    {
        var fraction1 = new RationalNumber(3, 1);
        Assert.That(fraction1.ToString(), Is.EqualTo("3"));

        var fraction2 = new RationalNumber(3, 2);
        Assert.That(fraction2.ToString(), Is.EqualTo("3/2"));
    }

    [Test]
    public void Addition_WorksCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a + b;
        Assert.That(result.Numerator, Is.EqualTo(5));
        Assert.That(result.Denominator, Is.EqualTo(6));
    }

    [Test]
    public void Subtraction_WorksCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a - b;
        Assert.That(result.Numerator, Is.EqualTo(1));
        Assert.That(result.Denominator, Is.EqualTo(6));
    }

    [Test]
    public void Multiplication_WorksCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 3);
        var result = a * b;
        Assert.That(result.Numerator, Is.EqualTo(1));
        Assert.That(result.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void Division_WorksCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 3);
        var result = a / b;
        Assert.That(result.Numerator, Is.EqualTo(3));
        Assert.That(result.Denominator, Is.EqualTo(4));
    }

    [Test]
    public void Division_ByZero_ThrowsDivideByZeroException()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(0, 1);

        Assert.That(() => a / b, Throws.TypeOf<DivideByZeroException>());
    }

    [Test]
    public void UnaryMinus_WorksCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var result = -a;
        Assert.That(result.Numerator, Is.EqualTo(-1));
        Assert.That(result.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void Equality_WorksCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 2);
        var c = new RationalNumber(2, 4);
        var d = new RationalNumber(1, 3);

        Assert.That(a == b, Is.True);
        Assert.That(a == c, Is.True);
        Assert.That(a == d, Is.False);
        Assert.That(a != d, Is.True);
    }

    [Test]
    public void Comparison_Operators_WorkCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var c = new RationalNumber(2, 4);

        Assert.That(a > b, Is.True);
        Assert.That(b < a, Is.True);
        Assert.That(a >= c, Is.True);
        Assert.That(a <= c, Is.True);
        Assert.That(a >= b, Is.True);
        Assert.That(b <= a, Is.True);
    }

    [Test]
    public void Equals_WithNull_ReturnsFalse()
    {
        var a = new RationalNumber(1, 2);
        Assert.That(a == null, Is.False);
        Assert.That(null == a, Is.False);
    }
}