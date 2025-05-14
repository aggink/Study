using Study.Lab1.Logic.Assistant;
using Study.Lab1.Logic.brnvika;
using Study.Lab1.Logic.Cherryy;
using Study.Lab1.Logic.eldarovskiy;
using Study.Lab1.Logic.gegemonTV;
using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Jki749;
using Study.Lab1.Logic.katty;
using Study.Lab1.Logic.kinkiss1;
using Study.Lab1.Logic.lsokol14l;
using Study.Lab1.Logic.neijrr;
using Study.Lab1.Logic.PresvyatoyKabachok;
using Study.Lab1.Logic.Pro100futa;
using Study.Lab1.Logic.Selestz;
using Study.Lab1.Logic.xynthh;
using Study.Lab1.Logic.freaxd;
using Study.Lab1.Logic.p0se1d0nov;


public static class Program
{
    /// <summary>
    /// Номер выполняемой задачи
    /// </summary>
    private const int RUN_TASK_NUMBER = 1;

    /// <summary>
    /// Название группы
    /// </summary>
    private const string GROUP_NAME = "assistant";

    /// <summary>
    /// Порядковый номер
    /// </summary>
    private const int PERSON_NUMBER = 21;

    public static void Main()
    {
        var service = GetRunLabService(GROUP_NAME, PERSON_NUMBER);

        switch (RUN_TASK_NUMBER)
        {
            case 1:
                service.RunTask1();
                break;
            case 2:
                service.RunTask2();
                break;
            case 3:
                service.RunTask3();
                break;
            default:
                throw new NotSupportedException();
        }
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
            case ("idb-23-02", 6):
                return new Kinkiss1Service();
            case ("idb-23-02", 17):
                return new kattyService();
            case ("idb-23-02", 19):
                return new lsokol14lService();
            case ("idb-23-02", 23):
                return new SelestzService();
            case ("idb-23-02", 10):
                return new PresvyatoyKabachokService();
            case ("idb-23-02", 24):
                return new CherryyService();
            case ("idb-23-02", 2):
                return new EldarovskiyService();
            case ("idb-23-03", 22):
                return new Jki749Service();
            case ("idb-23-03", 6):
                return new neijrrService();
            case ("idb-23-02", 4):
                return new brnvikaService();
            case ("idb-23-03", 15):
                return new gegemonTVService();
            case ("idb-23-03", 23):
                return new Pro100futaService();
            case ("idb-23-03", 16):
                return new freaxdService();
            case ("idb-23-03", 21):
                return new p0se1d0nService();
            default:
                throw new NotSupportedException();
        }
    }
}
