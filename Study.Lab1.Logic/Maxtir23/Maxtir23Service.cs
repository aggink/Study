using Study.Lab1.Logic.alkeivi.Task1;
using Study.Lab1.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.Maxtir23;

public class Maxtir23 : IRunService
{
    public void RunTask1()
    {
        var a = new RationalNumber(1, 5);
        var b = new RationalNumber(5, 10);
        var c = new RationalNumber(-1, 5);
        var d = new RationalNumber(10, -17);
        var e = new RationalNumber(-13, -19);
        var f = new RationalNumber(33, 11);

        Console.Write($"a = {a}, b = {b}, c = {c}, d = {d}, e = {e}, f = {f}\n" +
            $"a + b = {a + b}\n" +
            $"a - b = {a - b}\n" +
            $"a / b = {a / b}\n" +
            $"a * b = {a * b}\n" +
            $"a == b ? {a == b}\n" +
            $" -a = {-a}\n" +
            $" -d = {-d}\n" +
            $" -e = {-e}\n" +
            $"a > b: {a > b}\n" +
            $"b < a: {b < a}\n" +
            $"b <= c: {b <= c}\n" +
            $"d <= b: {d <= b}\n" +
            $"d >= a: {d >= a}\n"
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
