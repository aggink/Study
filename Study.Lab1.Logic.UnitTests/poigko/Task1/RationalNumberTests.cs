using Study.Lab1.Logic.poigko.Task1;

namespace Study.Lab1.Logic.UnitTests.poigko.Task1
{
    [TestFixture]
    public class RationalNumberTests
    {
        [Test]
        public void Constructor_DenominatorEqualsToZero_ShouldThrowDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => new RationalNumber(5, 0));
        }

        [Test]
        public void Constructor_NotAnAbbreviatedFraction_ShouldShortenTheFraction()
        {
            var someRationalNumber = new RationalNumber(2, 4);
            Assert.That(someRationalNumber.numerator, Is.EqualTo(1));
            Assert.That(someRationalNumber.denominator, Is.EqualTo(2));
        }

        [Test]
        public void Constructor_DenominatorIsNegative_ShouldMakeNumeratorNegative()
        {
            var someRationalNumber = new RationalNumber(2, -3);
            Assert.That(someRationalNumber.numerator, Is.EqualTo(-2));
            Assert.That(someRationalNumber.denominator, Is.EqualTo(3));
        }

        [Test]
        public void Constructor_ValidInput_ShouldInitializeCorrectly()
        {
            var someRationalNumber = new RationalNumber(1, 3);
            Assert.That(someRationalNumber.numerator, Is.EqualTo(1));
            Assert.That(someRationalNumber.denominator, Is.EqualTo(3));
        }

        [Test]
        public void Constructor_AcceptsOneParameter_ShouldInitializeCorrectly()
        {
            var someRationalNumber = new RationalNumber(2);
            Assert.That(someRationalNumber.numerator, Is.EqualTo(2));
            Assert.That(someRationalNumber.denominator, Is.EqualTo(1));
        }

        [Test]
        public void ToString_GetsTwoNumbers_CorrectStringRepresentation()
        {
            var someRationalNumber = new RationalNumber(2, 4);
            Assert.That(someRationalNumber.ToString(), Is.EqualTo("1/2"));
        }

        [Test]
        public void Addition_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(2, 7);
            var c = a + b;
            Assert.That(c.numerator, Is.EqualTo(13));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Addition_TwoNegativeNumbers_ReturnsCorrectSum()
        {
            var a = new RationalNumber(1, -3);
            var b = new RationalNumber(2, -7);
            var c = a + b;
            Assert.That(c.numerator, Is.EqualTo(-13));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Addition_FirstSummandNegative_ReturnsCorrectSum()
        {
            var a = new RationalNumber(1, -3);
            var b = new RationalNumber(2, 7);
            var c = a + b;
            Assert.That(c.numerator, Is.EqualTo(-1));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Addition_SecondSummandNegative_ReturnsCorrectSum()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(2, -7);
            var c = a + b;
            Assert.That(c.numerator, Is.EqualTo(1));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Addition_SecondSummandEqualsToZero_ReturnsCorrectSum()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(0);
            var c = a + b;
            Assert.That(c.numerator, Is.EqualTo(1));
            Assert.That(c.denominator, Is.EqualTo(2));
        }

        [Test]
        public void Substraction_ReducedAndSubtractibleArePositive_ReturnsCorrectDifference()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(2, 7);
            var c = a - b;
            Assert.That(c.numerator, Is.EqualTo(1));
            Assert.That(c.denominator, Is.EqualTo(21));
        }
        [Test]
        public void Substraction_ReducedAndSubtractibleAreNegative_ReturnsCorrectDifference()
        {
            var a = new RationalNumber(-1, 3);
            var b = new RationalNumber(-2, 7);
            var c = a - b;
            Assert.That(c.numerator, Is.EqualTo(-1));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Substraction_ReducedPositiveSubtractibleNegative_ReturnsCorrectDifference()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(-2, 7);
            var c = a - b;
            Assert.That(c.numerator, Is.EqualTo(13));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Substraction_ReducedNegativeSubtractiblePositive_ReturnsCorrectDifference()
        {
            var a = new RationalNumber(-1, 3);
            var b = new RationalNumber(2, 7);
            var c = a - b;
            Assert.That(c.numerator, Is.EqualTo(-13));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Substraction_SubtractibleEqualsToZero_ReturnsCorrectDifference()
        {
            var a = new RationalNumber(-1, 3);
            var b = new RationalNumber(0);
            var c = a - b;
            Assert.That(c.numerator, Is.EqualTo(-1));
            Assert.That(c.denominator, Is.EqualTo(3));
        }

        [Test]
        public void Multiplication_TwoPositiveNumbers_ReturnsCorrectProduct()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(2, 7);
            var c = a * b;
            Assert.That(c.numerator, Is.EqualTo(2));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Multiplication_TwoNegativeNumbers_ReturnsCorrectProduct()
        {
            var a = new RationalNumber(-1, 3);
            var b = new RationalNumber(-2, 7);
            var c = a * b;
            Assert.That(c.numerator, Is.EqualTo(2));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Multiplication_FirstNumberIsNegative_ReturnsCorrectProduct()
        {
            var a = new RationalNumber(-1, 3);
            var b = new RationalNumber(2, 7);
            var c = a * b;
            Assert.That(c.numerator, Is.EqualTo(-2));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Multiplication_SecondNumberIsNegative_ReturnsCorrectProduct()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(-2, 7);
            var c = a * b;
            Assert.That(c.numerator, Is.EqualTo(-2));
            Assert.That(c.denominator, Is.EqualTo(21));
        }

        [Test]
        public void Division_ByZero_ThrowsException()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(0);
            Assert.Throws<DivideByZeroException>(() => { var c = a / b; });
        }

        [Test]
        public void Division_TwoPositiveNumbers_ReturnsCorrectResult()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(2, 7);
            var c = a / b;
            Assert.That(c.numerator, Is.EqualTo(7));
            Assert.That(c.denominator, Is.EqualTo(6));
        }

        [Test]
        public void Division_TwoNegativeNumbers_ReturnsCorrectResult()
        {
            var a = new RationalNumber(-1, 3);
            var b = new RationalNumber(-2, 7);
            var c = a / b;
            Assert.That(c.numerator, Is.EqualTo(7));
            Assert.That(c.denominator, Is.EqualTo(6));
        }

        [Test]
        public void Division_FirstNumberIsNegative_ReturnsCorrectResult()
        {
            var a = new RationalNumber(-1, 3);
            var b = new RationalNumber(2, 7);
            var c = a / b;
            Assert.That(c.numerator, Is.EqualTo(-7));
            Assert.That(c.denominator, Is.EqualTo(6));
        }

        [Test]
        public void Division_SecondNumberIsNegative_ReturnsCorrectResult()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(-2, 7);
            var c = a / b;
            Assert.That(c.numerator, Is.EqualTo(-7));
            Assert.That(c.denominator, Is.EqualTo(6));
        }

        [Test]
        public void PrefixMinus_Number_ReturnsWithTheOppositeSign()
        {
            var a = new RationalNumber(-1, 2);
            a = -a;
            Assert.That(a.numerator, Is.EqualTo(1));
            Assert.That(a.denominator, Is.EqualTo(2));
        }

        [Test]
        public void Equality_TwoEqualNumbers_ShouldReturnTrue()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 2);
            Assert.That(a == b, Is.True);
        }

        [Test]
        public void Equality_NotEqualNumbers_ShouldReturnFalse()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(-1, 2);
            Assert.That(a == b, Is.False);
        }

        [Test]
        public void Inequality_TwoEqualNumbers_ShouldReturnTrue()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 2);
            Assert.That(a != b, Is.False);
        }

        [Test]
        public void Inequality_NotEqualNumbers_ShouldReturnFalse()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(-1, 2);
            Assert.That(a != b, Is.True);
        }

        [Test]
        public void Less_TwoEqualNumbers_ShouldReturnFalse()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 2);
            Assert.That(a < b, Is.False);
        }

        [Test]
        public void Less_FirstIsGreater_ShouldReturnFalse()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(-1, 2);
            Assert.That(a < b, Is.False);
        }

        [Test]
        public void Less_SecondIsGreater_ShouldReturnTrue()
        {
            var a = new RationalNumber(1, 4);
            var b = new RationalNumber(1, 2);
            Assert.That(a < b, Is.True);
        }

        [Test]
        public void LessOrEqual_TwoEqualNumbers_ShouldReturnTrue()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 2);
            Assert.That(a <= b, Is.True);
        }

        [Test]
        public void LessOrEqual_FirstIsGreater_ShouldReturnFalse()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 4);
            Assert.That(a <= b, Is.False);
        }

        [Test]
        public void LessOrEqual_SecondIsGreater_ShouldReturnTrue()
        {
            var a = new RationalNumber(1, 5);
            var b = new RationalNumber(1, 2);
            Assert.That(a <= b, Is.True);
        }


        [Test]
        public void More_TwoEqualNumbers_ShouldReturnFalse()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 2);
            Assert.That(a > b, Is.False);
        }

        [Test]
        public void More_SecondIsGreater_ShouldReturnFalse()
        {
            var a = new RationalNumber(-1, 2);
            var b = new RationalNumber(1, 2);
            Assert.That(a > b, Is.False);
        }

        [Test]
        public void More_FirstIsGreater_ShouldReturnTrue()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 9);
            Assert.That(a > b, Is.True);
        }

        [Test]
        public void MoreOrEqual_TwoEqualNumbers_ShouldReturnTrue()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 2);
            Assert.That(a >= b, Is.True);
        }

        [Test]
        public void MoreOrEqual_FirstIsGreater_ShouldReturnTrue()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 4);
            Assert.That(a >= b, Is.True);
        }

        [Test]
        public void MoreOrEqual_SecondIsGreater_ShouldReturnFalse()
        {
            var a = new RationalNumber(1, 5);
            var b = new RationalNumber(1, 2);
            Assert.That(a >= b, Is.False);
        }

    }
}
