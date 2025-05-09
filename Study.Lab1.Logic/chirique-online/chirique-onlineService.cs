using Study.Lab1.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab1.Logic.chirique_online.Task1;

namespace Study.Lab1.Logic.chirique_online;

public class chiriqueOnlineService : IRunService
{
    public void RunTask1()
    {
        var A = new RationalNumber(8, 7);
        var B = new RationalNumber(52, 28);
        var C = new RationalNumber(9, 11);
        var D = new RationalNumber(44, 3);
        var E = new RationalNumber(-81, -25);

        var sum = A + B; // перегруженный оператор +
        var diff = A - B; // перегруженный оператор -
        var mult = A * B; // перегруженный оператор *
        var quotient = A / B; // перегруженный оператор /
        var equality = A == B; // перегруженный оператор ==

        Console.Write($"a = {A}, b = {B}\n" +
                        $"a + b = {sum}\n" +
                        $"a - b = {diff}\n" +
                        $"a * b = {mult}\n" +
                        $"a / b = {quotient}\n" +
                        $"a == b ? {equality}\n" +
                        $"c = {C}\n" +
                        $"d = {D}\n" +
                        $"e = {E}\n" +
                        $"-e = {-E}\n" +
                        $"a > b: {A > B}\n" +
                        $"b < a: {B < A}\n" +
                        $"d >= c: {D >= C}\n" +
                        $"c <= b: {C <= B}\n" +
                        $"d >= b: {D >= B}\n" +
                        $"a <= c: {A <= C}\n" +
                        $"a == d: {A == C}\n"
        );

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
