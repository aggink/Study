using Study.Lab1.Logic.alkeivi.Task1;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.alkeivi;

public class alkeiviService : IRunService
{
    public void RunTask1()
    {
        var a = new RationalNumber(1, 2);
        var b = new RationalNumber(5, 10);
        var c = new RationalNumber(-6, 7);
        var d = new RationalNumber(-18, -3);
        var e = new RationalNumber(1, 1);

        var summary = a + b;
        var difference = a - b;
        var product = a * b;
        var quotient = a / b;
        var equality = a == b;

        Console.Write($"a:{a}, b:{b}, c:{c}, d:{d}, e:{e}\n" +
                      $"a + b = {summary}\n" +
                      $"a - b = {difference}\n" +
                      $"a * b = {product}\n" +
                      $"a / b = {quotient}\n" +
                      $"a == b : {equality}\n" +
                      $"a > b : {a > b}\n" +
                      $"b > c : {b > c}\n" +
                      $"d < c : {d < c}\n" +
                      $"e < d : {e < d}\n" +
                      $"c <= b : {e <= b}\n" +
                      $"d >= b : {d >= b}\n"
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
