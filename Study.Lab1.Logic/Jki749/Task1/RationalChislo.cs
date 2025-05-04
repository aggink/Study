using Study.Lab1.Logic.Interfaces.Jki749.Task1;

namespace Study.Lab1.Logic.Jki749.Task1;

public class RationalChislo : IRationalChislo
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public RationalChislo(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;

        if (Denominator < 0 && Numerator < 0)
        {
            Numerator *= -1;
            Denominator *= -1;

        }

        if (Denominator == 0)
        {
            throw new ArgumentException("Знаменатель не должен быть нулем");
        }
    }

    public override string ToString()
    {
        if (Denominator == 1)
            return $"{Numerator}";

        if (Denominator == 0)
            return $"Знаменатель не должен быть нулем";

        return $"{Numerator}/{Denominator}";
    }

    private int NOD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    private void Reduce()
    {
        int nod = NOD(Math.Abs(Numerator), Math.Abs(Denominator));
        Numerator /= nod;
        Denominator /= nod;

        if (Denominator < 0)
        {
            Denominator = Math.Abs(Denominator);
            Numerator = -Numerator;
        }

    }

    public static RationalChislo operator *(RationalChislo a, RationalChislo b)
    {

        return new RationalChislo(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    public static RationalChislo operator /(RationalChislo a, RationalChislo b)
    {

        return new RationalChislo(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    public static RationalChislo operator +(RationalChislo a, RationalChislo b)
    {

        return new RationalChislo(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }

    public static RationalChislo operator -(RationalChislo a, RationalChislo b)
    {

        return new RationalChislo(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }


    public static bool operator ==(RationalChislo a, RationalChislo b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
    }

    public static bool operator !=(RationalChislo a, RationalChislo b)
    {
        return !(a == b);
    }

    public static bool operator >(RationalChislo a, RationalChislo b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator <(RationalChislo a, RationalChislo b)
    {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    public static bool operator >=(RationalChislo a, RationalChislo b)
    {
        return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
    }

    public static bool operator <=(RationalChislo a, RationalChislo b)
    {
        return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
    }

}
