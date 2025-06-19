using Study.Lab1.Logic.UTBL.Task1;

namespace Study.Lab1.Logic.UnitTests.UTBL.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void ValidConstructor_ReducesFractionProperly()
    {
        var r = new RationalNumber(4, 6);
        Assert.That(r.Numerator, Is.EqualTo(2), "��������� �� �������� ���������.");
        Assert.That(r.Denominator, Is.EqualTo(3), "����������� �� �������� ���������.");
    }

    [Test]
    public void ZeroDenominator_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void AdditionOperator_CalculatesSumCorrectly()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        var sum = r1 + r2;
        var expected = new RationalNumber(5, 6);
        Assert.That(sum, Is.EqualTo(expected), "�������� �������� ��������� �������.");
    }

    [Test]
    public void SubtractionOperator_CalculatesDifferenceCorrectly()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        var diff = r1 - r2;
        var expected = new RationalNumber(1, 6);
        Assert.That(diff, Is.EqualTo(expected), "�������� ��������� ��������� �������.");
    }

    [Test]
    public void MultiplicationOperator_CalculatesProductCorrectly()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        var product = r1 * r2;
        var expected = new RationalNumber(1, 6);
        Assert.That(product, Is.EqualTo(expected), "�������� ��������� �� ��� ��������� ���������.");
    }

    [Test]
    public void DivisionOperator_CalculatesQuotientCorrectly()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        var quotient = r1 / r2;
        var expected = new RationalNumber(3, 2);
        Assert.That(quotient, Is.EqualTo(expected), "�������� ������� �� ��� ��������� ���������.");
    }

    [Test]
    public void EqualityOperator_ReturnsTrueForEquivalentFractions()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(2, 4);
        Assert.IsTrue(r1 == r2, "�������� ��������� �� ��������� ������������� �����.");
    }

    [Test]
    public void InequalityOperator_ReturnsTrueForDifferentFractions()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(1, 3);
        Assert.IsTrue(r1 != r2, "�������� ����������� ������� ���������� ������ �����.");
    }

    [Test]
    public void ToStringMethod_ReturnsExpectedRepresentation()
    {
        var r = new RationalNumber(1, 2);
        Assert.That(r.ToString(), Is.EqualTo("1/2"), "����� ToString ���������� �������� ������������� �����.");
    }

    [Test]
    public void EqualsMethod_ReturnsTrueForEquivalentFractionObjects()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(2, 4);
        Assert.IsTrue(r1.Equals(r2), "����� Equals �� ��������� ������������� ��������� �����.");
    }

    [Test]
    public void GetHashCodeMethod_ReturnsIdenticalHashForEquivalentFractions()
    {
        var r1 = new RationalNumber(1, 2);
        var r2 = new RationalNumber(2, 4);
        Assert.That(r1.GetHashCode(), Is.EqualTo(r2.GetHashCode()), "����� GetHashCode �� ���������� ���������� �������� ��� ������������� ������.");
    }
}
