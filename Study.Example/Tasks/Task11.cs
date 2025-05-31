using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public interface IMyInterface
{
    void Print();
    int GetLength(string input);
    bool CheckValue(int number);
}

public class MyClass4 : IMyInterface
{
    public bool CheckValue(int number)
    {
        var result = number % 2 == 0;

        Console.WriteLine($"Метод CheckValue вызван. Входящие {number}. Исходящие: {result}");

        return result;
    }

    public int GetLength(string input)
    {
        Console.WriteLine($"Метод GetLength вызван. Входящие {input}. Исходящие: {input.Length}");

        return input.Length;
    }

    public void Print()
    {
        Console.WriteLine($"Метод Print вызван");
    }
}

public class Task11 : IRunnable
{
    public void Run()
    {
        IMyInterface obj = new MyClass4();

        obj.Print();
        var length = obj.GetLength("Hello");
        bool isEven = obj.CheckValue(length);

        Console.WriteLine($"Длина строки: {length}");
        Console.WriteLine($"Результат проверки: {isEven}");
    }
}
