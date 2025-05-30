using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public abstract class BaseClass2
{
    public virtual void VirtualMethod()
    {
        Console.WriteLine("Базовая реализация виртуального метода");
    }

    public abstract void AbstractMethod();
}

public class ChildrenClass2 : BaseClass2
{
    public override void AbstractMethod()
    {
        Console.WriteLine("Переопределенная реализация абстрактного метода");
    }

    public override void VirtualMethod()
    {
        Console.WriteLine("Переопределенная реализация виртуального метода");
    }
}

public class Task5 : IRunnable
{
    public void Run()
    {
        var obj = new ChildrenClass2();

        obj.AbstractMethod();
        obj.VirtualMethod();
    }
}
