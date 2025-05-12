namespace Study.Lab1.Logic.katty;

public class RationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен 0!", nameof(denominator));
        }

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int nod = NOD(Math.Abs(numerator), denominator);
        Numerator = numerator / nod;
        Denominator = denominator / nod;
    }

    private static int NOD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        if (Denominator == 1)
        {
            return Numerator.ToString();
        }
        return $"{Numerator}/{Denominator}";
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int newDenominator = a.Denominator * b.Denominator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int newDenominator = a.Denominator * b.Denominator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Numerator;
        int newDenominator = a.Denominator * b.Denominator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        if (b.Numerator == 0)
        {
            throw new DivideByZeroException("Деление на ноль.");
        }
        int newNumerator = a.Numerator * b.Denominator;
        int newDenominator = a.Denominator * b.Numerator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (ReferenceEquals(a, b)) { return true; }
        if (ReferenceEquals(a, null)) { return false; }
        if (ReferenceEquals(b, null)) { return false; }

        return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return (double)a.Numerator / a.Denominator < (double)b.Numerator / b.Denominator;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return (double)a.Numerator / a.Denominator <= (double)b.Numerator / b.Denominator;
    }
    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return (double)a.Numerator / a.Denominator > (double)b.Numerator / b.Denominator;
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return (double)a.Numerator / a.Denominator >= (double)b.Numerator / b.Denominator;
    }
}