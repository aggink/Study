using Study.Lab1.Logic.Interfaces.UTBL.Task1;

namespace Study.Lab1.Logic.UTBL.Task1;

public class RationalNumber : IRationalNumber
{
    public int Numerator { get; }

    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("����������� �� ������ ���� ����� ����.");
        }

        // ����������� ����: ���� ����������� ������������� � ������ �����
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        var gcd = ComputeGCD(numerator, denominator);

        // �� ������ ������ ����������, ��� ��� �������������
        gcd = Math.Abs(gcd);

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    // ����� ��� ���������� ����������� ������ ��������
    private static int ComputeGCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }

        return a;
    }

    #region ���������� �������������� ����������

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
        int denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
        int denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Numerator;
        int denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Denominator;
        int denominator = r1.Denominator * r2.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    // ������� �����
    public static RationalNumber operator -(RationalNumber r)
    {
        return new RationalNumber(-r.Numerator, r.Denominator);
    }

    #endregion

    #region ���������� ���������� ���������

    public static bool operator ==(RationalNumber r1, RationalNumber r2)
    {
        if (ReferenceEquals(r1, r2))
            return true;

        if (r1 is null || r2 is null)
            return false;

        return r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator;
    }

    public static bool operator !=(RationalNumber r1, RationalNumber r2)
    {
        return !(r1 == r2);
    }

    public static bool operator <(RationalNumber r1, RationalNumber r2)
    {
        return r1.Numerator * r2.Denominator < r2.Numerator * r1.Denominator;
    }

    public static bool operator >(RationalNumber r1, RationalNumber r2)
    {
        return r1.Numerator * r2.Denominator > r2.Numerator * r1.Denominator;
    }

    public static bool operator <=(RationalNumber r1, RationalNumber r2)
    {
        return r1 < r2 || r1 == r2;
    }

    public static bool operator >=(RationalNumber r1, RationalNumber r2)
    {
        return r1 > r2 || r1 == r2;
    }

    #endregion

    #region ��������������� ������

    public override string ToString() =>
        Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";

    public override bool Equals(object obj)
    {
        if (obj is RationalNumber other)
        {
            return this == other;
        }

        return false;
    }

    public override int GetHashCode() =>
        HashCode.Combine(Numerator, Denominator);

    #endregion
}
