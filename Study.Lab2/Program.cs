using Study.Lab2.Logic.Assistant;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.xynthh;

public static class Program
{
    /// <summary>
    /// Название группы
    /// </summary>
    private const string GROUP_NAME = "assistant";

    /// <summary>
    /// Порядковый номер
    /// </summary>
    private const int PERSON_NUMBER = 1;

    public static async Task Main()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("========================================");
        Console.WriteLine("Лабораторная работа: Работа с HTTP-запросами");
        Console.WriteLine("Группа: " + GROUP_NAME.ToUpper() + " | Участник #" + PERSON_NUMBER);
        Console.WriteLine("========================================\n");
        Console.ResetColor();

        using var service = GetRunLabService(GROUP_NAME, PERSON_NUMBER);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Синхронное выполнение (без async/await)\n");
        Console.ResetColor();
        service.RunTask();

        using var cancellationTokenSource = new CancellationTokenSource();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nАсинхронное выполнение (с async/await)\n");
        Console.ResetColor();
        await service.RunTaskAsync(cancellationTokenSource.Token);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nВыполнение завершено. Нажмите любую клавишу для выхода...");
        Console.ResetColor();
        Console.ReadKey();
    }

    /// <summary>
    /// Получить сервис для выполнения задач
    /// </summary>
    /// <param name="group">Название группы</param>
    /// <param name="number">Порядковый номер</param>
    /// <returns>Сервис для выполнения задач</returns>
    private static IRunService GetRunLabService(string group, int number)
    {
        switch (group, number)
        {
            case ("assistant", 1):
                return new AssistantService();
            case ("idb-23-02", 15):
                return new XynthhService();
            default:
                throw new NotSupportedException();
        }
    }
}