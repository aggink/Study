using Study.Lab1.Logic.alexmark1612.Task1;
using Study.Lab1.Logic.Jki749.Task1;

namespace Study.Lab1.Logic.UnitTests.alexmark1612.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void ValidClassConstructorTest()
    {
        var a = new RationalNumber(4, 8);
        Assert.That(a.Numerator, Is.EqualTo(1), "Числитель не сокращён правильно.");
        Assert.That(a.Denominator, Is.EqualTo(2), "Знаменатель не сокращён правильно.");
    }
    [Test]
    public void ValidClassConstructorTestDenominatorDivingByZero()
    {
        var a = new RationalNumber(1, -3);
        Assert.That(a.Numerator, Is.EqualTo(-1), "Числитель не сокращён правильно.");
        Assert.That(a.Denominator, Is.EqualTo(3), "Знаменатель не сокращён правильно.");
    }
    [Test]
    public void ValidClassConstructorZeroDenominatorTest()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }
    [Test]
    public void ValidSummatorOperatorTest()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var sum = a + b;
        var expected = new RationalNumber(5, 6);
        Assert.That(sum, Is.EqualTo(expected), "Операция сложения выполнена неверно.");
    }
    [Test]
    public void ValidSubtractionOperatorTest()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var diff = a - b;
        var expected = new RationalNumber(1, 6);
        Assert.That(diff, Is.EqualTo(expected), "Операция вычитания выполнена неверно.");
    }
    [Test]
    public void ValidMultiplicationOperatorTest()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var product = a * b;
        var expected = new RationalNumber(1, 6);
        Assert.That(product, Is.EqualTo(expected), "Операция умножения не даёт ожидаемый результат.");
    }
    [Test]
    public void ValidDivisionOperatorTest()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var quotient = a / b;
        var expected = new RationalNumber(3, 2);
        Assert.That(quotient, Is.EqualTo(expected), "Операция деления не даёт ожидаемый результат.");
    }
    [Test]
    public void ValidUnaryMinusOperatorTest()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var quotient = -a - b;
        var expected = new RationalNumber(-5, 6);
        Assert.That(quotient, Is.EqualTo(expected), "Операция деления не даёт ожидаемый результат.");
    }
    [Test]
    public void ValidEqualityOperatorTest()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.IsTrue(a == b, "Оператор равенства не распознаёт эквивалентные дроби.");
    }
    [Test]
    public void ValidInequalityOperatorTest()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        Assert.IsTrue(a != b, "Оператор неравенства неверно определяет разные дроби.");
    }
    [Test]
    public void ValidBiggerOperatorTest()
    {
        var a = new RationalChislo(1, 2);
        var b = new RationalChislo(1, 3);
        Assert.IsTrue(a > b);
    }
    [Test]
    public void ValidSmallerOperatorTest()
    {
        var a = new RationalChislo(1, 2);
        var b = new RationalChislo(1, 3);
        Assert.IsTrue(b < a);
    }
    [Test]
    public void ValidBiggerOrEqualOperatorTest()
    {
        var a = new RationalChislo(1, 2);
        var b = new RationalChislo(1, 3);
        Assert.IsTrue(a >= b);
    }
    [Test]
    public void ValidSmallerOrEqualOperatorTest()
    {
        var a = new RationalChislo(1, 2);
        var b = new RationalChislo(1, 3);
        Assert.IsTrue(b <= a);
    }
    [Test]
    public void ToStringMethod()
    {
        var a = new RationalNumber(1, 2);
        Assert.That(a.ToString(), Is.EqualTo("1/2"), "Метод ToString возвращает неверное представление дроби.");
    }
    [Test]
    public void EqualsMethod()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.IsTrue(a.Equals(b), "Метод Equals не распознаёт эквивалентные объектные дроби.");
    }
    [Test]
    public void GetHashCodeMethod()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()), "Метод GetHashCode не возвращает одинаковые значения для эквивалентных дробей.");
    }
}