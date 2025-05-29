using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.mariabyrrrrak.Task1;

namespace Study.Lab1.Logic.mariabyrrrrak;

public class mariabyrrrrakService : IRunService
{
    public void RunTask1()
    {
        RationalNumber number = new RationalNumber(1, 1);
        Console.WriteLine(number);

        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(3, 4);
        var c = new RationalNumber(5, 3);
        var d = new RationalNumber(-8, 2);
        var e = new RationalNumber(-12, -3);

        var sum = a + b;
        var difference = a - b;
        var product = a * b;
        var quotient = a / b;
        var areEqual = a == b;

        Console.Write($"a: {a}, b: {b}, c: {c}, d: {d}, e: {e} \n" +
                      $"a + b = {sum}\n" +
                      $"a - b = {difference}\n" +
                      $"a * b = {product}\n" +
                      $"a / b = {quotient}\n" +
                      $"a == b ? {areEqual}\n" +
                      $"-e: {-e}\n" +
                      $"a>b: {a > b}\n" +
                      $"b<a: {b < a}\n" +
                      $"c<=b: {c <= b}\n" +
                      $"d>=b: {d >= b}\n"
        );
    }

    public void RunTask2()
    {
        throw new NotImplementedException();
    }

    public void RunTask3()
    {
        throw new NotImplementedException();
    }
}