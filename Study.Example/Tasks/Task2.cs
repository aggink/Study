using Study.Example.Interfaces;
using System.Reflection;

namespace Study.Example.Tasks;

public class MessagePrinter
{
    private void Print(string message)
    {
        Console.WriteLine($"Приватное сообщение: {message}");
    }
}

public class Task2 : IRunnable
{
    public void Run()
    {
        var messagePrinter = new MessagePrinter();

        var messagePrinterType = typeof(MessagePrinter);

        var printMethodInfo = messagePrinterType.GetMethod("Print", BindingFlags.NonPublic | BindingFlags.Instance);

        if (printMethodInfo == null)
            throw new Exception("Метод 'Print' не найден");

        printMethodInfo.Invoke(messagePrinter, new object[] { "Привет" });
    }
}
