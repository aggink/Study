using Study.Lab1.Logic.neijrr;

namespace Study.Lab1.Logic.UnitTests.neijrr.Task1
{
    [TestFixture]
    public class Task1Tests
    {
        [Test]
        public void Constructor_RegularCheck()
        {
            var frac = new Fraction(4, 6);
            Assert.That(frac.Numerator == 2);
            Assert.That(frac.Denominator == 3);
        }

        [Test]
        public void Constructor_DivByZeroCheck()
        {
            Assert.Throws<DivideByZeroException>(() => new Fraction(1, 0));
        }

        [Test]
        public void Operator_Addition_SameDenominator()
        {
            var a = new Fraction(1, 5);
            var b = new Fraction(2, 5);
            var result = a + b;
            Assert.That(result, Is.EqualTo(new Fraction(3, 5)));
        }

        [Test]
        public void Operator_Addition_DifferentDenominator()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 3);
            var result = a + b;
            Assert.That(result, Is.EqualTo(new Fraction(5, 6)));
        }

        [Test]
        public void Operator_Subtraction_SameDenominator()
        {
            var a = new Fraction(4, 5);
            var b = new Fraction(2, 5);
            var result = a - b;
            Assert.That(result, Is.EqualTo(new Fraction(2, 5)));
        }

        [Test]
        public void Operator_Subtraction_DifferentDenominator()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 3);
            var result = a - b;
            Assert.That(result, Is.EqualTo(new Fraction(1, 6)));
        }

        [Test]
        public void Operator_Negation()
        {
            var frac = new Fraction(2, 5);
            var neg = -frac;
            Assert.That(neg, Is.EqualTo(new Fraction(-2, 5)));
        }

        [Test]
        public void Operator_Multiplication()
        {
            var a = new Fraction(2, 5);
            var b = new Fraction(3, 7);
            var result = a * b;
            Assert.That(result, Is.EqualTo(new Fraction(6, 35)));
        }

        [Test]
        public void Operator_Division()
        {
            var a = new Fraction(4, 15);
            var b = new Fraction(2, 3);
            var result = a / b;
            Assert.That(result, Is.EqualTo(new Fraction(2, 5)));
        }

        [Test]
        public void Operator_Equality_True()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(2, 4);
            Assert.That(a == b);
        }

        [Test]
        public void Operator_Equality_False()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 4);
            Assert.That(!(a == b));
        }

        [Test]
        public void Operator_Inequality_True()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 4);
            Assert.That(a != b);
        }

        [Test]
        public void Operator_Inequality_False()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(2, 4);
            Assert.That(!(a != b));
        }

        [Test]
        public void Operator_Less_True()
        {
            var a = new Fraction(2, 5);
            var b = new Fraction(3, 5);
            Assert.That(a < b);
        }

        [Test]
        public void Operator_Less_False()
        {
            var a = new Fraction(3, 2);
            var b = new Fraction(2, 4);
            Assert.That(!(a < b));
        }

        [Test]
        public void Operator_Less_Equal()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(2, 4);
            Assert.That(!(a < b));
        }

        [Test]
        public void Operator_LessOrEq_True()
        {
            var a = new Fraction(2, 5);
            var b = new Fraction(3, 5);
            Assert.That(a <= b);
        }

        [Test]
        public void Operator_LessOrEq_False()
        {
            var a = new Fraction(3, 2);
            var b = new Fraction(2, 4);
            Assert.That(!(a <= b));
        }

        [Test]
        public void Operator_LessOrEq_Equal()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(2, 4);
            Assert.That(a <= b);
        }

        [Test]
        public void Operator_Greater_True()
        {
            var a = new Fraction(3, 5);
            var b = new Fraction(2, 5);
            Assert.That(a > b);
        }

        [Test]
        public void Operator_Greater_False()
        {
            var a = new Fraction(2, 4);
            var b = new Fraction(3, 5);
            Assert.That(!(a > b));
        }

        [Test]
        public void Operator_Greater_Equal()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(2, 4);
            Assert.That(!(a > b));
        }

        [Test]
        public void Operator_GreaterOrEq_True()
        {
            var a = new Fraction(3, 5);
            var b = new Fraction(2, 5);
            Assert.That(a >= b);
        }

        [Test]
        public void Operator_GreaterOrEq_False()
        {
            var a = new Fraction(2, 4);
            var b = new Fraction(3, 5);
            Assert.That(!(a >= b));
        }

        [Test]
        public void Operator_GreaterOrEq_Equal()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(2, 4);
            Assert.That(a >= b);
        }

        [Test]
        public void ToString_Regular()
        {
            var frac = new Fraction(2, 3);
            Assert.That(frac.ToString() == "2/3");
        }

        [Test]
        public void ToString_Denominator_One()
        {
            var frac = new Fraction(3, 1);
            Assert.That(frac.ToString() == "3");
        }

    }
}
