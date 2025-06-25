using Study.Lab1.Logic.Interfaces.Bonnemort.Task1;

namespace Study.Lab1.Logic.Bonnemort.Task1;

public class RationalNumber : IRationalNumber
{
    public int Numerator { get; }

    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Знаменатель не может быть нулём.", nameof(denominator));

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    #region Перегрузки
    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Невозможно разделить на ноль.");

        int numerator = a.Numerator * b.Denominator;
        int denominator = a.Denominator * b.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
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

    #region Методы
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

    public override string ToString()
    {
        if (Denominator == 1)
            return Numerator.ToString();

        return $"{Numerator}/{Denominator}";
    }
    #endregion
}