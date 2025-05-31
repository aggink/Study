using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class EventPublisher
{
    private EventHandler<int> _eventPublisher;

    public event EventHandler<int> PublisherEvent
    {
        add
        {
            _eventPublisher += value;
            Console.WriteLine($"Метод {value.Method.Name} подписан на событие");
        }
        remove
        {
            _eventPublisher -= value;
            Console.WriteLine($"Метод {value.Method.Name} отписан от события");
        }
    }

    public void InvokeEvent(int n)
    {
        _eventPublisher?.Invoke(this, n);
    }
}

public class Task12 : IRunnable
{
    public void HandleEvent(object sender, int f)
    {
        Console.WriteLine($"Событие вызвано с числом: {f}");
    }

    public void Run()
    {
        var publisher = new EventPublisher();

        publisher.PublisherEvent += HandleEvent;

        publisher.InvokeEvent(11);

        publisher.PublisherEvent -= HandleEvent;
    }
}
