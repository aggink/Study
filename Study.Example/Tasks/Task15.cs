using Study.Example.Interfaces;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Study.Example.Tasks;

public class Result
{
    public int ThreadId { get; }
    public int ArraySize { get; }
    public int Matches { get; }
    public TimeSpan ElapsedTime { get; }

    public Result(int threadId, int arraySize, int matches, TimeSpan elapsedTime)
    {
        ThreadId = threadId;
        ArraySize = arraySize;
        Matches = matches;
        ElapsedTime = elapsedTime;
    }
}


public class Task15 : IRunnable
{
    public void Run()
    {
        Console.Write("Введите значение X для поиска: ");
        if (!int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("Некорректное значение X. Используется значение по умолчанию 100.");
            x = 100;
        }

        var stopwatch = Stopwatch.StartNew();
        var results = new ConcurrentBag<Result>();
        int completedThreads = 0;
        const int totalThreads = 10;

        // Устанавливаем минимальное количество потоков в пуле
        ThreadPool.SetMinThreads(totalThreads, totalThreads);

        // Создаем и запускаем 10 задач через пул потоков
        for (int i = 0; i < totalThreads; i++)
        {
            int threadNum = i;
            ThreadPool.QueueUserWorkItem(state =>
            {
                var result = ProcessArray(threadNum, x);
                results.Add(result);

                Interlocked.Increment(ref completedThreads);
            });
        }

        // Ожидаем завершения всех потоков
        while (completedThreads < totalThreads)
        {
            Thread.Sleep(100);
        }

        stopwatch.Stop();

        // Выводим результаты
        Console.WriteLine("\nРезультаты выполнения:");
        foreach (var result in results)
        {
            Console.WriteLine($"Поток {result.ThreadId}: " +
                $"Размер массива: {result.ArraySize:N0}, " +
                $"Найдено элементов: {result.Matches:N0}, " +
                $"Время: {result.ElapsedTime.TotalMilliseconds:N2} мс");
        }

        // Выводим статистику
        Console.WriteLine("\nСтатистика:");
        Console.WriteLine($"Общее время выполнения: {stopwatch.Elapsed.TotalMilliseconds:N2} мс");
        Console.WriteLine($"Минимальное время: {CalculateMinTime(results):N2} мс");
        Console.WriteLine($"Максимальное время: {CalculateMaxTime(results):N2} мс");
        Console.WriteLine($"Среднее время: {CalculateAverageTime(results):N2} мс");
    }

    private static Result ProcessArray(int threadId, int x)
    {
        var sw = Stopwatch.StartNew();
        var random = new Random(threadId + Environment.TickCount);

        // Генерируем размер массива (10-15 млн)
        int size = random.Next(10_000_000, 15_000_001);

        // Создаем и заполняем массив
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(0, 1001);
        }

        // Сортируем массив
        Array.Sort(array);

        // Ищем количество элементов, равных X
        int count = 0;
        for (int i = 0; i < size; i++)
        {
            if (array[i] == x) count++;
            else if (array[i] > x) break;
        }

        sw.Stop();
        return new Result(threadId, size, count, sw.Elapsed);
    }

    private static double CalculateMinTime(ConcurrentBag<Result> results)
    {
        double min = double.MaxValue;
        foreach (var result in results)
        {
            if (result.ElapsedTime.TotalMilliseconds < min)
                min = result.ElapsedTime.TotalMilliseconds;
        }
        return min;
    }

    private static double CalculateMaxTime(ConcurrentBag<Result> results)
    {
        double max = double.MinValue;
        foreach (var result in results)
        {
            if (result.ElapsedTime.TotalMilliseconds > max)
                max = result.ElapsedTime.TotalMilliseconds;
        }
        return max;
    }

    private static double CalculateAverageTime(ConcurrentBag<Result> results)
    {
        double sum = 0;
        int count = 0;
        foreach (var result in results)
        {
            sum += result.ElapsedTime.TotalMilliseconds;
            count++;
        }
        return sum / count;
    }
}
