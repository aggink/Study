namespace Study.Lab1.Logic.Maxtir23.Task1;

public class RationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("Знаменатель не может являться нулем.");
        }

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int NOD = Math.Abs(NODFunc(numerator, denominator));
        Numerator = numerator / NOD;
        Denominator = denominator / NOD;
    }

    #region Peregruzki
    public static RationalNumber operator +(RationalNumber val1, RationalNumber val2)
    {
        int num = val1.Numerator * val2.Denominator + val2.Numerator * val1.Denominator;
        int den = val1.Denominator * val2.Denominator;
        return new RationalNumber(num, den);
    }

    public static RationalNumber operator -(RationalNumber val1, RationalNumber val2)
    {
        int num = val1.Numerator * val2.Denominator - val2.Numerator * val1.Denominator;
        int den = val1.Denominator * val2.Denominator;
        return new RationalNumber(num, den);
    }

    public static RationalNumber operator -(RationalNumber val1)
    {
        return new RationalNumber(-val1.Numerator, val1.Denominator);
    }

    public static RationalNumber operator *(RationalNumber val1, RationalNumber val2)
    {
        int num = val1.Numerator * val2.Numerator;
        int del = val1.Denominator * val2.Denominator;
        return new RationalNumber(num, del);
    }

    public static RationalNumber operator /(RationalNumber val1, RationalNumber val2)
    {
        int num = val1.Numerator * val2.Denominator;
        int del = val1.Denominator * val2.Numerator;
        return new RationalNumber(num, del);
    }

    public static bool operator ==(RationalNumber val1, RationalNumber val2)
    {
        return val1.Numerator == val2.Numerator && val1.Denominator == val2.Denominator;
    }

    public static bool operator !=(RationalNumber val1, RationalNumber val2)
    {
        return !(val1 == val2);
    }

    public static bool operator >(RationalNumber val1, RationalNumber val2)
    {
        return val1.Numerator * val2.Denominator > val2.Numerator * val1.Denominator;
    }

    public static bool operator <(RationalNumber val1, RationalNumber val2)
    {
        return val1.Numerator * val2.Denominator < val2.Numerator * val1.Denominator;
    }

    public static bool operator <=(RationalNumber val1, RationalNumber val2)
    {
        return val1.Numerator * val2.Denominator <= val2.Numerator * val1.Denominator;
    }

    public static bool operator >=(RationalNumber val1, RationalNumber val2)
    {
        return val1.Numerator * val2.Denominator >= val2.Numerator * val1.Denominator;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        if (Denominator == 1)
        {
            return $"{Numerator}";
        }

        return $"{Numerator}/{Denominator}";
    }

    public override bool Equals(object Number)
    {
        if (Number is RationalNumber number)
        {
            return this == number;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    private static int NODFunc(int firstValue, int secondValue)
    {
        firstValue = Math.Abs(firstValue);
        secondValue = Math.Abs(secondValue);

        while (secondValue != 0)
        {
            int pValue = secondValue;
            secondValue = firstValue % secondValue;
            firstValue = pValue;
        }

        return firstValue;
    }
    #endregion
}