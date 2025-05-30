using Study.Lab1.Logic.love100rubb.Task1;

namespace Study.Lab1.Logic.UnitTests.love100rubb.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void correctlyInput()
    {
        var value = new RationalNumber(5, 10);
        Assert.AreEqual(1, value.Numerator);
        Assert.AreEqual(2, value.Denominator);
    }

    [Test]
    public void correctlySumm()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        var result = firstValue + secondValue;
        Assert.AreEqual(new RationalNumber(29, 28), result);
    }

    [Test]
    public void correctlyMultiply()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        var result = firstValue * secondValue;
        Assert.AreEqual(new RationalNumber(6, 28), result);
    }

    [Test]
    public void correctlyDivide() 
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        var result = firstValue / secondValue;
        Assert.AreEqual(new RationalNumber(21, 8), result);
    }

    [Test]
    public void correctlySubtraction() 
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        var result = firstValue - secondValue;
        Assert.AreEqual(new RationalNumber(13, 28), result);
    }

    [Test]
    public void correctlyEquality() 
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(6, 8);
        Assert.IsTrue(firstValue == secondValue);
    }

    [Test]
    public void correctlyInequality() 
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        Assert.IsTrue(firstValue != secondValue);
    }

    [Test]
    public void correctlyToString() 
    {
        var value = new RationalNumber(3, 4);
        Assert.AreEqual("3/4", value.ToString());
    }

    [Test]
    public void correctlyReturnEquals() 
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(6, 8);
        Assert.IsTrue(firstValue.Equals(secondValue));
    }

    [Test]
    public void correctlyHashCode()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(6, 8);
        Assert.AreEqual(firstValue.GetHashCode(), secondValue.GetHashCode());
    }

    [Test]
    public void correctlyOtricanie() 
    {
        var value = new RationalNumber(3, 4);
        Assert.AreEqual(new RationalNumber(-3, 4), -value);
    }

    [Test]
    public void correctlySravnenie() 
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);

        Assert.That(secondValue < firstValue, Is.True);
        Assert.That(secondValue <= firstValue, Is.True);
        Assert.That(secondValue > firstValue, Is.False);
        Assert.That(secondValue >= firstValue, Is.False);

    }

    [Test]
    public void correctlyZerooo() 
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void correctlySokrashenieToString() 
    {
        var value = new RationalNumber(33, 11);
        Assert.AreEqual("3", value.ToString());
    }

}
