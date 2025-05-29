using Study.Lab1.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab1.Logic.cocobara.Task1;

namespace Study.Lab1.Logic.cocobara;

public class cocobaraService : IRunService
{
    public void RunTask1()
    {
        RationalNumber a = new RationalNumber(8, 7);
        RationalNumber b = new RationalNumber(52, 28);
        RationalNumber c = new RationalNumber(9, 11);
        RationalNumber d = new RationalNumber(44, 3);
        RationalNumber e = new RationalNumber(-81, -25);

        RationalNumber sum = a + b;
        RationalNumber diff = a - b;
        RationalNumber mult = a * b;
        RationalNumber quotient = a / b;
        bool equality = a == b;

        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine($"a + b = {sum}");
        Console.WriteLine($"a - b = {diff}");
        Console.WriteLine($"a * b = {mult}");
        Console.WriteLine($"a / b = {quotient}");
        Console.WriteLine($"a == b ? {equality}");
        Console.WriteLine($"c = {c}");
        Console.WriteLine($"d = {d}");
        Console.WriteLine($"e = {e}");
        Console.WriteLine($"-e = {-e}");
        Console.WriteLine($"a > b: {a > b}");
        Console.WriteLine($"b < a: {b < a}");
        Console.WriteLine($"d >= c: {d >= c}");
        Console.WriteLine($"c <= b: {c <= b}");
        Console.WriteLine($"d >= b: {d >= b}");
        Console.WriteLine($"a <= c: {a <= c}");
        Console.WriteLine($"a == d: {a == c}");

        // знаменатель равен нулю => ошибка;
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