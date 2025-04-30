using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;
using Study.Lab1.Logic.lsokol14l.Task1;
using Study.Lab1.Logic.lsokol14l.Task2;

namespace Study.Lab1.Logic.lsokol14l;

public class lsokol14lService : IRunService
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
        var dateTime = DateTime.Now;

        IDateFormatter americanFormatter = new AmericanDateFormatter();
        IDateFormatter europeanFormatter = new EuropeanDateFormatter();

        var formattedAmericanDate = americanFormatter.FormatDate(dateTime);
        var formattedAmericanTime = americanFormatter.FormatTime(dateTime);

        Console.WriteLine($"formattedAmericanDate - {formattedAmericanDate}, formattedAmericanTime - {formattedAmericanTime}");

        var formattedEuropeanDate = europeanFormatter.FormatDate(dateTime);
        var formattedEuropeanTime = europeanFormatter.FormatTime(dateTime);

        Console.WriteLine($"formattedEuropeanDate - {formattedEuropeanDate}, formattedEuropeanTime - {formattedEuropeanTime}");

        americanFormatter = new AddBracketsDecorator(americanFormatter);
        americanFormatter = new AddPrefixDecorator(americanFormatter, "**** ");
        americanFormatter = new AddPostfixDecorator(americanFormatter, " ****");

        europeanFormatter = new AddBracketsDecorator(europeanFormatter);
        europeanFormatter = new AddPrefixDecorator(europeanFormatter, "#### ");
        europeanFormatter = new AddPostfixDecorator(europeanFormatter, " ####");

        Console.WriteLine($"American date and time: \n{americanFormatter.FormatDate(dateTime)}\n{americanFormatter.FormatTime(dateTime)}");
        Console.WriteLine($"European date and time: \n{europeanFormatter.FormatDate(dateTime)}\n{europeanFormatter.FormatTime(dateTime)}");
    }


    public void RunTask3()
    {
        throw new NotImplementedException();
    }
}