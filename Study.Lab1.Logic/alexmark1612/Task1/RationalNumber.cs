﻿using Study.Lab1.Logic.Interfaces.alexmark1612.Task1;

namespace Study.Lab1.Logic.alexmark1612.Task1;

public class RationalNumber : IRationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("Знаменатель не может быть равен нулю.");

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int nod = Math.Abs(NOD(numerator, denominator));
        Numerator = numerator / nod;
        Denominator = denominator / nod;
    }

    public override bool Equals(object other)
    {
        if (other is RationalNumber)
        {
            var number = (RationalNumber)other;
            return this == number;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    public override string ToString()
    {
        if (Denominator == 1)
            return $"{Numerator}";

        return $"{Numerator}/{Denominator}";
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a.Numerator, a.Denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator;
        int denominator = a.Denominator * b.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return (a.Numerator * b.Denominator) < (b.Numerator * a.Denominator);
    }
    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return (a.Numerator * b.Denominator) <= (b.Numerator * a.Denominator);
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return (a.Numerator * b.Denominator) > (b.Numerator * a.Denominator);
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return (a.Numerator * b.Denominator) >= (b.Numerator * a.Denominator);
    }

    private static int NOD(int num, int den)
    {
        num = Math.Abs(num);
        den = Math.Abs(den);

        while (den != 0)
        {
            int t = den;
            den = num % den;
            num = t;
        }
        return num;
    }
}