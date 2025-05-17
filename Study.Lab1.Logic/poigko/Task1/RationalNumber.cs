namespace Study.Lab1.Logic.poigko.Task1
{
    public class RationalNumber
    {
        public int numerator { get; }
        public int denominator { get; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Знаменатель не может быть равен нулю\n");
            var gcd = Math.Abs(GreatestCommonDivisor(numerator, denominator));
            this.numerator = numerator / gcd;
            this.denominator = denominator / gcd;
            if ((numerator < 0 && denominator < 0) || (numerator > 0 && denominator < 0))
            {
                this.numerator = -this.numerator;
                this.denominator = -this.denominator;
            }
        }

        public RationalNumber(int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }

        public override string ToString()
        {
            if (denominator == 0)
                return $"0";
            if (denominator == -1)
                return $"{-numerator}";
            else if (denominator != 1)
            {
                if (numerator > 0 && denominator > 0 || numerator < 0 && denominator > 0)
                    return $"{numerator}/{denominator}";
                else
                    return $"{-numerator} /{-denominator}";
            }
            return $"{numerator}";
        }

        //Арифметические операторы
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            var numerator = a.numerator * b.denominator + b.numerator * a.denominator;
            var denominator = a.denominator * b.denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            var numerator = a.numerator * b.denominator - b.numerator * a.denominator;
            var denominator = a.denominator * b.denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            var numerator = a.numerator * b.numerator;
            var denominator = a.denominator * b.denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            var numerator = a.numerator * b.denominator;
            var denominator = a.denominator * b.numerator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber a)
        {
            var numerator = -a.numerator;
            var denominator = a.denominator;
            return new RationalNumber(numerator, denominator);
        }

        //Операторы сравнения
        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            if (a.numerator == b.numerator && a.denominator == b.denominator) return true;
            else return false;
        }

        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            if (a.numerator == b.numerator && a.denominator == b.denominator) return false;
            else return true;
        }

        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            var aNumerator = a.numerator * b.denominator;
            var bNumerator = b.numerator * a.denominator;
            return (aNumerator < bNumerator);
        }

        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            var aNumerator = a.numerator * b.denominator;
            var bNumerator = b.numerator * a.denominator;
            return (aNumerator <= bNumerator);
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            var aNumerator = a.numerator * b.denominator;
            var bNumerator = b.numerator * a.denominator;
            return (aNumerator > bNumerator);
        }

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            var aNumerator = a.numerator * b.denominator;
            var bNumerator = b.numerator * a.denominator;
            return (aNumerator >= bNumerator);
        }

        static private int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int tmp = b;
                b = a % b;
                a = tmp;
            }
            return a;
        }
    }
}