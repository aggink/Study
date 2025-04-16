using Study.Lab1.Logic.Interfaces.Jki749.Task1;

namespace Study.Lab1.Logic.Jki749.Task1;

class RationalChislo : IRationalChislo
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public RationalChislo(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;

        if (Denominator == 0)
        {
            Console.WriteLine("Знаменатель не должен быть нулем");
        }
    }

    public override string ToString()
    {
        if (Denominator == 1)
            return $"{Numerator}";

        return $"{Numerator}/{Denominator}";
    }

    int NOD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
    void Reduce()
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

    public static RationalChislo operator +(RationalChislo a, RationalChislo b)
    {

        return new RationalChislo(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }
}
