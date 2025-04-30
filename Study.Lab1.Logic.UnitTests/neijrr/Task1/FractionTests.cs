using Study.Lab1.Logic.neijrr.Task1;

namespace Study.Lab1.Logic.UnitTests.neijrr.Task1;

[TestFixture]
public class Task1Tests
{
    [Test]
    public void Constructor()
    {
        var a = new Fraction(4, 6);
        var b = new Fraction(1, -2);

        Assert.Multiple(() =>
        {
            Assert.That(a.Numerator, Is.EqualTo(2), "Ошибка в числителе при упрощении дроби");
            Assert.That(a.Denominator, Is.EqualTo(3), "Ошибка в знаменателе при упрощении дроби");

            Assert.That(b.Numerator, Is.EqualTo(-1), "Ошибка в числителе при переносе знака");
            Assert.That(b.Denominator, Is.EqualTo(2), "Ошибка в знаменателе при переносе знака");

            Assert.Throws<DivideByZeroException>(() => new Fraction(1, 0), "Допущено деление на 0");
        });
    }

    [Test]
    public void Math_Operators()
    {
        var a = new Fraction(1, 5);
        var b = new Fraction(2, 5);
        var c = new Fraction(2, 3);
        var r1 = a + b;    // 3/5
        var r2 = a + c;    // 13/15
        var r3 = b - a;    // 1/5
        var r4 = c - a;    // 7/15
        var r5 = b * c;    // 4/15
        var r6 = c / a;    // 10/3
        var r7 = b / a;    // 2
        var r8 = -b;       // -2/5

        Assert.Multiple(() =>
        {
            Assert.That(r1, Is.EqualTo(new Fraction(3, 5)), "Ошибка в сложении дробей с одинаковым делителем");
            Assert.That(r2, Is.EqualTo(new Fraction(13, 15)), "Ошибка в сложении дробей с разными делителями");

            Assert.That(r3, Is.EqualTo(new Fraction(1, 5)), "Ошибка в вычитании дробей с одинаковым делителем");
            Assert.That(r4, Is.EqualTo(new Fraction(7, 15)), "Ошибка в вычитании дробей с разными делителями");

            Assert.That(r5, Is.EqualTo(new Fraction(4, 15)), "Ошибка в умножении дробей");

            Assert.That(r6, Is.EqualTo(new Fraction(10, 3)), "Ошибка в делении дробей");

            Assert.That(r7, Is.EqualTo(new Fraction(2, 1)), "Ошибка в сокращении при делении дробей");

            Assert.That(r8, Is.EqualTo(new Fraction(-2, 5)), "Ошибка при унарном отрицании");
        });
    }

    [Test]
    public void Comparison_Operators()
    {
        var a = new Fraction(1, 5);
        var b = new Fraction(2, 5);
        var c = new Fraction(2, 5);

        Assert.Multiple(() =>
        {
            Assert.That(b, Is.EqualTo(c), "Ошибка при сравнении: a == b -> False при a == b");
            Assert.That(a, Is.Not.EqualTo(b), "Ошибка при сравнении: a != b -> True при a != b");

            Assert.That(a, Is.LessThan(b), "Ошибка при сравнении: a < b -> False при a < b");
            Assert.That(b, Is.Not.LessThan(c), "Ошибка при сравнении: a < b -> True при a == b");
            Assert.That(b, Is.Not.LessThan(a), "Ошибка при сравнении: a < b -> True при a > b");

            Assert.That(a, Is.LessThanOrEqualTo(b), "Ошибка при сравнении: a <= b -> False при a < b");
            Assert.That(b, Is.LessThanOrEqualTo(c), "Ошибка при сравнении: a <= b -> False при a == b");
            Assert.That(b, Is.Not.LessThanOrEqualTo(a), "Ошибка при сравнении: a <= b -> True при a > b");

            Assert.That(b, Is.GreaterThan(a), "Ошибка при сравнении: a > b -> False при a > b");
            Assert.That(b, Is.Not.GreaterThan(c), "Ошибка при сравнении: a > b -> True при a == b");
            Assert.That(a, Is.Not.GreaterThan(b), "Ошибка при сравнении: a > b -> True при a < b");

            Assert.That(b, Is.GreaterThanOrEqualTo(a), "Ошибка при сравнении: a >= b -> False при a > b");
            Assert.That(b, Is.GreaterThanOrEqualTo(c), "Ошибка при сравнении: a >= b -> False при a == b");
            Assert.That(a, Is.Not.GreaterThanOrEqualTo(b), "Ошибка при сравнении: a >= b -> True при a < b");

        });
    }

    [Test]
    public void ToString_Func()
    {
        var a = new Fraction(2, 3);
        var b = new Fraction(3, 1);

        Assert.Multiple(() =>
        {
            Assert.That(a.ToString(), Is.EqualTo("2/3"), "Не работает перевод в строку");
            Assert.That(b.ToString(), Is.EqualTo("3"), "Не работает упрощённая запись дроби");
        });
    }
}
