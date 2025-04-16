using Study.Lab1.Logic.Interfaces.poroshok.Task1;

namespace Study.Lab1.Logic.poroshok.Task1;

public class RationalNumber : IRationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }
    public RationalNumber(int Numerator, int Denominator)
    {

        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
        if (Denominator == 0)
        {
            throw new DivideByZeroException("Знаменатель не может быть равен нулю");
        }

        var Nod = Math.Abs(NOD(Numerator, Denominator));
        Numerator = Numerator / Nod;
        Denominator = Denominator / Nod;
    }

    #region overloads
    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator;
        int denominator = a.Denominator * b.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }
    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
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

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
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
        if (Denominator != 1)
        {
            return $"{Numerator} / {Denominator}";
        }
        return $"{Numerator}";
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

