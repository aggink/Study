using Study.Lab1.Logic.eduardvafin56.Task1;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.eduardvafin56;

public class Eduardvafin56Service : IRunService
{
    public void RunTask1()
    {
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(4, 5);
            var c = new RationalNumber(6, 12);
            var d = new RationalNumber(10, 2);
            var e = new RationalNumber(-12, -3);

            var sum = a + b;
            var difference = a - b;
            var product = a * b;
            var quotient = a / b;
            var areEqual = a == b;

            Console.Write($"a: {a}, b: {b}, c:6/12\n" +
                          $"a + b = {sum}\n" +
                          $"a - b = {difference}\n" +
                          $"a * b = {product}\n" +
                          $"a / b = {quotient}\n" +
                          $"a == b ? {areEqual}\n" +
                          $"c: {c}\n" +
                          $"d: {d}\n" +
                          $"e: {e}\n" +
                          $"-e: {-e}\n" +
                          $"a>b: {a > b}\n" +
                          $"b<a: {b < a}\n" +
                          $"c<=b: {c <= b}\n" +
                          $"d>=b: {d >= b}\n"
            );
        }
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