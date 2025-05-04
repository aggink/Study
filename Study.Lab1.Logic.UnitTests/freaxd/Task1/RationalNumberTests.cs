using Study.Lab1.Logic.freaxd.Task1;

namespace Study.Lab1.Logic.UnitTests.freaxd.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void CorrectAddition()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a + b;
        var expected = new RationalNumber(5, 6);
        Assert.That(result, Is.EqualTo(expected), "Операция сложения выполнена неверно.");
    }

    [Test]
    public void CorrectSubtraction()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a - b;
        var expected = new RationalNumber(1, 6);
        Assert.That(result, Is.EqualTo(expected), "Операция вычитания выполнена неверно.");
    }

    [Test]
    public void CorrectMultiplication()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a * b;
        var expected = new RationalNumber(1, 6);
        Assert.That(result, Is.EqualTo(expected), "Операция умножения выполнена неверно.");
    }

    [Test]
    public void CorrectDivision()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var result = a / b;
        var expected = new RationalNumber(3, 2);
        Assert.That(result, Is.EqualTo(expected), "Операция деления выполнена неверно.");
    }

    [Test]
    public void CheckDivisionByZero()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(0, 1);
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
        Assert.Throws<DivideByZeroException>(() => { var result = a / b; });
    }

    [Test]
    public void CorrectUnaryNegation()
    {
        var a = new RationalNumber(1, 2);
        var result = -a;
        var expected = new RationalNumber(-1, 2);
        Assert.That(result, Is.EqualTo(expected), "Операция унарного отрицания выполнена неверно.");
    }

    [Test]
    public void CorrectEquality()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.IsTrue(a == b, "Операция равенства выполнена неверно.");
    }

    [Test]
    public void CorrectInequality()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        Assert.IsTrue(a != b, "Операция неравенства выполнена неверно.");
    }

    [Test]
    public void CorrectLessSign()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        Assert.IsTrue(b < a, "Операция знака меньше выполнена неверно.");
    }

    [Test]
    public void CorrectLessOrEqualSign()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var c = new RationalNumber(1, 3);
        Assert.IsTrue(b <= a, "Операция знака меньше или равно выполнена неверно.");
        Assert.IsTrue(b <= c, "Операция знака меньше или равно не распознаёт одинаковые дроби.");
    }

    [Test]
    public void CorrectGreaterSign()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        Assert.IsTrue(a > b, "Операция знака больше выполнена неверно.");
    }

    [Test]
    public void CorrectGreaterOrEqualSign()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var c = new RationalNumber(1, 3);
        Assert.IsTrue(a >= b, "Операция знака меньше или равно выполнена неверно.");
        Assert.IsTrue(b >= c, "Операция знака меньше или равно не распознаёт одинаковые дроби.");
    }

    [Test]
    public void CorrectToStringMethod()
    {
        var a = new RationalNumber(1, 2);
        Assert.That(a.ToString(), Is.EqualTo("1/2"), "Метод ToString возвращает неверное значение.");
    }

    [Test]
    public void CorrectEqualsMethod()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.IsTrue(a.Equals(b), "Метод Equals возвращает неверное значение.");
    }

    [Test]
    public void CorrectGetHashCodeMethod()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()), "Метод GetHashCode возвращает неверное значение.");
    }
}