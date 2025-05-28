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
}