using Study.Lab1.Logic.Interfaces.Pro100futa.Task1;

namespace Study.Lab1.Logic.Pro100futa.Task1;

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
        var NewDenom = Math.Abs(NewDenomFunc(numerator, denominator));
        Numerator = numerator / NewDenom;
        Denominator = denominator / NewDenom;

    }

    #region Operators

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denomirator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denomirator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denomirator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denomirator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Numerator;
        int denomirator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denomirator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator;
        int denomirator = a.Denominator * b.Numerator;
        return new RationalNumber(numerator, denomirator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator * b.Denominator == b.Numerator * a.Denominator)
            return true;
        else
            return false;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator * b.Denominator == b.Numerator * a.Denominator)
            return false;
        else
            return true;
    }

    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator * b.Denominator < b.Numerator * a.Denominator)
            return true;
        else
            return false;
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator * b.Denominator > b.Numerator * a.Denominator)
            return true;
        else
            return false;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator * b.Denominator <= b.Numerator * a.Denominator)
            return true;
        else
            return false;
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator * b.Denominator >= b.Numerator * a.Denominator)
            return true;
        else
            return false;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return Denominator == 1 ? $"{Numerator}" : $"{Numerator}/{Denominator}";
    }

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

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    #endregion
}
