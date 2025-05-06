using Study.Lab1.Logic.freaxd.Task1;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.freaxd;

public class freaxdService : IRunService
{
    public void RunTask1()
    {
        var num1 = new RationalNumber(1, 2);
        var num2 = new RationalNumber(4, 6);
        var num3 = new RationalNumber(-5, 7);

        Console.WriteLine($"num1 = {num1}");
        Console.WriteLine($"num2 = {num2}");
        Console.WriteLine($"num3 = {num3}\n");

        var sum = num1 + num2;
        Console.WriteLine($"Сложение: {num1} + {num2} = {sum}");

        var sub = num1 - num2;
        Console.WriteLine($"Вычитание: {num1} - {num2} = {sub}");

        var mult = num1 * num2;
        Console.WriteLine($"Умножение: {num1} * {num2} = {mult}");

        var div = num1 / num2;
        Console.WriteLine($"Деление: {num1} / {num2} = {div}");

        var neg = -num3;
        Console.WriteLine($"Отрицание: -({num3}) = {neg}");

        var equal1 = num1 == num2;
        Console.WriteLine($"Сравнение ({num1} == {num2}): {equal1}");

        var equal2 = num1 != num3;
        Console.WriteLine($"Сравнение ({num1} != {num3}): {equal2}");

        var equal3 = num1 > num2;
        Console.WriteLine($"Сравнение ({num1} > {num2}): {equal3}");

        var equal4 = num1 <= num3;
        Console.WriteLine($"Сравнение ({num1} <= {num3}): {equal4}");
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