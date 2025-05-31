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
            throw new ArgumentException("You can't divide by 0.", nameof(dum));
        }

        int nod = GreatestCommonDivisor(Math.Abs(num), Math.Abs(dum));

        Numerator = num / nod;
        Denominator = dum / nod;
    }

    #region Overloads
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
            throw new DivideByZeroException("Division by zero");

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
    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    public override string ToString()
    {
        if (Denominator == 1)
            return Numerator.ToString();

        return $"{Numerator}/{Denominator}";

    }

    public override bool Equals(object obj)
    {
        if (obj is RationalNumber other)
        {
            return this == other;
        }

        return false;
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
    #endregion
}