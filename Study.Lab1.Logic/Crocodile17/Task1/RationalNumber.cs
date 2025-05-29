using System;
using Study.Lab1.Logic.Interfaces.Crocodile17.Task1;

namespace Study.Lab1.Logic.Crocodile17.Task1
{
    public class RationalNumber : IRationalNumber
    {
        public long Numerator { get; }
        public long Denominator { get; }

        public RationalNumber(long numerator, long denomenator)
        {
            if (denomenator == 0)
                throw new DivideByZeroException("[ERROR]: Denomenator is equal to 0!");

            if (numerator < 0 && denomenator < 0)
            {
                numerator = -numerator;
                denomenator = -denomenator;
            }
            else if (denomenator < 0)
            {
                long temp = numerator;
                numerator = denomenator;
                denomenator = temp;
            }

            long gcd = GCD((ulong)Math.Abs(numerator), (ulong)Math.Abs(denomenator));

            Numerator = numerator / gcd;
            Denominator = denomenator / gcd;
        }

        #region Operators Overloading
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            long numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            long denominator = a.Denominator * b.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            long numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            long denominator = a.Denominator * b.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber a)
        {
            return new RationalNumber(-a.Numerator, a.Denominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            long numerator = a.Numerator * b.Numerator;
            long denominator = a.Denominator * b.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("[ERROR]: Can't divide by 0!");

            long numerator = a.Numerator * b.Denominator;
            long denominator = a.Denominator * b.Numerator;
            return new RationalNumber(numerator, denominator);
        }


        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }

        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !(a == b);
        }

        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        }

        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
        }
        #endregion

        #region Methods
        private static long GCD(ulong a, ulong b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return (long)(a | b);
        }
        public override bool Equals(object obj)
        {
            if (obj is RationalNumber other)
            {
                return this == other;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public override string ToString()
        {
            if (Denominator == 1)
                return Numerator.ToString();

            return $"{Numerator}/{Denominator}";
        }
        #endregion
    }
}
