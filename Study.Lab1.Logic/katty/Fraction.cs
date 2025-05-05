namespace Study.Lab1.Logic.katty;

public class Fraction
{
    /// <summary>
    /// Числитель
    /// </summary>
    public int Numerator { get; init; }

    /// <summary>
    /// Знаменатель
    /// </summary>
    public int Denominator { get; init; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException(nameof(denominator));

        Numerator = numerator;
        Denominator = denominator;
    }

    #region Переопределение операций
    public static Fraction operator +(Fraction arg1, Fraction arg2)
    {
        return new Fraction(1, 1);
    }
    #endregion

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}
