using Study.Lab1.Logic.yamisakimei.Task1;

namespace Study.Lab1.Logic.UnitTests.yamisakimei.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void СorrectlyInput()
    {
        var value = new RationalNumber(5, 10);
        Assert.AreEqual(1, value.Numerator);
        Assert.AreEqual(2, value.Denominator);
    }

    [Test]
    public void СorrectlySumm()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        var result = firstValue + secondValue;
        Assert.AreEqual(new RationalNumber(29, 28), result);
    }

    [Test]
    public void СorrectlyMultiply()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        var result = firstValue * secondValue;
        Assert.AreEqual(new RationalNumber(6, 28), result);
    }

    [Test]
    public void СorrectlyDivide()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        var result = firstValue / secondValue;
        Assert.AreEqual(new RationalNumber(21, 8), result);
    }

    [Test]
    public void СorrectlySubtraction()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        var result = firstValue - secondValue;
        Assert.AreEqual(new RationalNumber(13, 28), result);
    }

    [Test]
    public void СorrectlyEquality()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(6, 8);
        Assert.IsTrue(firstValue == secondValue);
    }

    [Test]
    public void СorrectlyInequality()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        Assert.IsTrue(firstValue != secondValue);
    }

    [Test]
    public void СorrectlyToString()
    {
        var value = new RationalNumber(3, 4);
        Assert.AreEqual("3/4", value.ToString());
    }

    [Test]
    public void СorrectlyReturnEquals()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(6, 8);
        Assert.IsTrue(firstValue.Equals(secondValue));
    }

    [Test]
    public void СorrectlyHashCode()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(6, 8);
        Assert.AreEqual(firstValue.GetHashCode(), secondValue.GetHashCode());
    }

    [Test]
    public void СorrectlyOtricanie()
    {
        var value = new RationalNumber(3, 4);
        Assert.AreEqual(new RationalNumber(-3, 4), -value);
    }

    [Test]
    public void СorrectlySravnenie()
    {
        var firstValue = new RationalNumber(3, 4);
        var secondValue = new RationalNumber(2, 7);
        Assert.That(secondValue < firstValue, Is.True);
        Assert.That(secondValue <= firstValue, Is.True);
        Assert.That(secondValue > firstValue, Is.False);
        Assert.That(secondValue >= firstValue, Is.False);
    }

    [Test]
    public void СorrectlyZerooo()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void СorrectlySokrashenieToString()
    {
        var value = new RationalNumber(33, 11);
        Assert.AreEqual("3", value.ToString());
    }
}