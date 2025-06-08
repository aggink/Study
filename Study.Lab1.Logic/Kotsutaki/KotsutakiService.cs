using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Kotsutaki.Task1;

namespace Study.Lab1.Logic.Kotsutaki;

public class KotsutakiService : IRunService
{
   public void RunTask1()
    {
        var A = new RationalNumber(1, 2);
        var B = new RationalNumber(3, 4);
        var C = new RationalNumber(5, 3);
        var D = new RationalNumber(-8, 2);
        var E = new RationalNumber(-12, -3);
        var F = new RationalNumber(0, 1);

        var summary = A + B;
        var summary2 = B + C;
        var summary3 = D + E;
        var difference = A - B;
        var difference2 = B - C;
        var difference3 = D - E;
        var product = A * B;
        var product2 = B * C;
        var product3 = D * E;
        var quotient = A / B;
        var quotient2 = B / C;
        var quotient3 = D / E;
        var Equal = A == B;
        var Equal2 = B == C;
        var Equal3 = D == F;

        Console.Write($"a:{A}, b:{B}, c:{C}, d:{D}, e:{E}, f:{F}\n" +
                      $"a + b = {summary}\n" +
                      $"b + c = {summary2}\n" +
                      $"d + e = {summary3}\n" +
                      $"a - b = {difference}\n" +
                      $"b - c = {difference2}\n" +
                      $"d - e = {difference3}\n" +
                      $"a * b = {product}\n" +
                      $"b * c = {product2}\n" +
                      $"d * e = {product3}\n" +
                      $"a / b = {quotient}\n" +
                      $"b / c = {quotient2}\n" +
                      $"d / e = {quotient3}\n" +
                      $"a == b : {Equal}\n" +
                      $"b == c : {Equal2}\n" +
                      $"d == f : {Equal3}\n" +
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