using Study.Lab1.Logic.Interfaces.neijrr.Task1;

namespace Study.Lab1.Logic.neijrr
{
    /// <summary>
    /// Дробное число, хранящееся в виде числителя и знаменателя
    /// </summary>
    public class Fraction : IRationalNumber, IComparable
    {
        private int _numerator;
        private int _denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Делитель не может быть равен нулю");

            _numerator = numerator;
            _denominator = denominator;
            Simplify();
        }

        public int Numerator
        {
            get { return _numerator; }
            set
            {
                _numerator = value;
                Simplify();
            }
        }

        public int Denominator
        {
            get { return _denominator; }
            set
            {
                if (value == 0)
                    throw new DivideByZeroException("Делитель не может быть равен нулю");

                _denominator = value;
                Simplify();
            }
        }


        public override string ToString()
        {
            // Если делитель равен 1 (целое число), вывести только знаменатель
            if (_denominator == 1)
                return _numerator.ToString();

            // Иначе вывести дробь
            return $"{_numerator}/{_denominator}";
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
            return new Fraction(
                obj1._numerator * obj2._denominator - obj2._numerator * obj1._denominator,
                obj1._denominator * obj2._denominator
            );
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
            if (obj == null || obj is not Fraction)
                return false;

            return this == (Fraction)obj;
        }

        public override int GetHashCode() => (_numerator, _denominator).GetHashCode();

        public int CompareTo(object obj)
        {
            if (obj == null || obj is not Fraction) throw new ArgumentException(
                $"Передан объект типа {obj.GetType()}, ожидался объект типа Fraction"
            );

            return (_numerator * ((Fraction)obj)._denominator).CompareTo(((Fraction)obj)._numerator * _denominator);
        }

        #endregion CompOperators

        /// <summary>
        /// Упрощает дробь, перенеся знак минус из знаменателя
        /// и сократив числитель и знаменатель на их наибольший общий делитель
        /// </summary>
        private void Simplify()
        {
            // Перенос знака
            if (_denominator < 0)
            {
                _numerator = -_numerator;
                _denominator = -_denominator;
            }

            // Наибольший общий делитель числителя и знаменателя
            int gcd = neijrrService.GCD(_numerator, _denominator);
            if (gcd > 1)    // Дробь можно сократить
            {
                _numerator /= gcd;
                _denominator /= gcd;
            }
        }
    }
}
