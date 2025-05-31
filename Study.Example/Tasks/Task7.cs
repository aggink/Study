using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class MyClass
{
    public int A { get; set; }
    public int B { get; set; }

    public MyClass(int a, int b)
    {
        A = a;
        B = b;
    }

    public static MyClass operator +(MyClass x, MyClass y)
    {
        return new MyClass(x.A + y.A, x.B + y.B);
    }

    public override string ToString()
    {
        return $"A = {A}, B = {B}";
    }
}

public class Task7 : IRunnable
{
    public void Run()
    {
        var obj1 = new MyClass(1, 2);
        var obj2 = new MyClass(5, 7);

        Console.WriteLine($"Объект 1: {obj1}");
        Console.WriteLine($"Объект 2: {obj2}");

        var obj3 = obj1 + obj2;

        Console.WriteLine($"Результат операции: {obj3}");
    }
}
