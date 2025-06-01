using Study.Lab1.Logic.yamisakimei.Task1;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.yamisakimei;

public class yamisakimeiService : IRunService
{
    public void RunTask1()
    {
        var a = new RationalNumber(1, 6);
        var b = new RationalNumber(6, 10);
        var c = new RationalNumber(-8, 13);
        var d = new RationalNumber(10, -17);
        var e = new RationalNumber(-1, -19);
        var f = new RationalNumber(22, 11);

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
