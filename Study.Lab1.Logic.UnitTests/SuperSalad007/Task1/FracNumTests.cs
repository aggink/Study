using Study.Lab1.Logic.SuperSalad007.Task1;

namespace Study.Lab1.Logic.UnitTests.SuperSalad007.Task1;

[TestFixture]
public class FracNumTests
{
    /* “ест 1: проверка на сокращение неправильной дроби
     * “ест 2:проверка на дурака нет делени€ на ноль
     * “ест 3:проверка на вывод целого числа(только число без знаменател€)
     * “ест 4:проверка корректной работы с отрицательными значени€ми в числителе или в знаменателе
     * “ест 5:проверка на корректный вывод дроби 
     * “ест 6:проверка работы оператора +
     * “ест 7:проверка работы оператора -
     * “ест 8:проверка работы оператора *
     * “ест 9:проверка работы оператора /
     * “ест 10:проверка работы оператора унарный минус
     * “ест 11:проверка работы оператора ==
     * “ест 12:проверка работы оператора !=
     * “ест 13:проверка работы оператора <
     * “ест 14:проверка работы оператора <=
     * “ест 15:проверка работы оператора >
     * “ест 16:проверка работы оператора >=
    */

    [Test]
    public void Constructor_ValidInput_ShouldInitializeCorrectly()
    {
        var rationalNumber = new FracNumber(3, 6);
        Assert.AreEqual(1, rationalNumber.NumeratorPart);
        Assert.AreEqual(2, rationalNumber.DenominatorPart);
    }

    [Test]
    public void Operator_Addition_ShouldReturnCorrectResult()
    {
        var A = new FracNumber(4, 6);
        var B = new FracNumber(2, 8);
        var Result = A + B;
        Assert.AreEqual(new FracNumber(11, 12), Result);
    }

    [Test]
    public void Operator_Subtraction_ShouldReturnCorrectResult()
    {
        var A = new FracNumber(4, 6);
        var B = new FracNumber(2, 8);
        var Result = A - B;
        Assert.AreEqual(new FracNumber(5, 12), Result);
    }

    [Test]
    public void Operator_Division_ShouldReturnCorrectResult()
    {
        var A = new FracNumber(4, 6);
        var B = new FracNumber(2, 8);
        var Result = A / B;
        Assert.AreEqual(new FracNumber(8, 3), Result);
    }

    [Test]
    public void Operator_Multiplication_ShouldReturnCorrectResult()
    {
        var A = new FracNumber(4, 6);
        var B = new FracNumber(2, 8);
        var Result = A * B;
        Assert.AreEqual(new FracNumber(1, 6), Result);
    }

    [Test]
    public void Operator_Equality_ShouldReturnTrueForEqualRationalNumbers()
    {
        var A = new FracNumber(4, 6);
        var B = new FracNumber(2, 3);
        Assert.IsTrue(A == B);
    }

    [Test]
    public void Operator_Inequality_ShouldReturnTrueForDifferentRationalNumbers()
    {
        var A = new FracNumber(4, 6);
        var B = new FracNumber(2, 8);
        Assert.IsTrue(A != B);
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        var rationalNumber = new FracNumber(5, 7);
        Assert.AreEqual("5/7", rationalNumber.ToString());
    }

    [Test]
    public void Equals_ShouldReturnTrueForEqualRationalNumbers()
    {
        var A = new FracNumber(2, 3);
        var B = new FracNumber(6, 9);
        Assert.IsTrue(A.Equals(B));
    }

    [Test]
    public void GetHashCode_ShouldReturnSameHashCodeForEqualRationalNumbers()
    {
        var A = new FracNumber(2, 3);
        var B = new FracNumber(6, 9);
        Assert.AreEqual(A.GetHashCode(), B.GetHashCode());
    }

    [Test]
    public void Operator_Minus_ShouldReturnReverse()
    {
        var A = new FracNumber(5, 7);
        Assert.AreEqual(new FracNumber(-5, 7), -A);
    }

    [Test]
    public void RationalNumber_ComparisonOperators()
    {
        var A = new FracNumber(4, 6);
        var B = new FracNumber(2, 8);

        Assert.That(B < A, Is.True);
        Assert.That(B <= A, Is.True);
        Assert.That(B > A, Is.False);
        Assert.That(B >= A, Is.False);
    }

    [Test]
    public void Constructor_DenominatorZero_ShouldThrowDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => new FracNumber(1, 0));
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation2()
    {
        var rationalNumber = new FracNumber(64, 16);
        Assert.AreEqual("4", rationalNumber.ToString());
    }
}
