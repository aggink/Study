namespace Study.Lab1.Logic.Pro100futa.Task1;


[TestFixture]
internal class RationalNumsTest
{
    [Test]
    public void Constructor_ValidInput_ShouldInitializeCorrectly()
    {
        var A = new RationalNumber(3, 6);
        Assert.IsTrue(1 == A.Numerator);
        Assert.IsTrue(2 == A.Denominator);
    }

    [Test]
    public void Operator_Addition_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(2, 9);
        var B = new RationalNumber(3, 11);
        var C = new RationalNumber(49, 99);
        var result = A + B;
        Assert.IsTrue(C.Numerator == result.Numerator);
        Assert.IsTrue(C.Denominator == result.Denominator);
    }

    [Test]
    public void Operator_Subtraction_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(2, 9);
        var B = new RationalNumber(3, 11);
        if (new RationalNumber(-5, 99) == A - B)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }

    [Test]
    public void Operator_Division_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(3, 9);
        var B = new RationalNumber(3, 11);
        if (new RationalNumber(11, 9) == A / B)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }

    [Test]
    public void Operator_Multiplication_ShouldReturnCorrectResult()
    {
        var A = new RationalNumber(3, 9);
        var B = new RationalNumber(3, 11);
        if (new RationalNumber(1, 11) == A * B)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }

    [Test]
    public void Operator_Equality_ShouldReturnTrueForEqualRationalNumbers()
    {
        var A = new RationalNumber(3, 9);
        var B = new RationalNumber(1, 3);
        if (A == B)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }

    [Test]
    public void Operator_Inequality_ShouldReturnTrueForDifferentRationalNumbers()
    {
        var A = new RationalNumber(3, 9);
        var B = new RationalNumber(2, 3);
        if (A != B)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }
}

