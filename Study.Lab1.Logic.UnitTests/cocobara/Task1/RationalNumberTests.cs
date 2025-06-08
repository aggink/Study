using Study.Lab1.Logic.cocobara.Task1;

namespace Study.Lab1.Logic.UnitTests.cocobara.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void RationalNumber_CorrectSum()
    {
        var A = new RationalNumber(3, 2);
        var B = new RationalNumber(1, 3);

        var result = A + B;

<<<<<<< HEAD
        Assert.That(result.Numerator, Is.EqualTo(11)); 
=======
        Assert.That(result.Numerator, Is.EqualTo(11));
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        Assert.That(result.Denominator, Is.EqualTo(6));
    }

    [Test]
    public void RationalNumber_CorrectSubtraction()
    {
        var A = new RationalNumber(5, 6);
        var B = new RationalNumber(1, 3);

        var result = A - B;

        Assert.That(result.Numerator, Is.EqualTo(1));
        Assert.That(result.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_CorrectMultiplication()
    {
        var A = new RationalNumber(2, 3);
        var B = new RationalNumber(3, 4);

        var result = A * B;

        Assert.That(result.Numerator, Is.EqualTo(1));
        Assert.That(result.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_CorrectDivision()
    {
        var A = new RationalNumber(2, 3);
        var B = new RationalNumber(3, 4);

        var result = A / B;

        Assert.That(result.Numerator, Is.EqualTo(8));
        Assert.That(result.Denominator, Is.EqualTo(9));
    }

    [Test]
    public void RationalNumber_DivisionByZero_ThrowsException()
    {
        var A = new RationalNumber(1, 2);
        var B = new RationalNumber(0, 1);


        Assert.Throws<DivideByZeroException>(() =>
        {
            var result = A / B;
        });
    }

    [Test]
    public void RationalNumber_CorrectNegate()
    {
        var A = new RationalNumber(1, 2);
        var B = -A;

        Assert.That(B.Numerator, Is.EqualTo(-1));
        Assert.That(B.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_CorrectEquals()
    {
        var A = new RationalNumber(1, 2);
        var B = new RationalNumber(1, 2);

        var result = A == B;
        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_CorrectMultiOperation()
    {
        var A = new RationalNumber(1, 2);
        var B = new RationalNumber(9, 3);

        var C = A * B;
        var D = (A + B) / A;
        C += D;
        C -= B;
        C = -C;

        Assert.That(C.Numerator, Is.EqualTo(-11));
        Assert.That(C.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void RationalNumber_CorrectMinusMultiplication()
    {
        var A = new RationalNumber(8, -12);
        var B = new RationalNumber(93, 8);
        var C = A * B;
        Assert.That(C.Numerator, Is.EqualTo(-31));
        Assert.That(C.Denominator, Is.EqualTo(4));
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
        var A = new RationalNumber(3, 4);
        var B = new RationalNumber(1, 2);

        var result = A > B;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_GreaterThan_ReturnsFalse_WhenLeftIsLess()
    {
        var A = new RationalNumber(1, 3);
        var B = new RationalNumber(1, 2);

        var result = A > B;

        Assert.That(result, Is.False);
    }

    [Test]
    public void RationalNumber_LessThan_ReturnsTrue_WhenLeftIsLess()
    {
        var A = new RationalNumber(1, 3);
        var B = new RationalNumber(1, 2);

        var result = A < B;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_LessThan_ReturnsFalse_WhenLeftIsGreater()
    {
        var A = new RationalNumber(3, 4);
        var B = new RationalNumber(1, 2);

        var result = A < B;

        Assert.That(result, Is.False);
    }

    [Test]
    public void RationalNumber_GreaterThanOrEqual_ReturnsTrue_WhenLeftIsGreater()
    {
        var A = new RationalNumber(3, 4);
        var B = new RationalNumber(1, 2);

        var result = A >= B;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_GreaterThanOrEqual_ReturnsTrue_WhenEqual()
    {
        var A = new RationalNumber(1, 2);
        var B = new RationalNumber(2, 4);

        var result = A >= B;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_LessThanOrEqual_ReturnsTrue_WhenLeftIsLess()
    {
        var A = new RationalNumber(1, 3);
        var B = new RationalNumber(1, 2);

        var result = A <= B;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_LessThanOrEqual_ReturnsTrue_WhenEqual()
    {
        var A = new RationalNumber(1, 2);
        var B = new RationalNumber(2, 4);

        var result = A <= B;

        Assert.That(result, Is.True);
    }

    [Test]
    public void RationalNumber_ComparisonOperators_WorkWithNegativeNumbers()
    {
        var A = new RationalNumber(-1, 2);
        var B = new RationalNumber(1, 4);

        Assert.That(A < B, Is.True);
        Assert.That(A <= B, Is.True);
        Assert.That(A > B, Is.False);
        Assert.That(A >= B, Is.False);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
