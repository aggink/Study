using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Selestz.Task1;


namespace Study.Lab1.Logic.Selestz;
public class SelestzService : IRunService
{
    public void RunTask1()
    {
        var a = new RationalNumber(1, 3);
        var b = new RationalNumber(12, 5);
        var c = new RationalNumber(52, 13);
        var d = new RationalNumber(-5, 21);
        var e = new RationalNumber(-23, -4);

        var sum = a + b;
        var diff = a - b;
        var Multiply = a * b;
        var Division = a / b;
        var areEqual = a == b;

        Console.Write($"a: {a}, b: {b}, c:{c}, d:{d}, e:{e}\n" +
                      $"a + b = {sum}\n" +
                      $"a - b = {diff}\n" +
                      $"a * b = {Multiply}\n" +
                      $"a / b = {Division}\n" +
                      $"a == b ? {areEqual}\n" +
                      $"-a: {-a}\n" +
                      $"-d: {-d}\n" +
                      $"-e: {-e}\n" +
                      $"a>b: {a > b}\n" +
                      $"b<a: {b < a}\n" +
                      $"b<=c: {b <= c}\n" +
                      $"d<=b: {d <= b}\n" +
                      $"d>=a: {d >= a}\n"
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