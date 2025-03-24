using Study.Lab1.Logic.Interfaces.xynthh;

namespace Study.Lab1.Logic.xynthh.Task1;

public class RationalNumber : IRationalNumber
{
    // Конструктор
    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0) throw new DivideByZeroException("Знаменатель не может быть равен нулю");

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        // Сокращение дроби
        var gcd = Math.Abs(Gcd(numerator, denominator));
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    // Переменные
    public int Numerator { get; }

    public int Denominator { get; }

    // Методы
    public override string ToString()
    {
        if (Denominator == 1) return $"{Numerator}";

        return $"{Numerator}/{Denominator}";
    }

    private static int Gcd(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    // Операторы
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

    /// <summary>
    ///     Функция равенства (без этого не работает)
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj is RationalNumber number)
            return this == number;
        return false;
    }

    /// <summary>
    ///     Какой-то хешкод:)
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }
}