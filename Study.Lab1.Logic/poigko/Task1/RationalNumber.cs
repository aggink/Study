namespace Study.Lab1.Logic.poigko.Task1;

public class RationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("Знаменатель не может быть равен нулю");

        var gcd = Math.Abs(GreatestCommonDivisor(numerator, denominator));

        this.Numerator = numerator / gcd;
        this.Denominator = denominator / gcd;

        if ((numerator < 0 && denominator < 0) || (numerator > 0 && denominator < 0))
        {
            this.Numerator = -this.Numerator;
            this.Denominator = -this.Denominator;
        }
    }

    public RationalNumber(int numerator)
    {
        this.Numerator = numerator;
        this.Denominator = 1;
    }

    public override string ToString()
    {
        if (Denominator == 0)
            return $"0";

        if (Denominator == -1)
            return $"{-Numerator}";

        else if (Denominator != 1)
        {
            if (Numerator > 0 && Denominator > 0 || Numerator < 0 && Denominator > 0)
                return $"{Numerator}/{Denominator}";

            else
                return $"{-Numerator} /{-Denominator}";
        }

        return $"{Numerator}";
    }

    #region Арифметические операторы
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
        var numerator = a.Numerator * b.Denominator;
        var denominator = a.Denominator * b.Numerator;

        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        var numerator = -a.Numerator;
        var denominator = a.Denominator;

        return new RationalNumber(numerator, denominator);
    }
    #endregion

    # region Операторы сравнения
    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator == b.Numerator && a.Denominator == b.Denominator)
            return true;

        else
            return false;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator == b.Numerator && a.Denominator == b.Denominator)
            return false;

        else
            return true;
    }

    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        var aNumerator = a.Numerator * b.Denominator;
        var bNumerator = b.Numerator * a.Denominator;

        return (aNumerator < bNumerator);
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        var aNumerator = a.Numerator * b.Denominator;
        var bNumerator = b.Numerator * a.Denominator;

        return (aNumerator <= bNumerator);
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        var aNumerator = a.Numerator * b.Denominator;
        var bNumerator = b.Numerator * a.Denominator;

        return (aNumerator > bNumerator);
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        var aNumerator = a.Numerator * b.Denominator;
        var bNumerator = b.Numerator * a.Denominator;

        return (aNumerator >= bNumerator);
    }
    #endregion

    private static int GreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int tmp = b;
            b = a % b;
            a = tmp;
        }
        return a;
    }
}