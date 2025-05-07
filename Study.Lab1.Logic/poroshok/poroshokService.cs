using System.Text;
using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.poroshok.Task1;
using Study.Lab1.Logic.Interfaces.poroshok.Task2;
using Study.Lab1.Logic.poroshok.Task2;
using Study.Lab1.Logic.Interfaces.poroshok.Task2;
using Study.Lab1.Logic.poroshok.Task2;

namespace Study.Lab1.Logic.poroshok;

public class poroshokService : IRunService
{
    public void RunTask1()
    {
        throw new NotImplementedException();
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

