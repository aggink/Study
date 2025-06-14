using Study.Lab1.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.p0se1d0nov.Task1;

public class Rational
{
    private int numerator_;
    private int denominator_;

    public Rational(int num, int den)
    {
        if (den == 0)
            throw new DivideByZeroException("Делитель не может быть равен нулю");

        numerator_ = num;
        denominator_ = den;

        Simplify();
    }

    public int Numerator
    {
        get { return numerator_; }
        set
        {
            numerator_ = value;

            Simplify();
        }
    }

    public int Denominator
    {
        get { return denominator_; }
        set
        {
            if (value == 0)
                throw new DivideByZeroException("Делитель не может быть равен нулю");

            denominator_ = value;

            Simplify();
        }
    }

    public String ToString()
    {
        if (denominator_ == 1)
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
    #region arithmetic_overloading
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
        return new Rational(-r.Numerator, r.Denominator);
    }
    #endregion

    // Перегрузка логических операторов
    #region logic_overloading
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
    #endregion

    #region private_methods
    private int gcd(int num1, int num2)
    {
        if (num1 == num2) return num1;
        if (num1 <= 1 || num2 <= 1) return 1;
        if (num1 > num2) return gcd(num1 - num2, num2);
        if (num1 < num2) return gcd(num1, num2 - num1);

        return 1;
    }

    private void Simplify()
    {
        if (denominator_ < 0)
        {
            denominator_ = -denominator_;
            numerator_ = -numerator_;
        }

        int divisor = gcd(numerator_, denominator_);
        numerator_ /= divisor;
        denominator_ /= divisor;
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
    #endregion
}

