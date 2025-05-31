using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class BaseClass
{
    public string Text { get; set; }
    public bool Flag { get; set; }

    public BaseClass(string text, bool flag)
    {
        Text = text;
        Flag = flag;
    }

    public override string ToString()
    {
        return $"Текст: {Text}, Flag: {Flag}";
    }
}

public class ChildrenClass : BaseClass
{
    public ChildrenClass(string text, bool flag) : base(text, flag)
    {

    }
}

public class Task4 : IRunnable
{
    private readonly string[] _sampleTexts = { "Москва", "Санкт-Петербург", "Казань", "Новосибирск", "Екатеринбург" };

    public void Run()
    {
        Console.Write("Введите размер массива: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Некорректное число.");
            return;
        }

        var array1 = new ChildrenClass[n];
        var array2 = new ChildrenClass[n];

        var random = new Random();

        for (int i = 0; i < n; i++)
        {
            array1[i] = new ChildrenClass(_sampleTexts[random.Next(_sampleTexts.Length)], random.Next(2) == 1);
            array2[i] = new ChildrenClass(_sampleTexts[random.Next(_sampleTexts.Length)], random.Next(2) == 1);
        }

        Console.WriteLine("\nМассив 1:");
        Console.WriteLine(string.Join<ChildrenClass>("\n", array1));

        Console.WriteLine("\nМассив 2:");
        Console.WriteLine(string.Join<ChildrenClass>("\n", array2));

        var falseCount1 = GetCountFalseFlags(array1);
        var falseCount2 = GetCountFalseFlags(array2);

        Console.WriteLine($"\nМассив 1: {falseCount1} значений false");
        Console.WriteLine($"Массив 2: {falseCount2} значений false");

        if (falseCount1 > falseCount2)
        {
            Console.WriteLine("\nВ массиве 1 чаще встречаются false");
        }
        else if (falseCount1 < falseCount2)
        {
            Console.WriteLine("\nВ массиве 2 чаще встречаются false");
        }
        else
        {
            Console.WriteLine("\nВ обоих массивах одинаковое количество значений false");
        }
    }

    private int GetCountFalseFlags(ChildrenClass[] array)
    {
        return array.Count(x => x.Flag == false);
    }
}
