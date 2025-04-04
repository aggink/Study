using Study.Lab1.Logic.kinkiss1.task1;

namespace Study.Lab1.Logic.UnitTests.kinkiss1.task1;

[TestFixture]
public class Task1Tests
{
    [Test]
    public void Constructor_ValidInput_ShouldInitializeCorrectly()
    {
        var rationalNumber = new RationalNumber(4, 6);
        Assert.AreEqual(2, rationalNumber.Numerator);
        Assert.AreEqual(3, rationalNumber.Denominator);
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
        Assert.AreEqual(new RationalNumber(5, 6), result);
    }

    [Test]
    public void Operator_Subtraction_ShouldReturnCorrectResult()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a - b;
        Assert.AreEqual(new RationalNumber(1, 6), result);
    }

    [Test]
    public void Operator_Multiplication_ShouldReturnCorrectResult()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a * b;
        Assert.AreEqual(new RationalNumber(1, 6), result);
    }

    [Test]
    public void Operator_Division_ShouldReturnCorrectResult()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a / b;
        Assert.AreEqual(new RationalNumber(3, 2), result);
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
        Assert.AreEqual("1/2", rationalNumber.ToString());
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
        Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
    }
}