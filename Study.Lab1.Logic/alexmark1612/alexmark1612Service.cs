using Study.Lab1.Logic.alexmark1612.Task1;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.alexmark1612;

public class alexmark1612Service : IRunService
{
    public void RunTask1()
    {
        var a = new RationalNumber(3, 4);
        var b = new RationalNumber(-5, -1);
        var c = new RationalNumber(1, 2);
        var d = new RationalNumber(5, 10);
        var e = new RationalNumber(-1, 2);
        var sum = a + b;
        var difference = a - b;
        var product = a * b;
        var quotient = a / b;
        var anti_a = -a;
        var equal1 = c == d;
        var equal2 = c == e;
        Console.Write($"{sum}\n");
        Console.Write($"{difference}\n");
        Console.Write($"{product}\n");
        Console.Write($"{quotient}\n");
        Console.Write($"{anti_a}\n");
        Console.Write($"{equal1}\n");
        Console.Write($"{equal2}\n");
        Console.Write($"{c >= d}\n");
        Console.Write($"{c <= d}\n");
        Console.Write($"{c >= e}\n");
        Console.Write($"{c <= e}\n");
        Console.Write($"{a > b}\n");
        Console.Write($"{a < b}\n");
        Console.Write($"{a != b}\n");
        Console.Write($"{c != d}\n");
        Console.Write($"{-a - c}\n");
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