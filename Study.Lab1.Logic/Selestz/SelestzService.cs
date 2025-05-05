using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Selestz.Task1;
using Study.Lab1.Logic.Selestz.Task2;
using Study.Lab1.Logic.Selestz.Task3;
using System.Text;

namespace Study.Lab1.Logic.Selestz;

public class SelestzService : IRunService
{
    public void RunTask1()
    {
        var a = new RationalNumber(1, 3);
        var b = new RationalNumber(12, 5);
        var c = new RationalNumber(52, 13);
        var d = new RationalNumber(-5, 21);
        var e = new RationalNumber(-23, -4);

        var sum = a + b;
        var diff = a - b;
        var Multiply = a * b;
        var Division = a / b;
        var areEqual = a == b;

        Console.Write($"a: {a}, b: {b}, c:{c}, d:{d}, e:{e}\n" +
                      $"a + b = {sum}\n" +
                      $"a - b = {diff}\n" +
                      $"a * b = {Multiply}\n" +
                      $"a / b = {Division}\n" +
                      $"a == b ? {areEqual}\n" +
                      $"-a: {-a}\n" +
                      $"-d: {-d}\n" +
                      $"-e: {-e}\n" +
                      $"a>b: {a > b}\n" +
                      $"b<a: {b < a}\n" +
                      $"b<=c: {b <= c}\n" +
                      $"d<=b: {d <= b}\n" +
                      $"d>=a: {d >= a}\n"
        );
    }

    public void RunTask2()
    {
        // Создаем форматтеры для европейского и американского форматов
        var europeanDateForm = new EuropeanDateForm();
        var americanDateForm = new AmericanDateForm();

        // Применяем универсальный декоратор
        var decoratedEuropeanForm = new Decorator23(europeanDateForm);
        var decoratedAmericanForm = new Decorator23(americanDateForm);

        var doubleDecorator = new PrefDecorator(decoratedAmericanForm);
        var tripleDecorator = new PostDecorator(doubleDecorator);

        // Выводим результаты форматирования
        Console.WriteLine("Европейский стиль даты и времени:");
        Console.WriteLine(decoratedEuropeanForm.FormatDateTime());

        Console.WriteLine("\nАмериканский стиль даты и времени:");
        Console.WriteLine(decoratedAmericanForm.FormatDateTime());

        Console.WriteLine("\nИспользуется два декоратора:");
        Console.WriteLine(doubleDecorator.FormatDateTime());

        Console.WriteLine("\nИспользуется три декоратора:");
        Console.WriteLine(tripleDecorator.FormatDateTime());
    }

    public void RunTask3()
    {
        {
            var rootstring = new TreeNode<string>("Root");

            var child1 = new TreeNode<string>("Child 1");
            var child2 = new TreeNode<string>("Child 2");

            var grandChild1 = new TreeNode<string>("Grandchild 1");
            var grandGrandChild1 = new TreeNode<string>("GrandGrandchild 2");
            var grandChild11 = new TreeNode<string>("Grandchild 2");

            grandChild1.Add(grandGrandChild1);
            child1.Add(grandChild1);
            child1.Add(grandChild11);
            rootstring.Add(child1);
            rootstring.Add(child2);

            Console.WriteLine("Дерево со строками-значениями:");
            Console.WriteLine(rootstring.GetTree());

            var rootInt = new TreeNode<int>(0);

            var child3 = new TreeNode<int>(1);
            var child4 = new TreeNode<int>(2);

            var grandChild2 = new TreeNode<int>(11);
            var grandChild3 = new TreeNode<int>(22);
            var grandGrandChild2 = new TreeNode<int>(111);

            grandChild2.Add(grandGrandChild2);
            child3.Add(grandChild2);
            child4.Add(grandChild3);
            rootInt.Add(child3);
            rootInt.Add(child4);

            Console.WriteLine("Дерево с числами-значениями:");
            Console.WriteLine(rootInt.GetTree());
        }
    }
}