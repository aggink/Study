using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab1.Logic.Maxtir23.Task1;

namespace Study.Lab1.Logic.UnitTests.Maxtir23.Task1;

[TestFixture]
public class RationalNumberTest
{
    [Test]
    public void correctlyInput()
    {
        var value = new RationalNumber(3, 15);
        Assert.AreEqual(1, value.Numerator);
        Assert.AreEqual(5, value.Denominator);
    }

    [Test]
    public void correctlySumm()
    {
        var firstValue = new RationalNumber(1, 3);
        var secondValue = new RationalNumber(3, 15);
        var result = firstValue + secondValue;
        Assert.AreEqual(new RationalNumber(8, 15), result);
    }

    [Test]
    public void correctlyMultiply()
    {
        var firstValue = new RationalNumber(1, 3);
        var secondValue = new RationalNumber(3, 15);
        var result = firstValue * secondValue;
        Assert.AreEqual(new RationalNumber(3, 45), result);
    }

    [Test]
    public void correctlyDivide()
    {
        var firstValue = new RationalNumber(1, 3);
        var secondValue = new RationalNumber(3, 15);
        var result = firstValue / secondValue;
        Assert.AreEqual(new RationalNumber(5, 3), result);
    }

    [Test]
    public void correctlySubtraction()
    {
        var firstValue = new RationalNumber(1, 3);
        var secondValue = new RationalNumber(3, 15);
        var result = firstValue - secondValue;
        Assert.AreEqual(new RationalNumber(2, 15), result);
    }

    [Test]
    public void correctlyEquality()
    {
        var firstValue = new RationalNumber(1, 5);
        var secondValue = new RationalNumber(3, 15);
        Assert.IsTrue(firstValue == secondValue);
    }

    [Test]
    public void correctlyInequality()
    {
        var firstValue = new RationalNumber(1, 3);
        var secondValue = new RationalNumber(3, 15);
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
        var firstValue = new RationalNumber(1, 3);
        var secondValue = new RationalNumber(2, 6);
        Assert.IsTrue(firstValue.Equals(secondValue));
    }

    [Test]
    public void correctlyHashCode()
    {
        var firstValue = new RationalNumber(1, 3);
        var secondValue = new RationalNumber(2, 6);
        Assert.AreEqual(firstValue.GetHashCode(), secondValue.GetHashCode());
    }

    [Test]
    public void correctlyOtricanie()
    {
        var value = new RationalNumber(1, 3);
        Assert.AreEqual(new RationalNumber(-1, 3), -value);
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
        var value = new RationalNumber(21, 7);
        Assert.AreEqual("3", value.ToString());
    }
}
