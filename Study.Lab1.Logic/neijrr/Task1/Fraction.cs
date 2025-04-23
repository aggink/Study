using Study.Lab1.Logic.Interfaces.neijrr.Task1;
namespace Study.Lab1.Logic.neijrr
{
    /// <summary>
    /// Дробное число
    /// </summary>
    public class Fraction : IRationalNumber
    {
        private int _numerator;
        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; _simplify(); }
        }
        private int _denominator;
        public int Denominator
        {
            get { return _denominator; }
            set
            {
                if (value == 0) { throw new DivideByZeroException(); }
                _denominator = value; _simplify();
            }
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) { throw new DivideByZeroException(); }
            _numerator = numerator;
            _denominator = denominator;
            _simplify();
        }

        private void _simplify()
        {
            if (_denominator < 0)
            {
                _numerator = -_numerator;
                _denominator = -_denominator;
            }

            int gcd = MathHelper.GCD(_numerator, _denominator); // Наибольший общий делитель числителя и знаменателя
            if (gcd > 1)    // Дробь можно сократить
            {
                _numerator /= gcd;
                _denominator /= gcd;
            }
        }

        public override string ToString()
        {
            // Если делитель равен 1 (целое число), вывести только знаменатель
            if (_denominator == 1) { return _numerator.ToString(); }
            // Иначе вывести дробь
            return $"{_numerator.ToString()}/{_denominator.ToString()}";
        }

        #region MathOperators

        public static Fraction operator +(Fraction obj1, Fraction obj2)
        {
            return new Fraction(
                obj1._numerator * obj2._denominator + obj2._numerator * obj1._denominator,
                obj1._denominator * obj2._denominator
            );
        }

        public static Fraction operator -(Fraction obj1, Fraction obj2)
        {
            return obj1 + (-obj2);
        }

        public static Fraction operator *(Fraction obj1, Fraction obj2)
        {
            return new Fraction(
                obj1._numerator * obj2._numerator,
                obj1._denominator * obj2._denominator
            );
        }

        public static Fraction operator /(Fraction obj1, Fraction obj2)
        {
            return new Fraction(
                obj1._numerator * obj2._denominator,
                obj1._denominator * obj2._numerator
            );
        }

        public static Fraction operator -(Fraction obj)
        {
            obj._numerator *= -1;
            return obj;
        }

        #endregion MathOperators

        #region CompOperators

        public static bool operator ==(Fraction obj1, Fraction obj2)
        {
            return obj1._numerator == obj2._numerator && obj1._denominator == obj2._denominator;
        }

        public static bool operator !=(Fraction obj1, Fraction obj2)
        {
            return obj1._numerator != obj2._numerator || obj1._denominator != obj2._denominator;
        }

        public static bool operator <(Fraction obj1, Fraction obj2)
        {
            return obj1._numerator * obj2._denominator < obj2._numerator * obj1._denominator;
        }

        public static bool operator >(Fraction obj1, Fraction obj2)
        {
            return obj1._numerator * obj2._denominator > obj2._numerator * obj1._denominator;
        }

        public static bool operator <=(Fraction obj1, Fraction obj2)
        {
            return obj1._numerator * obj2._denominator <= obj2._numerator * obj1._denominator;
        }

        public static bool operator >=(Fraction obj1, Fraction obj2)
        {
            return obj1._numerator * obj2._denominator >= obj2._numerator * obj1._denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Fraction))
            {
                return false;
            }
            return this == (Fraction)obj;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        #endregion CompOperators

    }
}
