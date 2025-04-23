using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Jki749.Task1;

namespace Study.Lab1.Logic.Jki749;

public class Jki749Service : IRunService
{
    public void RunTask1()
    {

        var ch1 = new RationalChislo(1, 2);
        var ch2 = new RationalChislo(1, 3);
        var ch3 = new RationalChislo(-1, 5);

        Console.WriteLine($"ch1 = {ch1}");
        Console.WriteLine($"ch2 = {ch2}");
        Console.WriteLine($"ch3 = {ch3}\n");

        var prod = ch1 * ch2;
        Console.WriteLine($"Умножение: {ch1} * {ch2} = {prod}");

        var summ = ch1 + ch2;
        Console.WriteLine($"Сложение: {ch1} + {ch2} = {summ}");

        var minn = ch1 - ch2;
        Console.WriteLine($"Вычитание: {ch1} - {ch2} = {minn}");

        var del = ch1 / ch2;
        Console.WriteLine($"Деление: {ch1} / {ch2} = {del}\n");

        var equality = ch1 == ch1;
        Console.WriteLine($"Сравнение (ch1 == ch1): {equality}");

        var equality2 = ch1 == ch2;
        Console.WriteLine($"Сравнение (ch1 == ch2): {equality2}");

        var equality3 = ch1 <= ch3;
        Console.WriteLine($"Сравнение (ch1 <= ch3): {equality3}");


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
