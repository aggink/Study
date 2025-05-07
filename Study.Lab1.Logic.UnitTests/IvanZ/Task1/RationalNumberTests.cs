using Study.Lab1.Logic.IvanZ.Task1;

namespace Study.Lab1.Logic.UnitTests.IvanZ.Task1;

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
        var A = new RationalNumber(5, 12);
        var B = new RationalNumber(1, 23);
        var C = new RationalNumber(127, 276);
        var result = A + B;
        
        Assert.AreEqual(C, result);
    }

    [Test]
    public void Operator_Subtraction_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(5, 12);
        var B = new RationalNumber(1, 23);
        var C = new RationalNumber(103, 276);
        var result = A - B;
        
        Assert.AreEqual(C, result);
    }

    [Test]
    public void Operator_Division_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(5, 12);
        var B = new RationalNumber(23, 12);
        var C = new RationalNumber(5, 23);
        var result = A / B;
        
        Assert.AreEqual(C, result);
    }

    [Test]
    public void Operator_Multiplication_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(5, 12);
        var B = new RationalNumber(12, 23);
        var C = new RationalNumber(5, 23);
        var result = A * B;
        
        Assert.AreEqual(C, result);
    }

    [Test]
    public void Operator_Equality_ShouldReturnTrueForEqualRationalNumbers()
    {
        var A = new RationalNumber(2, 4);
        var B = new RationalNumber(1, 2);
        
        Assert.IsTrue(A == B);
    }

    [Test]
    public void Operator_Inequality_ShouldReturnTrueForDifferentRationalNumbers()
    {
        var A = new RationalNumber(1, 2);
        var B = new RationalNumber(1, 3);
        
        Assert.IsTrue(A != B);
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        var A = new RationalNumber(1, 2);
        
        Assert.AreEqual("1/2", A.ToString());
    }
    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation2()
    {
        var rationalNumber = new RationalNumber(12, 2);
        
        Assert.AreEqual("6", rationalNumber.ToString());
    }

    [Test]
    public void Operator_Minus_ShouldReturnReverse()
    {
        var A = new RationalNumber(1, 2);
        
        Assert.AreEqual(new RationalNumber(-1, 2), -A);
    }

    [Test]
    public void RationalNumber_ComparisonOperators()
    {
        var A = new RationalNumber(5, 7);
        var B = new RationalNumber(1, 7);

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
}
