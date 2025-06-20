using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.UTBL;
using Study.Lab1.Logic.UTBL.Task1;

namespace Study.Lab1.Logic.UTBL;

public class UTBLService : IRunService
{
    public void RunTask1()
    {
        var numA = new RationalNumber(27, 12);
        var numB = new RationalNumber(-3, 4);
        var numC = new RationalNumber(5, -3);
        var numD = new RationalNumber(-8, 2);
        var numE = new RationalNumber(-12, -3);
        var numF = new RationalNumber(0, 1);

        var summary = numA + numB;
        var summary2 = numB + numC;
        var summary3 = numD + numE;
        var difference = numA - numB;
        var difference2 = numB - numC;
        var difference3 = numD - numE;
        var product = numA * numB;
        var product2 = numB * numC;
        var product3 = numD * numE;
        var quotient = numA / numB;
        var quotient2 = numB / numC;
        var quotient3 = numD / numE;
        var Equal = numA == numB;
        var Equal2 = numB == numC;
        var Equal3 = numD == numF;

        Console.Write($"a:{numA}, b:{numB}, c:{numC}, d:{numD}, e:{numE}, f:{numF}\n" +
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
                      $"a > b : {numA > numB}\n" +
                      $"b > c : {numB > numC}\n" +
                      $"c > d : {numC > numD}\n" +
                      $"d > e : {numD > numE}\n" +
                      $"b < a : {numB < numA}\n" +
                      $"c < b : {numC < numB}\n" +
                      $"d < c : {numD < numC}\n" +
                      $"e < d : {numE < numD}\n" +
                      $"c <= b : {numE <= numB}\n" +
                      $"d >= b : {numD >= numB}\n"
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