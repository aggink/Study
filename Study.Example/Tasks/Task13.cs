using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class Counter
{
    public int Count { get; private set; }

    [ThreadStatic]
    private static int _threadCallCount;

    public void Increment()
    {
        _threadCallCount++;
        Count = _threadCallCount;
        Console.WriteLine($"[Поток: {Thread.CurrentThread.ManagedThreadId}] Вызов № {Count}");
    }
}

public class Task13 : IRunnable
{
    public void Run()
    {
        var counter = new Counter();

        WaitCallback callback = state =>
        {
            for (int i = 0; i < 5; i++)
            {
                counter.Increment();
                Thread.Sleep(100);
            }
        };

        for (int i = 0; i < 3; i++)
        {
            ThreadPool.QueueUserWorkItem(callback);
        }

        Thread.Sleep(5000);
    }
}
