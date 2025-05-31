using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class MyGenericClass<T>
{
    public void PrintTypeName()
    {
        Console.WriteLine($"Тип данных: {typeof(T).Name}");
    }
}

public class Task8 : IRunnable
{
    public void Run()
    {
        var obj1 = new MyGenericClass<int>();
        obj1.PrintTypeName();

        var obj2 = new MyGenericClass<bool>();
        obj2.PrintTypeName();

        var obj3 = new MyGenericClass<string>();
        obj3.PrintTypeName();

        var obj4 = new MyGenericClass<DateTime>();
        obj4.PrintTypeName();
    }
}
