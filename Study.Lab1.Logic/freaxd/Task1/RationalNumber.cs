using Study.Lab1.Logic.Interfaces.freaxd.Task1;

namespace Study.Lab1.Logic.freaxd.Task1;

public class RationalNumber : IRationalNumber
{
    public int Numerator { get; set; }

    public int Denominator { get; set; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("The denominator should not be zero.");
        }

        // Нормализация знака при отрицательном знаменателе
        if (denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }

        int gcd = GCD(numerator, denominator);

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;        
    }

    // Метод вычисления наибольшого общего делителя
    private int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }

        return a;
    }

    public override string ToString()
    {
        if (Denominator == 1)
            return $"{Numerator}";

        return $"{Numerator}/{Denominator}";
    }

    public override bool Equals(object obj)
    {
        if (obj is RationalNumber other)
            return this == other;        

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    /// <summary>
    /// Перегрузка арифметических операторов
    /// </summary>
    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
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

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
    }

    /// <summary>
    /// Перегрузка операторов сравнения
    /// </summary>
    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

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

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return a < b || a == b;
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return a > b || a == b;
    }
}   