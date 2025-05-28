namespace Study.Lab1.Logic.mariabyrrrrak.Task1;

public class RationalNumber
{
    public int Numerator { get; private set; }

    private int _denominator;

    public int Denominator
    {
        get
        {
            return _denominator;
        }
        private set
        {
            _denominator = value;
        }
    }

    public RationalNumber(int num, int dum)
    {
        Numerator = num;
        Denominator = dum;

        if (Denominator == 0)
        {
            throw new ArgumentException("Делить на 0 нельзя!", nameof(dum));
        }
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        var num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        var den = a.Denominator * b.Denominator;
        return new RationalNumber(num, den);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        var num = a.Numerator * b.Numerator;
        var den = a.Denominator * b.Denominator;
        return new RationalNumber(num, den);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        var numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
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
}