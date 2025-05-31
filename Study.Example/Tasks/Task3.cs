using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class Task3 : IRunnable
{
    public void Run()
    {
        Console.Write("Введите размер массива: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Некорректное число.");
            return;
        }

        var array = GenerateRandomArray(n);

        Console.WriteLine($"Массив: {string.Join(" ", array)}");

        var median = GetMedian(array);

        Console.WriteLine($"Медианное значение массива: {median}");
    }

    private int[] GenerateRandomArray(int size)
    {
        var random = new Random();
        int[] array = new int[size];

        for (var i = 0; i < size; i++)
            array[i] = random.Next(0, size + 1);

        return array;
    }

    private double GetMedian(int[] array)
    {
        array = array.OrderBy(x => x).ToArray();
        int mid = array.Length / 2;

        Console.WriteLine($"Отсортированный массив: {string.Join(" ", array)}");

        if (array.Length % 2 == 0)
        {
            return (array[mid - 1] + array[mid]) / 2.0;
        }
        else
        {
            return array[mid];
        }
    }
}
