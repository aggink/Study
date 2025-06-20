using Study.Lab2.Logic.alexmark1612;
using Study.Lab2.Logic.alkeivi;
using Study.Lab2.Logic.Assistant;
using Study.Lab2.Logic.baldfromazzers;
using Study.Lab2.Logic.brnvika;
using Study.Lab2.Logic.chaspix;
using Study.Lab2.Logic.Cherryy;
using Study.Lab2.Logic.chirique_online;
using Study.Lab2.Logic.Crocodile17;
using Study.Lab2.Logic.danaky1;
using Study.Lab2.Logic.eldarovskiy;
using Study.Lab2.Logic.freaxd;
using Study.Lab2.Logic.gegemonTV;
using Study.Lab2.Logic.IvanZ;
using Study.Lab2.Logic.Jki749;
using Study.Lab2.Logic.katty;
using Study.Lab2.Logic.kinkiss1;
using Study.Lab2.Logic.KirillPoroshin;
using Study.Lab2.Logic.love100rubb;
using Study.Lab2.Logic.lsokol14l;
using Study.Lab2.Logic.mariabyrrrrak;
using Study.Lab2.Logic.neijrr;
using Study.Lab2.Logic.p0se1d0n;
using Study.Lab2.Logic.poigko;
using Study.Lab2.Logic.PresvyatoyKabachok;
using Study.Lab2.Logic.Pro100futa;
using Study.Lab2.Logic.Selestz;
using Study.Lab2.Logic.Taipano;
using Study.Lab2.Logic.TucKaW;
using Study.Lab2.Logic.xynthh;
using Study.Lab2.Logic.yamisakimei;
using Study.Lab2.Logic.SuperSalad007;
using Study.Lab2.Logic.Bonnemort;
using Study.Lab2.Logic.cocobara;
using Study.Lab2.Logic.eduardvafin56;

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
            case ("idb-23-03", 21):
                return new p0se1d0nService();
            case ("idb-23-03", 2):
                return new love100rubbService();
            case ("idb-23-03", 22):
                return new jki749Service();
            case ("idb-23-03", 12):
                return new alkeiviService();
            case ("idb-23-02", 10):
                return new PresvyatoyKabachokService();
            case ("idb-23-03", 20):
                return new mariabyrrrrakService();
            case ("idb-23-03", 15):
                return new gegemonTVService();
            case ("idb-23-03", 23):
                return new Pro100futaService();
            case ("idb-23-02", 12):
                return new chiriqueOnlineService();
            case ("idb-23-03", 9):
                return new TucKaWService();
            case ("idb-23-03", 1):
                return new danaky1Service();
            case ("idb-23-03", 16):
                return new freaxdService();
            case ("idb-23-03", 6):
                return new neijrrService();
            case ("idb-23-03", 5):
                return new SuperSalad007Service();
            case ("idb-23-02", 11):
                return new ChaspixService();
            case ("idb-23-03", 8):
                return new yamisakimeiService();
            case ("idb-23-03", 13):
                return new alexmark1612Service();
            case ("idb-23-03", 7):
                return new IvanZService();
            case ("idb-23-03", 19):
                return new Crocodile17Service();
            case ("idb-23-02", 18):
                return new BonnemortService();
            case ("idb-23-02", 7):
                return new Eduardvafin56Service();
            case ("idb-23-02", 22):
                return new baldfromazzersService();
            case ("idb-23-02", 13):
                return new cocobaraService();
            default:
                throw new NotSupportedException();
        }
    }
}
