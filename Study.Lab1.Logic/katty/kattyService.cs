using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Interfaces.katty.Task2;
using Study.Lab1.Logic.Interfaces.katty.Task3;
using Study.Lab1.Logic.katty.Task_2;
using Study.Lab1.Logic.katty.Task_3;

namespace Study.Lab1.Logic.katty;

public class kattyService : IRunService
{
    public void RunTask1()
    {
        var fraction1 = new Fraction(1, 1);
        Console.WriteLine(fraction1.ToString());
    }

    public void RunTask2()
    {
        IDateTimeFormatter europeanFormatter = new EuropeanDateTimeFormatter();
        IDateTimeFormatter americanFormatter = new AmericanDateTimeFormatter();

        europeanFormatter = new StartDecorator(europeanFormatter, "Европейский формат: ");
        europeanFormatter = new NextDecorator(europeanFormatter, " (UTC)");

        americanFormatter = new StartDecorator(americanFormatter, "Американский формат: ");
        americanFormatter = new NextDecorator(americanFormatter, " (UTC)");

        string europeanDateTime = europeanFormatter.FormatDateTime(DateTime.Now);
        string americanDateTime = americanFormatter.FormatDateTime(DateTime.Now);

        Console.WriteLine(europeanDateTime);
        Console.WriteLine(americanDateTime);
    }

    public void RunTask3()
    {
        ITreeService treeService = new TreeService();
        treeService.BuildSampleTree();

        Console.WriteLine("Структура дерева:");
        Console.WriteLine(treeService.Root.GetTreeAsString());

        Console.WriteLine($"\nДерево содержит циклы: {treeService.HasCycles()}");
        Console.WriteLine($"Дерево валидно: {treeService.IsValidTree()}");

        Console.WriteLine("\nВсе узлы дерева:");
        foreach (var value in treeService.Root.GetAllValues())
        {
            Console.WriteLine($"- {value}");
        }
    }
}
