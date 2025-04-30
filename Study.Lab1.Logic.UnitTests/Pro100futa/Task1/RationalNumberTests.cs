using Study.Lab1.Logic.Pro100futa.Task1;

namespace Study.Lab1.Logic.UnitTests.Pro100futa.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void Constructor_ValidInput_ShouldInitializeCorrectly()
    {
        var A = new RationalNumber(3, 6);
        Assert.AreEqual(new RationalNumber(1, 2), A);
    }

    [Test]
    public void Operator_Addition_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(2, 9);
        var B = new RationalNumber(3, 11);
        var C = new RationalNumber(49, 99);
        var result = A + B;
        Assert.AreEqual(C, result);
    }

    [Test]
    public void Operator_Subtraction_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(2, 9);
        var B = new RationalNumber(3, 11);
        var C = new RationalNumber(-5, 99);
        var result = A - B;
        Assert.AreEqual(C, result);
    }

    [Test]
    public void Operator_Division_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(3, 9);
        var B = new RationalNumber(3, 11);
        var C = new RationalNumber(11, 9);
        var result = A / B;
        Assert.AreEqual(C, result);
    }

    [Test]
    public void Operator_Multiplication_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(3, 9);
        var B = new RationalNumber(3, 11);
        var C = new RationalNumber(1, 11);
        var result = A * B;
        Assert.AreEqual(C, result);
    }

    [Test]
    public void Operator_Equality_ShouldReturnTrueForEqualRationalNumbers()
    {
        var A = new RationalNumber(3, 9);
        var B = new RationalNumber(1, 3);
        Assert.IsTrue(A == B);
    }

    [Test]
    public void Operator_Inequality_ShouldReturnTrueForDifferentRationalNumbers()
    {
        var A = new RationalNumber(3, 9);
        var B = new RationalNumber(2, 3);
        Assert.IsTrue(A != B);
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        var A = new RationalNumber(5, 7);
        Assert.AreEqual("5/7", A.ToString());
    }

    [Test]
    public void Equals_ShouldReturnTrueForEqualRationalNumbers()
    {
        var A = new RationalNumber(2, 3);
        var B = new RationalNumber(6, 9);
        Assert.IsTrue(A.Equals(B));
    }

    [Test]
    public void GetHashCode_ShouldReturnSameHashCodeForEqualRationalNumbers()
    {
        var A = new RationalNumber(2, 3);
        var B = new RationalNumber(6, 9);
        Assert.AreEqual(A.GetHashCode(), B.GetHashCode());
    }

    [Test]
    public void Operator_Minus_ShouldReturnReverse()
    {
        var A = new RationalNumber(5, 7);
        Assert.AreEqual(new RationalNumber(-5, 7), -A);
    }

    [Test]
    public void RationalNumber_ComparisonOperators()
    {
        var A = new RationalNumber(4, 6);
        var B = new RationalNumber(2, 8);

        Assert.AreEqual(true, B < A);
        Assert.AreEqual(true, B <= A);
        Assert.AreEqual(false, B > A);
        Assert.AreEqual(false, B >= A);
    }

    [Test]
    public void Constructor_DenominatorZero_ShouldThrowDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation2()
    {
        var rationalNumber = new RationalNumber(64, 16);
        Assert.AreEqual("4", rationalNumber.ToString());
    }
}

