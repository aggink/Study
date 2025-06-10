using Study.Example.Interfaces;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Study.Example.Tasks;

public class Task16 : IRunnable
{
    private static readonly object _lock = new object();
    private static int _totalMatches = 0;
    private static readonly ConcurrentBag<long> _waitTimes = new ConcurrentBag<long>();

    public void Run()
    {
        Console.Write("Введите значение X для поиска (0-1000): ");
        if (!int.TryParse(Console.ReadLine(), out int x) || x < 0 || x > 1000)
        {
            Console.WriteLine("Некорректное значение X. Используется значение по умолчанию 100.");
            x = 100;
        }

        var stopwatch = Stopwatch.StartNew();
        int completedThreads = 0;
        const int totalThreads = 10;

        ThreadPool.SetMinThreads(totalThreads, totalThreads);

        for (int i = 0; i < totalThreads; i++)
        {
            int threadNum = i;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                // 1. Генерация массива
                var array = GenerateArray(threadNum);

                // 2. Сортировка (вне критической секции)
                Array.Sort(array);

                // 3. Поиск элементов (в критической секции)
                CountElementsInSortedArray(array, x, threadNum);

                Interlocked.Increment(ref completedThreads);
            });
        }

        while (completedThreads < totalThreads)
        {
            Thread.Sleep(100);
        }

        stopwatch.Stop();

        Console.WriteLine($"\nОбщее количество элементов, равных {x}: {_totalMatches:N0}");

        var nonZeroWaits = _waitTimes.Where(t => t > 0).ToList();
        if (nonZeroWaits.Any())
        {
            Console.WriteLine("\nСтатистика времени ожидания в критической секции:");
            Console.WriteLine($"Количество ненулевых ожиданий: {nonZeroWaits.Count}");
            Console.WriteLine($"Минимальное время: {nonZeroWaits.Min() / 1000.0:N3} мкс");
            Console.WriteLine($"Максимальное время: {nonZeroWaits.Max() / 1000.0:N3} мкс");
            Console.WriteLine($"Среднее время: {nonZeroWaits.Average() / 1000.0:N3} мкс");
        }
        else
        {
            Console.WriteLine("\nНе было зафиксировано ненулевых времен ожидания.");
        }

        Console.WriteLine($"\nОбщее время выполнения: {stopwatch.Elapsed.TotalSeconds:N2} сек");
    }

    private static int[] GenerateArray(int threadId)
    {
        var random = new Random(threadId + Environment.TickCount);
        int size = random.Next(10_000_000, 15_000_001);
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(0, 1001);
        }

        return array;
    }

    private static void CountElementsInSortedArray(int[] sortedArray, int x, int threadId)
    {
        var waitTimer = Stopwatch.StartNew();

        lock (_lock)
        {
            waitTimer.Stop();
            long waitTicks = waitTimer.ElapsedTicks;
            long waitNanoseconds = (long)(waitTicks * (1_000_000_000.0 / Stopwatch.Frequency));

            if (waitNanoseconds > 0)
            {
                _waitTimes.Add(waitNanoseconds);
            }

            // Поиск в отсортированном массиве
            int count = 0;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (sortedArray[i] == x) count++;
                else if (sortedArray[i] > x) break; // Оптимизация для отсортированного массива
            }

            _totalMatches += count;
            Console.WriteLine($"Поток {threadId}: найдено {count:N0} элементов");
        }
    }
}
