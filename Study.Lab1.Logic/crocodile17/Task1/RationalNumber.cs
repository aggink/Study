using Study.Lab1.Logic.Interfaces.crocodile17.Task1;

namespace Study.Lab1.Logic.crocodile17.Task1;

public class RationalNumber : IRationalNumber
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

        // Сокращение дроби
        var NewDenom = Math.Abs(NewDenomFunc(numerator, denominator));
        Numerator = numerator / NewDenom;
        Denominator = denominator / NewDenom;
    }
    public static int NewDenomFunc(int a, int b)
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
}
