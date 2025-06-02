using Study.Lab1.Logic.Interfaces.cocobara.Task1;

namespace Study.Lab1.Logic.cocobara.Task1;

public class RationalNumber : IRationalNumber
{
    public int Numerator { get; }

    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("Знаменатель не может быть равен нулю");

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int gcd = Math.Abs(Gcd(numerator, denominator));
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    #region Operators

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int newDenominator = a.Denominator * b.Denominator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int newDenominator = a.Denominator * b.Denominator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Numerator;
        int newDenominator = a.Denominator * b.Denominator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Denominator;
        int newDenominator = a.Denominator * b.Numerator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;

        return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b) => !(a == b);

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

    public override string ToString()
    {
        return Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";
    }

    public override bool Equals(object obj)
    {
        return obj is RationalNumber number && this == number;
    }

    public override int GetHashCode()
    {
        return (Numerator, Denominator).GetHashCode();
    }

    private static int Gcd(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    #endregion
}