using Study.Lab1.Logic.Jki749.Task1;

namespace Study.Lab1.Logic.UnitTests.Jki749.Task1;

[TestFixture]
public class RationalChisloTests
{
    [Test]
    public void Prod()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 3);
        var prod = chislo1 * chislo2;
        var expected = new RationalChislo(1, 6);
        Assert.That(prod.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void Prod2()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 0);
        var prod = chislo1 * chislo2;
        var expected = "Знаменатель не должен быть нулем";
        Assert.That(prod.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void Summ()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 3);
        var sum = chislo1 + chislo2;
        var expected = new RationalChislo(5, 6);
        Assert.That(sum.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void Minus()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 3);
        var mm = chislo1 - chislo2;
        var expected = new RationalChislo(1, 6);
        Assert.That(mm.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void Minus2()
    {
        var chislo1 = new RationalChislo(-1, 2);
        var chislo2 = new RationalChislo(1, 3);
        var mm = chislo1 - chislo2;
        var expected = new RationalChislo(-5, 6);
        Assert.That(mm.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void Summ2()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, -3);
        var sum = chislo1 + chislo2;
        var expected = new RationalChislo(1, 6);
        Assert.That(sum.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void Del()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 3);
        var del = chislo1 / chislo2;
        var expected = new RationalChislo(3, 2);
        Assert.That(del.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void Del2()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 0);
        var del = chislo1 / chislo2;
        var expected = new RationalChislo(0, 2);
        Assert.That(del.ToString(), Is.EqualTo(expected.ToString()));

    }

    [Test]
    public void EqualityT()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsTrue(chislo1 == chislo2);
    }

    [Test]
    public void EqualityF()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 3);
        Assert.IsFalse(chislo1 == chislo2);
    }

    [Test]
    public void Greater()
    {
        var chislo1 = new RationalChislo(1, 2);
        var chislo2 = new RationalChislo(1, 3);
        Assert.IsTrue(chislo1 > chislo2);
    }

    [Test]
    public void Less()
    {
        var chislo1 = new RationalChislo(1, 3);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsTrue(chislo1 < chislo2);
    }

    [Test]
    public void GreaterOrEqualT()
    {
        var chislo1 = new RationalChislo(3, 4);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsTrue(chislo1 >= chislo2);
    }

    [Test]
    public void GreaterOrEqualF()
    {
        var chislo1 = new RationalChislo(1, 3);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsFalse(chislo1 >= chislo2);
    }

    [Test]
    public void LessOrEqualT()
    {
        var chislo1 = new RationalChislo(1, 3);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsTrue(chislo1 <= chislo2);
    }

    [Test]
    public void LessOrEqualF()
    {
        var chislo1 = new RationalChislo(3, 4);
        var chislo2 = new RationalChislo(1, 2);
        Assert.IsFalse(chislo1 <= chislo2);
    }
}
