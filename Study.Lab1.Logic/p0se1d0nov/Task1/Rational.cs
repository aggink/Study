using Study.Lab1.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.p0se1d0nov.Task1
{
    public class Rational
    {
        public Rational(int num, int den)
        {
            numerator_ = num;

            if (den != 0)
            {
                denominator_ = den;
            }

            Simplify();

        }

        private int gcd(int num1, int num2)
        {
            if (num1 == num2) return num1;
            if (num1 <= 1 || num2 <= 1) return 1;
            if (num1 > num2) return gcd(num1-num2, num2);
            if (num1 < num2) return gcd(num1, num2-num1);

            return 1;
        }

        private void Simplify()
        {
            if(denominator_ < 0)
            {
                denominator_ = -denominator_;
                numerator_ = -numerator_;
            }

            int divisor = gcd(numerator_, denominator_);
            numerator_ /= divisor;
            denominator_ /= divisor;
        }

        public String ToString()
        {
            if(denominator_ == 1)
            {
                return $"{numerator_}";
            }
            return $"{numerator_}/{denominator_}";
        }

        public double GetAsDouble()
        {
            return (double)numerator_ / (double)denominator_;
        }


        // Перегрузка арифметических операторов
        public static Rational operator +(Rational left, Rational right)
        {
            Rational res = new Rational(left.numerator_ * right.denominator_ + right.numerator_ * left.denominator_, left.denominator_ * right.denominator_);
            res.Simplify();
            return res;

        }

        public static Rational operator -(Rational left, Rational right)
        {
            Rational res = new Rational(left.numerator_ * right.denominator_ - right.numerator_ * left.denominator_, left.denominator_ * right.denominator_);
            res.Simplify();
            return res;
        }

        public static Rational operator *(Rational left, Rational right)
        {
            Rational res = new Rational(left.numerator_ * right.numerator_, left.denominator_ * right.denominator_);
            res.Simplify();
            return res;
        }

        public static Rational operator /(Rational left, Rational right)
        {
            Rational res = new Rational(left.numerator_ * right.denominator_, left.denominator_ * right.numerator_);
            res.Simplify();
            return res;
        }

        public static Rational operator -(Rational r)
        {
            return new Rational(-r.GetNumerator(), r.GetDenominator());
        }


        // Перегрузка логических операторов
        public static bool operator ==(Rational left, Rational right)
        {
            return (left.numerator_ == right.numerator_) && (left.denominator_ == right.denominator_);
        }

        public static bool operator !=(Rational left, Rational right)
        {
            return (left.numerator_ != right.numerator_) || (left.denominator_ != right.denominator_);
        }

        public static bool operator <(Rational left, Rational right)
        {
            return left.GetAsDouble() < right.GetAsDouble();
        }

        public static bool operator <=(Rational left, Rational right)
        {
            return left.GetAsDouble() <= right.GetAsDouble();
        }

        public static bool operator >(Rational left, Rational right)
        {
            return left.GetAsDouble() > right.GetAsDouble();
        }

        public static bool operator >=(Rational left, Rational right)
        {
            return left.GetAsDouble() >= right.GetAsDouble();
        }



        public void SetNumerator(int numerator)
        {
            numerator_ = numerator;
            Simplify();
        }

        public void SetDenominator(int denominator)
        {
            if (denominator != 0)
            {
                denominator_ = denominator;
            }

            Simplify();
        }

        public int GetNumerator()
        {
            return numerator_;
        }

        public int GetDenominator()
        {
            return denominator_;
        }

        private int numerator_ = 1;
        private int denominator_ = 1;

    }
}
