namespace Study.Lab1.Logic.mansurgh.Task1;

public class RationalNumber
{   
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("Знаменатель не может быть нулём");

        // переносим минус знаменателя на числитель
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        // нод по алгоритму Евклида
        int gcd = Gcd(Math.Abs(numerator), Math.Abs(denominator));

        // сокращаем дробь (упрощение)
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public override string ToString()
    {
        if (Denominator == 1)
        {
            return $"{Numerator}";
        }
        else
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != this.GetType()) return false;

        var other = (RationalNumber)obj;
        return this.Numerator == other.Numerator && this.Denominator == other.Denominator;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

#region Operators

    public static RationalNumber operator+ (RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int newDenominator = a.Denominator * b.Denominator;

        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator- (RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int newDenominator = a.Denominator * b.Denominator;

        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator* (RationalNumber a, RationalNumber b)
    {
        int newNumerator = a.Numerator * b.Numerator;
        int newDenominator = a.Denominator * b.Denominator;

        return new RationalNumber(newNumerator, newDenominator);
    }

    public static RationalNumber operator/ (RationalNumber a, RationalNumber b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Нельзя делить на ноль");

        int newNumerator = a.Numerator * b.Denominator;
        int newDenominator = a.Denominator * b.Numerator;

        return new RationalNumber(newNumerator, newDenominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
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

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
    }

#endregion

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }   
}