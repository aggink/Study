using System;
using NUnit.Framework;
using Study.Lab1.Logic.p0se1d0nov.Task1;

namespace Study.Lab1.Logic.UnitTests.p0se1d0nov.Task1;

[TestFixture]
public class RationalTests
{
    [Test]
    public void Constructor_WithValidParameters_SimplifiesFraction()
    {
        var rational = new Rational(4, 6);
        Assert.That(rational.Numerator, Is.EqualTo(2));
        Assert.That(rational.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void Constructor_WithNegativeDenominator_MovesSignToNumerator
    {
        var rational = new Rational(1, -2);
        Assert.That(rational.Numerator, Is.EqualTo(-1));
        Assert.That(rational.Denominator, Is.EqualTo(2));
    }
  

    [Test]
    public void Equality_Operator_ReturnsTrueForEqualFractions()
    {
        var a = new Rational(2, 5);
        var b = new Rational(2, 5);
        Assert.IsTrue(a == b);
    }

    [Test]
    public void Equality_Operator_ReturnsFalseForDifferentFractions()
    {
        var a = new Rational(1, 5);
        var b = new Rational(2, 5);
        Assert.IsFalse(a == b);
    }

    [Test]
    public void Inequality_Operator_ReturnsTrueForDifferentFractions()
    {
        var a = new Rational(1, 5);
        var b = new Rational(2, 5);
        Assert.IsTrue(a != b);
    }

    [Test]
    public void LessThan_Operator_ReturnsCorrectResults()
    {
        var a = new Rational(1, 5);
        var b = new Rational(2, 5);
        Assert.IsTrue(a < b);
        Assert.IsFalse(b < a);
        Assert.IsFalse(b < new Rational(2, 5));
    }

    [Test]
    public void LessThanOrEqual_Operator_ReturnsCorrectResults()
    {
        var a = new Rational(1, 5);
        var b = new Rational(2, 5);
        Assert.IsTrue(a <= b);
        Assert.IsTrue(b <= new Rational(2, 5));
        Assert.IsFalse(b <= a);
    }

    [Test]
    public void GreaterThan_Operator_ReturnsCorrectResults()
    {
        var a = new Rational(1, 5);
        var b = new Rational(2, 5);
        Assert.IsTrue(b > a);
        Assert.IsFalse(a > b);
        Assert.IsFalse(b > new Rational(2, 5));
    }

    [Test]
    public void GreaterThanOrEqual_Operator_ReturnsCorrectResults()
    {
        var a = new Rational(1, 5);
        var b = new Rational(2, 5);
        Assert.IsTrue(b >= a);
        Assert.IsTrue(b >= new Rational(2, 5));
        Assert.IsFalse(a >= b);
    }

    [Test]
    public void ToString_WithDenominatorOne_ReturnsIntegerString()
    {
        var rational = new Rational(3, 1);
        Assert.That(rational.ToString(), Is.EqualTo("3"));
    }

    [Test]
    public void ToString_WithDenominatorNotOne_ReturnsFractionString()
    {
        var rational = new Rational(2, 3);
        Assert.That(rational.ToString(), Is.EqualTo("2/3"));
    }

    [Test]
    public void GetAsDouble_ReturnsCorrectDecimalValue()
    {
        var rational = new Rational(1, 2);
        Assert.That(rational.GetAsDouble(), Is.EqualTo(0.5));
    }
}
