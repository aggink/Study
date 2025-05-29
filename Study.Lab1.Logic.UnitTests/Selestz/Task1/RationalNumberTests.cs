using Study.Lab1.Logic.Selestz.Task1;

namespace Study.Lab1.Logic.UnitTests.Selestz.Task1;

[TestFixture]
public class Task1Tests
{
    [Test]
    public void Constructor_ValidInput_ShouldInitializeCorrectly()
    {
        var rationalNumber = new RationalNumber(6, 12);
        Assert.AreEqual(1, rationalNumber.Numerator);
        Assert.AreEqual(2, rationalNumber.Denominator);
    }

    [Test]
    public void Operator_Addition_ShouldReturnCorrectResult()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(1, 4);
        var result = FirstNumber + SecondNumber;
        Assert.AreEqual(new RationalNumber(11, 12), result);
    }

    [Test]
    public void Operator_Subtraction_ShouldReturnCorrectResult()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(1, 4);
        var result = FirstNumber - SecondNumber;
        Assert.AreEqual(new RationalNumber(5, 12), result);
    }

    [Test]
    public void Operator_Division_ShouldReturnCorrectResult()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(1, 4);
        var result = FirstNumber / SecondNumber;
        Assert.AreEqual(new RationalNumber(8, 3), result);
    }

    [Test]
    public void Operator_Multiplication_ShouldReturnCorrectResult()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(1, 4);
        var result = FirstNumber * SecondNumber;
        Assert.AreEqual(new RationalNumber(1, 6), result);
    }

    [Test]
    public void Operator_Equality_ShouldReturnTrueForEqualRationalNumbers()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(4, 6);
        Assert.IsTrue(FirstNumber == SecondNumber);
    }

    [Test]
    public void Operator_Inequality_ShouldReturnTrueForDifferentRationalNumbers()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(1, 4);
        Assert.IsTrue(FirstNumber != SecondNumber);
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        var rationalNumber = new RationalNumber(2, 3);
        Assert.AreEqual("2/3", rationalNumber.ToString());
    }

    [Test]
    public void Equals_ShouldReturnTrueForEqualRationalNumbers()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(4, 6);
        Assert.IsTrue(FirstNumber.Equals(SecondNumber));
    }

    [Test]
    public void GetHashCode_ShouldReturnSameHashCodeForEqualRationalNumbers()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(4, 6);
        Assert.AreEqual(FirstNumber.GetHashCode(), SecondNumber.GetHashCode());
    }

    [Test]
    public void Operator_Minus_ShouldReturnReverse()
    {
        var FirstNumber = new RationalNumber(2, 3);
        Assert.AreEqual(new RationalNumber(-2, 3), -FirstNumber);
    }

    [Test]
    public void RationalNumber_ComparisonOperators()
    {
        var FirstNumber = new RationalNumber(2, 3);
        var SecondNumber = new RationalNumber(1, 4);

        Assert.That(SecondNumber < FirstNumber, Is.True);
        Assert.That(SecondNumber <= FirstNumber, Is.True);
        Assert.That(SecondNumber > FirstNumber, Is.False);
        Assert.That(SecondNumber >= FirstNumber, Is.False);
    }

    [Test]
    public void Constructor_DenominatorZero_ShouldThrowDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation2()
    {
        var rationalNumber = new RationalNumber(52, 13);
        Assert.AreEqual("4", rationalNumber.ToString());
    }
}