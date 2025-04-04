using Study.Lab1.Logic.Interfaces.lsokol14l.Task1;

namespace Study.Lab1.Logic.lsokol14l.Task1;

public class RationalNumber : IRationalNumber
{
    public int Numerator { get; }

    public int Denominator { get; }

    /// <summary>
    /// Конструктор с 1 параметром
    /// </summary>
    /// <param name="numerator">Числитель</param>
    public RationalNumber(int numerator)
    {
        Numerator = numerator;
        Denominator = 1;
    }

    /// <summary>
    /// Конструктор с 2 параметрами
    /// </summary>
    /// <param name="numerator">Числитель</param>
    /// <param name="denominator">Знаменатель</param>
    public RationalNumber(int numerator, int denominator)
    {
        // если значенатель < 0 нам нужно нормалиховать дробь(перекинуть знак в числитель)
        // либо убрать знак если они оба отрицательные
        if (denominator < 0) { numerator *= -1; denominator *= -1; }

        if (denominator == 0)
            throw new DivideByZeroException("Знаменатель не может быть равен нулю");

        Numerator = numerator;
        Denominator = denominator;

        // Сокращение дроби
        var gcd = Math.Abs(Gcd(numerator, denominator));
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public override string ToString()
    {
        return Denominator == 1 ? $"{Numerator}" : $"{Numerator}/{Denominator}";
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
    #endregion

    #region Comparison Operators
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
    /// Генерация хеш-кода
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

    #endregion
}