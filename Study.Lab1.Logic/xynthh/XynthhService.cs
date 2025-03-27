using System.Text;
using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Interfaces.xynthh.Task2;
using Study.Lab1.Logic.xynthh.Task1;
using Study.Lab1.Logic.xynthh.Task2;

namespace Study.Lab1.Logic.xynthh;

public class XynthhService : IRunService
{
    public void RunTask1()
    {
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(3, 4);
            var c = new RationalNumber(5, 10);
            var d = new RationalNumber(8, 2);
            var e = new RationalNumber(-12, -3);

            var sum = a + b; // Используем перегруженный оператор +
            var difference = a - b; // Используем перегруженный оператор -
            var product = a * b; // Используем перегруженный оператор *
            var quotient = a / b; // Используем перегруженный оператор /
            var areEqual = a == b; // Используем перегруженный оператор ==

            Console.Write($"a: {a}, b: {b}, c:5/10\n" +
                          $"a + b = {sum}\n" +
                          $"a - b = {difference}\n" +
                          $"a * b = {product}\n" +
                          $"a / b = {quotient}\n" +
                          $"a == b ? {areEqual}\n" +
                          $"c: {c}\n" +
                          $"d: {d}\n" +
                          $"e: {e}\n" +
                          $"-e: {-e}\n" +
                          $"a>b: {a > b}\n" +
                          $"b<a: {b < a}\n" +
                          $"c<=b: {c <= b}\n" +
                          $"d>=b: {d >= b}\n"
            );

            // e.Denominator = 0; Ошибка => только для чтения;
        }
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