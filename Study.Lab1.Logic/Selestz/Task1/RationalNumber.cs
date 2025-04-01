
using Study.Lab1.Logic.Interfaces.Selestz.Task1;
namespace Study.Lab1.Logic.Selestz.Task1;



public class RationalNumber : IRatNums
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
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
        int NOD = Math.Abs(NodFunction(numerator, denominator));
        Numerator = numerator / NOD;
        Denominator = denominator / NOD;
    }


    #region Перегрузки

    public static RationalNumber operator /(RationalNumber num1, RationalNumber num2)
    {
        int numerator = num1.Numerator * num2.Denominator;
        int denominator = num1.Denominator * num2.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber num1, RationalNumber num2)
    {
        int numerator = num1.Numerator * num2.Numerator;
        int denominator = num1.Denominator * num2.Denominator;
        return new RationalNumber(numerator, denominator);
    }
    public static RationalNumber operator -(RationalNumber num1, RationalNumber num2)
    {
        int numerator = num1.Numerator * num2.Denominator - num2.Numerator * num1.Denominator;
        int denominator = num1.Denominator * num2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber num1)
    {
        return new RationalNumber(-num1.Numerator, num1.Denominator);
    }

    public static RationalNumber operator +(RationalNumber num1, RationalNumber num2)
    {
        int numerator = num1.Numerator * num2.Denominator + num2.Numerator * num1.Denominator;
        int denominator = num1.Denominator * num2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static bool operator ==(RationalNumber num1, RationalNumber num2)
    {
        return num1.Numerator == num2.Numerator && num1.Denominator == num2.Denominator;
    }

    public static bool operator !=(RationalNumber num1, RationalNumber num2)
    {
        return !(num1 == num2);
    }

    public static bool operator <(RationalNumber num1, RationalNumber num2)
    {
        return num1.Numerator * num2.Denominator < num2.Numerator * num1.Denominator;
    }

    public static bool operator >(RationalNumber num1, RationalNumber num2)
    {
        return num1.Numerator * num2.Denominator > num2.Numerator * num1.Denominator;
    }

    public static bool operator <=(RationalNumber num1, RationalNumber num2)
    {
        return num1.Numerator * num2.Denominator <= num2.Numerator * num1.Denominator;
    }

    public static bool operator >=(RationalNumber num1, RationalNumber num2)
    {
        return num1.Numerator * num2.Denominator >= num2.Numerator * num1.Denominator;
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
    /// <param name="Number"></param>
    /// <returns></returns>
    public override bool Equals(object Number)
    {
        if (Number is RationalNumber number)
            return this == number;
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
    /// Вычисляет наименьший общий делитель
    /// </summary>
    /// <param name="FirstNumber"></param>
    /// <param name="SecondNumber"></param>
    /// <returns></returns>
    private static int NodFunction(int FirstNumber, int SecondNumber)
    {
        FirstNumber = Math.Abs(FirstNumber);
        SecondNumber = Math.Abs(SecondNumber);

        while (SecondNumber != 0)
        {
            int tempNumber = SecondNumber;
            SecondNumber = FirstNumber % SecondNumber;
            FirstNumber = tempNumber;
        }

        return FirstNumber;
    }
    #endregion

}

