using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Study.Lab1.Logic.Taipano.Task1;

namespace Study.Lab1.Logic.UnitTests.Taipano.Task1
{
    [TestFixture]
    public class RationalNumberTests
    {
        [Test]
        public void Constructor_ValidInput_ShouldInitializeAndSimplify()
        {
            var rational = new RationalNumber(6, 12);

            Assert.AreEqual(1, rational.Numerator);
            Assert.AreEqual(2, rational.Denominator);
        }

        [Test]
        public void Constructor_NegativeDenominator_ShouldMoveSignToNumerator()
        {
            var rational = new RationalNumber(3, -4);

            Assert.AreEqual(-3, rational.Numerator);
            Assert.AreEqual(4, rational.Denominator);
        }

        [Test]
        public void Constructor_ZeroDenominator_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RationalNumber(1, 0));
        }

        [Test]
        public void Operator_Addition_ShouldAddCorrectly()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 3);
            var result = a + b;

            Assert.AreEqual(5, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }

        [Test]
        public void Operator_Subtraction_ShouldSubtractCorrectly()
        {
            var a = new RationalNumber(3, 4);
            var b = new RationalNumber(1, 2);
            var result = a - b;

            Assert.AreEqual(1, result.Numerator);
            Assert.AreEqual(4, result.Denominator);
        }

        [Test]
        public void Operator_Multiplication_ShouldMultiplyCorrectly()
        {
            var a = new RationalNumber(2, 3);
            var b = new RationalNumber(3, 4);
            var result = a * b;

            Assert.AreEqual(1, result.Numerator);
            Assert.AreEqual(2, result.Denominator);
        }

        [Test]
        public void Operator_Division_ShouldDivideCorrectly()
        {
            var a = new RationalNumber(2, 3);
            var b = new RationalNumber(4, 5);
            var result = a / b;

            Assert.AreEqual(5, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }


        [Test]
        public void Operator_UnaryMinus_ShouldNegateCorrectly()
        {
            var a = new RationalNumber(3, 4);
            var result = -a;

            Assert.AreEqual(-3, result.Numerator);
            Assert.AreEqual(4, result.Denominator);
        }

        [Test]
        public void Operator_Equality_ShouldCompareCorrectly()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(2, 4);

            Assert.IsTrue(a == b);
        }

        [Test]
        public void Operator_Inequality_ShouldCompareCorrectly()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 3);

            Assert.IsTrue(a != b);
        }

        [Test]
        public void ComparisonOperators_ShouldWorkCorrectly()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 3);
            var c = new RationalNumber(2, 4);

            Assert.IsTrue(b < a);
            Assert.IsTrue(a > b);
            Assert.IsTrue(a <= c);
            Assert.IsTrue(a >= c);
        }

        [Test]
        public void ToString_ShouldFormatCorrectly()
        {
            var a = new RationalNumber(3, 4);
            var b = new RationalNumber(4, 1);

            Assert.AreEqual("3/4", a.ToString());
            Assert.AreEqual("4", b.ToString());
        }
    }
}
