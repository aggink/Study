using Study.Lab1.Logic.SlavicSquat.Task1;

namespace Study.Lab1.Logic.UnitTests.SlavicSquat.Task1;

[TestFixture]
public class RationalNumberTests
{
    [Test]
    public void Prod()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, 3);
        var prod = numb1 * numb2;
        var expected = new RationalNumber(1, 6);
        Assert.That(prod.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void Prod2()
    {
        var expected = Assert.Throws<ArgumentException>(() => new RationalNumber(1, 0));
        Assert.That(expected.Message, Is.EqualTo("Знаменатель не должен быть нулем"));
    }

    [Test]
    public void Summ()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, 3);
        var sum = numb1 + numb2;
        var expected = new RationalNumber(5, 6);
        Assert.That(sum.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Minus()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, 3);
        var mm = numb1 - numb2;
        var expected = new RationalNumber(1, 6);
        Assert.That(mm.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Minus2()
    {
        var numb1 = new RationalNumber(-1, 2);
        var numb2 = new RationalNumber(1, 3);
        var mm = numb1 - numb2;
        var expected = new RationalNumber(-5, 6);
        Assert.That(mm.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Summ2()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, -3);
        var sum = numb1 + numb2;
        var expected = new RationalNumber(1, 6);
        Assert.That(sum.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Del()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, 3);
        var del = numb1 / numb2;
        var expected = new RationalNumber(3, 2);
        Assert.That(del.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Del2()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, 9);
        var del = numb1 / numb2;
        var expected = new RationalNumber(9, 2);
        Assert.That(del.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void EqualityT()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, 2);
        Assert.IsTrue(numb1 == numb2);
    }

    [Test]
    public void EqualityF()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, 3);
        Assert.IsFalse(numb1 == numb2);
    }

    [Test]
    public void Greater()
    {
        var numb1 = new RationalNumber(1, 2);
        var numb2 = new RationalNumber(1, 3);
        Assert.IsTrue(numb1 > numb2);
    }

    [Test]
    public void Less()
    {
        var numb1 = new RationalNumber(1, 3);
        var numb2 = new RationalNumber(1, 2);
        Assert.IsTrue(numb1 < numb2);
    }

    [Test]
    public void GreaterOrEqualT()
    {
        var numb1 = new RationalNumber(3, 4);
        var numb2 = new RationalNumber(1, 2);
        Assert.IsTrue(numb1 >= numb2);
    }

    [Test]
    public void GreaterOrEqualF()
    {
        var numb1 = new RationalNumber(1, 3);
        var numb2 = new RationalNumber(1, 2);
        Assert.IsFalse(numb1 >= numb2);
    }

    [Test]
    public void LessOrEqualT()
    {
        var numb1 = new RationalNumber(1, 3);
        var numb2 = new RationalNumber(1, 2);
        Assert.IsTrue(numb1 <= numb2);
    }

    [Test]
    public void LessOrEqualF()
    {
        var numb1 = new RationalNumber(3, 4);
        var numb2 = new RationalNumber(1, 2);
        Assert.IsFalse(numb1 <= numb2);
    }
}
