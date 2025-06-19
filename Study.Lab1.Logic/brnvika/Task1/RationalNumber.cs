using Study.Lab1.Logic.Interfaces.brnvika.Task1;

namespace Study.Lab1.Logic.brnvika.Task1;

public class RationalNumber : IRationalNumber
{
    // private int a;
    // public int A
    // {
    //     get { return a + 1 ; }
    //     private set { a = value; }
    // }

    public int Numerator { get; private set; }

    public int Denominator { get; private set; }

    public RationalNumber(int numerator = 0, int denominator = 1)
    {
        switch (denominator)
        {
            case 0:
                throw new DivideByZeroException("Знаменатель не может быть равен 0.");
            case < 0:
                numerator *= -1;
                denominator *= -1;
                break;
        }

        int NodNumbers = nodNumbers(numerator, denominator);

        if (NodNumbers != 0)
        {
            Numerator = numerator / NodNumbers;
            Denominator = denominator / NodNumbers;
        }
    }

    public override string ToString()
    {
        if (Denominator != 1)
            return string.Format("{0}/{1}", Numerator, Denominator);

        return string.Format("{0}", Numerator);
    }

    public static RationalNumber operator +(RationalNumber number1, RationalNumber number2)
    {
        number1.Numerator *= number2.Denominator;
        number2.Numerator *= number1.Denominator;
        number1.Denominator *= number2.Denominator;

        return new RationalNumber(number1.Numerator + number2.Numerator, number1.Denominator);
    }

    public static RationalNumber operator -(RationalNumber number1, RationalNumber number2)
    {
        number1.Numerator *= number2.Denominator;
        number2.Numerator *= number1.Denominator;
        number1.Denominator *= number2.Denominator;

        return new RationalNumber(number1.Numerator - number2.Numerator, number1.Denominator);
    }

    public static RationalNumber operator *(RationalNumber number1, RationalNumber number2)
    {
        return new RationalNumber(number1.Numerator * number2.Numerator, number1.Denominator * number2.Denominator);
    }

    public static RationalNumber operator /(RationalNumber number1, RationalNumber number2)
    {
        if (number2.Numerator == 0)
            throw new DivideByZeroException("Делить на 0 нельзя");

        return new RationalNumber(number1.Numerator * number2.Denominator, number1.Denominator * number2.Numerator);
    }

    public static RationalNumber operator -(RationalNumber number)
    {
        return new RationalNumber(-number.Numerator, number.Denominator);
    }

    public static bool operator ==(RationalNumber number1, RationalNumber number2)
    {
        if (number1.Numerator == number2.Numerator && number1.Denominator == number2.Denominator)
            return true;

        return false;
    }

    public static bool operator !=(RationalNumber number1, RationalNumber number2)
    {
        if (number1.Numerator != number2.Numerator || number1.Denominator != number2.Denominator)
            return true;

        return false;
    }

    public static bool operator <(RationalNumber number1, RationalNumber number2)
    {
        if (number1.Numerator / number1.Denominator < number2.Numerator / number2.Denominator)
            return true;

        return false;
    }

    public static bool operator >(RationalNumber number1, RationalNumber number2)
    {
        if (number1.Numerator / number1.Denominator > number2.Numerator / number2.Denominator)
            return true;

        return false;
    }

    public static bool operator <=(RationalNumber number1, RationalNumber number2)
    {
        if (number1.Numerator / number1.Denominator <= number2.Numerator / number2.Denominator)
            return true;

        return false;
    }

    public static bool operator >=(RationalNumber number1, RationalNumber number2)
    {
        if (number1.Numerator / number1.Denominator >= number2.Numerator / number2.Denominator)
            return true;

        return false;
    }

    private int nodNumbers(int a, int b)
    {
        if (a < 0)
        {
            a *= -1;
        }

        while (a != 0 && b != 0)
        {
            if (a > b) { a = a % b; }
            else { b = b % a; }
        }

        return a + b;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
