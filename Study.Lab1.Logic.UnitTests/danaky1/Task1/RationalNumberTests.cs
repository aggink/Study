using Study.Lab1.Logic.danaky1.Task1;

namespace Study.Lab1.Logic.UnitTests.danaky1.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void ValidConstructor_ReducesFractionProperly()
    {
        var a = new RationalNumber(4, 10);
        Assert.That(a.Numerator, Is.EqualTo(2), "Числитель не сокращён правильно.");
        Assert.That(a.Denominator, Is.EqualTo(5), "Знаменатель не сокращён правильно.");
    }

    [Test]
    public void ZeroDenominator_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void AdditionOperator_CalculatesSumCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var sum = a + b;
        var expected = new RationalNumber(5, 6);
        Assert.That(sum, Is.EqualTo(expected), "Операция сложения выполнена неверно.");
    }

    [Test]
    public void SubtractionOperator_CalculatesDifferenceCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var diff = a - b;
        var expected = new RationalNumber(1, 6);
        Assert.That(diff, Is.EqualTo(expected), "Операция вычитания выполнена неверно.");
    }

    [Test]
    public void MultiplicationOperator_CalculatesProductCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var product = a * b;
        var expected = new RationalNumber(1, 6);
        Assert.That(product, Is.EqualTo(expected), "Операция умножения не даёт ожидаемый результат.");
    }

    [Test]
    public void DivisionOperator_CalculatesQuotientCorrectly()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        var quotient = a / b;
        var expected = new RationalNumber(3, 2);
        Assert.That(quotient, Is.EqualTo(expected), "Операция деления не даёт ожидаемый результат.");
    }

    [Test]
    public void EqualityOperator_ReturnsTrueForEquivalentFractions()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.IsTrue(a == b, "Оператор равенства не распознаёт эквивалентные дроби.");
    }

    [Test]
    public void InequalityOperator_ReturnsTrueForDifferentFractions()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(1, 3);
        Assert.IsTrue(a != b, "Оператор неравенства неверно определяет разные дроби.");
    }

    [Test]
    public void ToStringMethod_ReturnsExpectedRepresentation()
    {
        var a = new RationalNumber(1, 2);
        Assert.That(a.ToString(), Is.EqualTo("1/2"), "Метод ToString возвращает неверное представление дроби.");
    }

    [Test]
    public void EqualsMethod_ReturnsTrueForEquivalentFractionObjects()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.IsTrue(a.Equals(b), "Метод Equals не распознаёт эквивалентные объектные дроби.");
    }

    [Test]
    public void GetHashCodeMethod_ReturnsIdenticalHashForEquivalentFractions()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(2, 4);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()), "Метод GetHashCode не возвращает одинаковые значения для эквивалентных дробей.");
    }
}