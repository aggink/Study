using Study.Lab1.Logic.alkeivi.Task1;
using Study.Lab1.Logic.Jki749.Task1;

namespace Study.Lab1.Logic.UnitTests.alkeivi.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void ValidConstructorInput()
    {
        var a = new RationalNumber(6, 12);
        Assert.That(a.Numerator, Is.EqualTo(1), "Числитель не сокращён правильно.");
        Assert.That(a.Denominator, Is.EqualTo(2), "Знаменатель не сокращён правильно.");
    }

    [Test]
    public void ZeroDenominator()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void AdditionOperator()
    {
        var a = new RationalNumber(1, 5);
        var b = new RationalNumber(1, 6);
        var sum = a + b;
        var expected = new RationalNumber(11, 30);
        Assert.That(sum, Is.EqualTo(expected), "Операция сложения выполнена неверно.");
    }

    [Test]
    public void SubtractionOperator()
    {
        var a = new RationalNumber(1, 5);
        var b = new RationalNumber(1, 6);
        var diff = a - b;
        var expected = new RationalNumber(1, 30);
        Assert.That(diff, Is.EqualTo(expected), "Операция вычитания выполнена неверно.");
    }

    [Test]
    public void MultiplicationOperator()
    {
        var a = new RationalNumber(1, 5);
        var b = new RationalNumber(1, 6);
        var product = a * b;
        var expected = new RationalNumber(1, 30);
        Assert.That(product, Is.EqualTo(expected), "Операция умножения не даёт ожидаемый результат.");
    }

    [Test]
    public void DivisionOperator()
    {
        var a = new RationalNumber(1, 5);
        var b = new RationalNumber(1, 6);
        var quotient = a / b;
        var expected = new RationalNumber(6, 5);
        Assert.That(quotient, Is.EqualTo(expected), "Операция деления не даёт ожидаемый результат.");
    }

    [Test]
    public void UnaryMinusOperator()
    {
        var a = new RationalNumber(-1, 5);
        var b = new RationalNumber(1, 6);
        var quotient = a - b;
        var expected = new RationalNumber(-11, 30);
        Assert.That(quotient, Is.EqualTo(expected), "Операция деления не даёт ожидаемый результат.");
    }

    [Test]
    public void EqualityOperator()
    {
        var a = new RationalNumber(1, 3);
        var b = new RationalNumber(2, 6);
        Assert.IsTrue(a == b, "Оператор равенства не распознаёт эквивалентные дроби.");
    }

    [Test]
    public void InequalityOperator()
    {
        var a = new RationalNumber(1, 5);
        var b = new RationalNumber(1, 6);
        Assert.IsTrue(a != b, "Оператор неравенства неверно определяет разные дроби.");
    }

    [Test]
    public void BiggerOperator()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 3);
        Assert.IsTrue(chislo1 > chislo2);
    }

    [Test]
    public void SmallerOperator()
    {
        var chislo1 = new RationalChislo(1, 3);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsTrue(chislo1 < chislo2);
    }

    [Test]
    public void BiggerOrEqualOperator()
    {
        var chislo1 = new RationalChislo(3, 4);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsTrue(chislo1 >= chislo2);
    }

    [Test]
    public void SmallerOrEqualOperator()
    {
        var chislo1 = new RationalChislo(1, 3);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsTrue(chislo1 <= chislo2);
    }

    [Test]
    public void ToStringMethod()
    {
        var a = new RationalNumber(1, 3);
        Assert.That(a.ToString(), Is.EqualTo("1/3"), "Метод ToString возвращает неверное представление дроби.");
    }

    [Test]
    public void EqualsMethod()
    {
        var a = new RationalNumber(1, 5);
        var b = new RationalNumber(2, 10);
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
