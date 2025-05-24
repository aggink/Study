using Study.Lab1.Logic.Interfaces.danaky1.Task1;

namespace Study.Lab1.Logic.danaky1.Task1;

public class RationalNumber : IRationalNumber
{
    public int Numerator { get; }

    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {

        if (denominator == 0)
        {
            throw new DivideByZeroException("Знаменатель не может быть равен нулю");
        }

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        var Nod = Math.Abs(NOD(numerator, denominator));
        Numerator = numerator / Nod;
        Denominator = denominator / Nod;
    }

    #region overloads

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        var numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        var denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        var numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        var denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        var numerator = a.Numerator * b.Numerator;
        var denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Деление на ноль");

        var numerator = a.Numerator * b.Denominator;
        var denominator = a.Denominator * b.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
    }

    #endregion

    #region Methods

    public override bool Equals(object other)
    {
        if (other is RationalNumber)
        {
            var number = (RationalNumber)other;
            return this == number;
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
            return $"{Numerator}";

        return $"{Numerator}/{Denominator}";
    }

    private static int NOD(int num, int dem)
    {
        num = Math.Abs(num);
        dem = Math.Abs(dem);

        while (dem != 0)
        {
            var t = dem;
            dem = num % dem;
            num = t;
        }

        return num;
    }

    #endregion
}

