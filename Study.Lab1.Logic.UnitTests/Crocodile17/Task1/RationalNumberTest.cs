using Study.Lab1.Logic.Crocodile17.Task1;

namespace Study.Lab1.Logic.UnitTests.Crocodile17.Task1;

[TestFixture]
class RationalNumberTest
{
    [Test]
    public void ValidConstructor_ReducesFractionProperly()
    {
        var r = new RationalNumber(2, 6);
        Assert.That(r.Numerator, Is.EqualTo(1), "Ошибка сокращения числителя!");
        Assert.That(r.Denominator, Is.EqualTo(3), "Ошибка сокращения знаменателя!");
    }

    [Test]
    public void ZeroDenominator_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void AdditionOperator_CalculatesSumCorrectly()
    {
        var r1 = new RationalNumber(2, 3);
        var r2 = new RationalNumber(1, 5);
        var sum = r1 + r2;
        var expected = new RationalNumber(13, 15);
        Assert.That(sum, Is.EqualTo(expected), "Операция сложения произведена неверно!");
    }

    [Test]
    public void SubtractionOperator_CalculatesDifferenceCorrectly()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        var diff = r1 - r2;
        var expected = new RationalNumber(1, 6);
        Assert.That(diff, Is.EqualTo(expected), "Операция вычитания произведена неверно!");
    }

    [Test]
    public void MultiplicationOperator_CalculatesProductCorrectly()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        var product = r1 * r2;
        var expected = new RationalNumber(1, 6);
        Assert.That(product, Is.EqualTo(expected), "Операция умножения произведена неверно!");
    }

    [Test]
    public void DivisionOperator_CalculatesQuotientCorrectly()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        var quotient = r1 / r2;
        var expected = new RationalNumber(3, 2);
        Assert.That(quotient, Is.EqualTo(expected), "Операция деления произведена неверно!");
    }

    [Test]
    public void EqualityOperator_ReturnsTrueForEquivalentFractions()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(2, 4);
        Assert.IsTrue(r1 == r2, "Оператор равенства не распознаёт эквивалентные дроби.");
    }

    [Test]
    public void InequalityOperator_ReturnsTrueForDifferentFractions()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        Assert.IsTrue(r1 != r2, "Оператор неравенства неверно определяет разные дроби.");
    }

    [Test]
    public void ToStringMethod_ReturnsExpectedRepresentation()
    {
        var r = new RationalNumber(1, 2);
        Assert.That(r.ToString(), Is.EqualTo("1/2"), "Метод ToString возвращает неверное представление дроби.");
    }

    [Test]
    public void EqualsMethod_ReturnsTrueForEquivalentFractionObjects()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(2, 4);
        Assert.IsTrue(r1.Equals(r2), "Метод Equals не распознаёт эквивалентные объектные дроби.");
    }

    [Test]
    public void GetHashCodeMethod_ReturnsIdenticalHashForEquivalentFractions()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(2, 4);
        Assert.That(r1.GetHashCode(), Is.EqualTo(r2.GetHashCode()), "Метод GetHashCode не возвращает одинаковые значения для эквивалентных дробей.");
    }
}

