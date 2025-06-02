using Study.Lab2.Logic.Assistant;
using Study.Lab2.Logic.brnvika;
using Study.Lab2.Logic.eldarovskiy;
using Study.Lab2.Logic.Cherryy;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.katty;
using Study.Lab2.Logic.kinkiss1;
using Study.Lab2.Logic.lsokol14l;
using Study.Lab2.Logic.poigko;
using Study.Lab2.Logic.Selestz;
using Study.Lab2.Logic.xynthh;
using Study.Lab2.Logic.KirillPoroshin;
using Study.Lab2.Logic.Taipano;
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
            case ("idb-23-02", 4):
                return new brnvikaService();
            case ("idb-23-02", 23):
                return new SelestzService();
            case ("idb-23-02", 2):
                return new eldarovskiyService();
            case ("idb-23-02", 6):
                return new kinkiss1Service();
            case ("idb-23-02", 19):
                return new lsokol14lService();
            case ("idb-23-02", 17):
                return new KattyHttpService();
            case ("idb-23-03", 10):
                return new poigkoService();
            case ("idb-23-02", 24):
                return new CherryyService();
            case ("idb-23-03", 17):
                return new KirillPoroshinService();
            case ("idb-23-03", 3):
                return new TaipanoService();
            default:
                throw new NotSupportedException();
        }
    }
}
