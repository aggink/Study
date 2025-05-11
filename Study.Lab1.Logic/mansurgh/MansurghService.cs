using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.mansurgh.Task1;

namespace Study.Lab1.Logic.mansurgh;

public class MansurghService : IRunService
{
    public void RunTask1()
    {
        var a = new RationalNumber(1, 2);     // 1/2
        var b = new RationalNumber(3, 4);     // 3/4
        var c = new RationalNumber(5, 10);    // 5/10 = 1/2
        var d = new RationalNumber(8, 2);     // 8/2 = 4
        var e = new RationalNumber(-12, -3);  // -12/-3 = 4

        var sum = a + b;             // 1/2 + 3/4 = 5/4
        var difference = a - b;      // 1/2 - 3/4 = -1/4
        var product = a * b;         // 1/2 * 3/4 = 3/8
        var quotient = a / b;        // 1/2 / 3/4 = 2/3
        var areEqual = a == b;       // 1/2 == 3/4 → false

        Console.WriteLine("===== Task 1: Rational Numbers =====");
        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine($"a + b = {sum}");
        Console.WriteLine($"a - b = {difference}");
        Console.WriteLine($"a * b = {product}");
        Console.WriteLine($"a / b = {quotient}");
        Console.WriteLine($"a == b ? {areEqual}");
        Console.WriteLine($"c = {c}");
        Console.WriteLine($"d = {d}");
        Console.WriteLine($"e = {e}");
        Console.WriteLine($"-e = {-e}");
        Console.WriteLine($"a > b? {a > b}");
        Console.WriteLine($"b < a? {b < a}");
        Console.WriteLine($"c <= b? {c <= b}");
        Console.WriteLine($"d >= b? {d >= b}");
    }
    
    public void RunTask2()
    {
        Console.WriteLine("Task 2 is not implemented yet.");
    }

    public void RunTask3()
    {
        Console.WriteLine("Task 3 is not implemented yet.");
    }


}
