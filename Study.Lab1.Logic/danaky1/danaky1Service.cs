using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.danaky1.Task1;
using System.Text;

namespace Study.Lab1.Logic.danaky1;

public class danaky1Service : IRunService
{
    public void RunTask1()
    {
        var A = new RationalNumber(2, 4);
        var B = new RationalNumber(6, 8);
        var C = new RationalNumber(10, 20);
        var D = new RationalNumber(-16, 18);
        var E = new RationalNumber(-24, -6);
        var F = new RationalNumber(2, 2);

        var summary = A + B;

        var difference = A - B;

        var product = A * B;

        var quotient = A / B;

        var Equal = A == B;

        Console.Write($"a:{A}, b:{B}, c:{C}, d:{D}, e:{E}, f:{F}\n" +
                      $"a + b = {summary}\n" +
                      $"a - b = {difference}\n" +
                      $"a * b = {product}\n" +
                      $"a / b = {quotient}\n" +
                      $"a == b : {Equal}\n" +
                      $"a > b : {A > B}\n" +
                      $"b > c : {B > C}\n" +
                      $"c > d : {C > D}\n" +
                      $"d > e : {D > E}\n" +
                      $"b < a : {B < A}\n" +
                      $"c < b : {C < B}\n" +
                      $"d < c : {D < C}\n" +
                      $"e < d : {E < D}\n" +
                      $"c <= b : {E <= B}\n" +
                      $"d >= b : {D >= B}\n"
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

