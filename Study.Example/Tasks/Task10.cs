using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class Task10 : IRunnable
{
    private delegate void MyDelegateA(int x, string message, bool flag);
    private delegate int MyDelegateB(int[] numbers, double value);

    public void MethodA(int x, string message, bool flag)
    {
        Console.WriteLine($"[MethodA] x = {x}, message = {message}, flag = {flag}");
    }

    public int MethodB(int[] numbers, double value)
    {
        var sum = numbers.Sum();
        var result = (int)(sum * value);

        Console.WriteLine($"[MethodB] numbers = {string.Join(" ", numbers)}, value = {value}. Результат: {result}");

        return result;
    }

    public void Run()
    {
        MyDelegateA delA = MethodA;
        MyDelegateB delB = MethodB;

        delA(11, "Привет", false);

        var result = delB(new[] { 1, 2, 3, 4 }, 1.6);
        Console.WriteLine($"[Main] MethodB = {result}");
    }
}
