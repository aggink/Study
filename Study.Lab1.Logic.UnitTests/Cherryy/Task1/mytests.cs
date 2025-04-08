using Study.Lab1.Logic.Cherryy.task1;

namespace Study.Lab1.Logic.UnitTests.Cherryy.Task1
{
   public class mytests
    {
        [Test]
        public void Constructor_ValidInput_ShouldInitializeCorrectly()
        {
            var rationalNumber = new RationalNumber(4, 8);
            Assert.That(rationalNumber.Numerator, Is.EqualTo(1));
            Assert.That(rationalNumber.Denominator, Is.EqualTo(2));
        }

        [Test]
        public void Constructor_DenominatorZero()
        {
            Assert.Throws<ArgumentException>(() => new RationalNumber(1, 0));
        }

        [Test]
        public void Operator_Addition()
        {
            var a = new RationalNumber(2, 3);
            var b = new RationalNumber(5, 3);
            var result = a + b;
            Assert.That(result, Is.EqualTo(new RationalNumber(7, 3)));
        }

        [Test]
        public void Operator_Subtraction()
        {
            var a = new RationalNumber(2, 3);
            var b = new RationalNumber(1, 5);
            var result = a - b;
            Assert.That(result, Is.EqualTo(new RationalNumber(7, 15)));
        }

        [Test]
        public void Operator_Multiplication_ShouldReturnCorrectResult()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(2, 3);
            var result = a * b;
            Assert.That(result, Is.EqualTo(new RationalNumber(1, 3)));
        }

        [Test]
        public void Operator_Division_ShouldReturnCorrectResult()
        {
            var a = new RationalNumber(2, 5);
            var b = new RationalNumber(1, 2);
            var result = a / b;
            Assert.That(result, Is.EqualTo(new RationalNumber(4, 5)));
        }

        [Test]
        public void Operator_Equality_ShouldReturnTrueForEqualRationalNumbers()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(2, 4);
            Assert.That(a == b, Is.True);
        }

        [Test]
        public void Operator_Inequality_ShouldReturnTrueForDifferentRationalNumbers()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 5);
            Assert.That(a != b, Is.True);
        }

        [Test]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            var rationalNumber = new RationalNumber(5, 7);
            Assert.That(rationalNumber.ToString(), Is.EqualTo("5/7"));
        }

        [Test]
        public void Equals_ShouldReturnTrueForEqualRationalNumbers()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(2, 4);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void GetHashCode_ShouldReturnSameHashCodeForEqualRationalNumbers()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(2, 4);
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
        }
    }
}
