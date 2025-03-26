using Study.Lab1.Logic.Interfaces.kinkiss1.task1;
namespace Study.Lab1.Logic.kinkiss1.task1;

public class RationalNumber: IRationalNum
{
    public int Numerator { get; }
    public int Denominator { get; }
    public RationalNumber (int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("Знаменатель не может быть равен нулю");
        }
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        var nod = Math.Abs(NOD(numerator, denominator));
        Numerator = numerator / nod;
        Denominator = denominator / nod;
    }
   
    
    #region Перегрузка операторов

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator;
        int denominator = a.Denominator * b.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Numerator;
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

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
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
    #endregion

    #region Методы
   
    
    /// <summary>
    /// Переопределение метода ToString
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (Denominator == 1) 
            return $"{Numerator}";

        return $"{Numerator}/{Denominator}";

    }



    /// <summary>
    /// Переопределение метода Equals
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals(object other)
    {
        if (other is RationalNumber)
        {
            var number = (RationalNumber)other;
            return this == number;
        }
        return false;
    }


    /// <summary>
    /// Переопределение метода GetHashCode
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }


    /// <summary>
    /// Вычисляет НОД для двух чисел
    /// </summary>
    /// <param name="one"></param>
    /// <param name="two"></param>
    /// <returns></returns>
    private static int NOD (int one, int two)
    {
     one=Math.Abs(one);
     two = Math.Abs(two);

     while (two != 0)
     { 
         var t = two;
         two = one % two;
         one = t;
     }

     return one;
    }
    #endregion
}