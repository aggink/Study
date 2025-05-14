using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Interfaces.poroshok.Task2;
using Study.Lab1.Logic.poroshok.Task1;
using Study.Lab1.Logic.poroshok.Task2;
using System.Text;

namespace Study.Lab1.Logic.poroshok;

public class poroshokService : IRunService
{
    public void RunTask1()
    {
        var A = new RationalNumber(1, 2);
        var B = new RationalNumber(3, 4);
        var C = new RationalNumber(5, 10);
        var D = new RationalNumber(-8, 9);
        var E = new RationalNumber(-12, -3);
        var F = new RationalNumber(1, 1);

        var summary = A + B;

        var difference = A - B;

        var product = A * B;

        var quotient = A / B;

        var Equal = A == B;

        Console.Write($"a:{A}, b:{B}, c:{C}, d:{D}, e:{E}, f:{F}\n" +
                      $"a + b = {summary}\n" +
                      $"a - b = {difference}\n" +
                      $"a * b = {product}\n" +
                      $"a / b = {quotient}\n" +
                      $"a == b : {Equal}\n" +
                      $"a > b : {A > B}\n" +
                      $"b > c : {B > C}\n" +
                      $"c > d : {C > D}\n" +
                      $"d > e : {D > E}\n" +
                      $"b < a : {B < A}\n" +
                      $"c < b : {C < B}\n" +
                      $"d < c : {D < C}\n" +
                      $"e < d : {E < D}\n" +
                      $"c <= b : {E <= B}\n" +
                      $"d >= b : {D >= B}\n"
            );
    }

    public void RunTask2()
    {
        var output = new StringBuilder();
        output.AppendLine("--- Задание 2: Форматы Даты и Времени ---\n");

        output.AppendLine("Американский стиль:\n");
        IDateTimeFormatter ad1 = new AmericanDateTimeFormatter();
        ad1 = new AddBracketsDecorator(ad1);
        ad1 = new AddPrefixDecorator(ad1, "**** ");
        ad1 = new AddSuffixDecorator(ad1, " ****");
        output.AppendLine(ad1.FormatDateTime());

        output.AppendLine("\nЕвропейский стиль:\n");
        IDateTimeFormatter ed1 = new EuropeanDateTimeFormatter();
        ed1 = new AddBracketsDecorator(ed1);
        ed1 = new AddPrefixDecorator(ed1, "#### ");
        ed1 = new AddSuffixDecorator(ed1, " ####");
        output.AppendLine(ed1.FormatDateTime());

        Console.Write(output.ToString());
    }

    public void RunTask3()
    {
        throw new NotImplementedException();
    }
}

