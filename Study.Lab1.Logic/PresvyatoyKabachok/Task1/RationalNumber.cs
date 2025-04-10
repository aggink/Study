using Study.Lab1.Logic.Interfaces.PresvyatoyKabachok.Task1;

namespace Study.Lab1.Logic.PresvyatoyKabachok.Task1;

public class RationalNumber : IRationalN
{
    public int Numerator { get; }

    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        switch (denominator)
        {
            case 0:
                throw new DivideByZeroException("Знаменатель не может быть равен нулю");
            case < 0:
                numerator = -numerator;
                denominator = -denominator;
                break;
        }

        // Сокращение дроби
        var NewDenom = Math.Abs(NewDenomFunc(numerator, denominator));
        Numerator = numerator / NewDenom;
        Denominator = denominator / NewDenom;
    }

    #region Operators

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

    public override string ToString()
    {
        return Denominator == 1 ? $"{Numerator}" : $"{Numerator}/{Denominator}";
    }

    /// <summary>
    /// Функция равенства (без этого не работает)
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
    /// Какой-то хешкод:)
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    /// <summary>
    /// Вычисляет НОД для двух чисел.
    /// </summary>
    /// <param name="a">Первое число</param>
    /// <param name="b">Второе число</param>
    /// <returns>НОД от a и b</returns>
    private static int NewDenomFunc(int a, int b)
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

    #endregion
}