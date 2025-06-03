using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class BaseClass3
{
    public int Id { get; set; }
    public string Name { get; set; }

    public BaseClass3(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}

public class ChildrenClass3 : BaseClass3
{
    public ChildrenClass3(int id, string name) : base(id, name)
    {
    }
}

public class MyGenericClass3<T>
    where T : BaseClass3
{
    public MyGenericClass3(T data)
    {
        Data = data;
    }

    public T Data { get; set; }

    public void PrintData()
    {
        Console.WriteLine($"Содержимое: {Data}");
    }
}

public class Task9 : IRunnable
{
    public void Run()
    {
        var obj1 = new MyGenericClass3<BaseClass3>(new BaseClass3(1, "Base Object"));
        var obj2 = new MyGenericClass3<ChildrenClass3>(new ChildrenClass3(2, "Children Object"));

        obj1.PrintData();
        obj2.PrintData();
    }
}
