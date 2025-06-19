using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.Taipano.Task1
{
    public class RationalNumber
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        public override string ToString()
        {
            return Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator -(RationalNumber a)
        {
            return new RationalNumber(-a.Numerator, a.Denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
        public static bool operator ==(RationalNumber left, RationalNumber right)
        {
            return (left.Numerator == right.Numerator) && (left.Denominator == right.Denominator);
        }

        public static bool operator !=(RationalNumber left, RationalNumber right)
        {
            return (left.Numerator != right.Numerator) || (left.Denominator != right.Denominator);
        }

        public static bool operator <(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) >= 0;
        }

        public int CompareTo(RationalNumber other)
        {
            if (other is null) return 1;

            long left = (long)Numerator * other.Denominator;
            long right = (long)other.Numerator * Denominator;

            return left.CompareTo(right);
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}
