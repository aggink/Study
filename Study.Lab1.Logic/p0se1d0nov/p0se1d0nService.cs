using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.p0se1d0nov.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.p0se1d0nov;

public class p0se1d0nService : IRunService
{
    public void RunTask1()
    {
        Rational r1 = new Rational(3, 6);
        r1.Numerator = 2;
        Rational r2 = new Rational(4, 12);
        Rational multiplication_rational = r1 * r2;
        Rational division_rational = r1 / r2;
        Rational add_rational = r1 + r2;
        Rational sub_rational = r1 - r2;

        Console.WriteLine($"Rational 1: {r1.ToString()}\n");
        Console.WriteLine($"Rational 2: {r2.ToString()}\n");
        Console.WriteLine($"Multiplication: {multiplication_rational.ToString()}\n");
        Console.WriteLine($"Division: {division_rational.ToString()}\n");
        Console.WriteLine($"Add: {add_rational.ToString()}\n");
        Console.WriteLine($"Sub: {sub_rational.ToString()}\n");

        Console.WriteLine($"r1 > r2: {r1 > r2}\n");
        Console.WriteLine($"r1 < r2: {r1 < r2}\n");
        Console.WriteLine($"r1 >= r2: {r1 >= r2}\n");
        Console.WriteLine($"r1 <= r2: {r1 <= r2}\n");
        Console.WriteLine($"r1 == r2: {r1 == r2}\n");
        Console.WriteLine($"r1 != r2: {r1 != r2}\n");
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

