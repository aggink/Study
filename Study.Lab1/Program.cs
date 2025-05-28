using Study.Lab1.Logic.alkeivi;
using Study.Lab1.Logic.Assistant;
using Study.Lab1.Logic.brnvika;
using Study.Lab1.Logic.Cherryy;
using Study.Lab1.Logic.chirique_online;
using Study.Lab1.Logic.eldarovskiy;
using Study.Lab1.Logic.freaxd;
using Study.Lab1.Logic.gegemonTV;
using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.IvanZ;
using Study.Lab1.Logic.Jki749;
using Study.Lab1.Logic.katty;
using Study.Lab1.Logic.kinkiss1;
using Study.Lab1.Logic.love100rubb;
using Study.Lab1.Logic.lsokol14l;
using Study.Lab1.Logic.mansurgh;
using Study.Lab1.Logic.neijrr;
using Study.Lab1.Logic.poigko;
using Study.Lab1.Logic.poroshok;
using Study.Lab1.Logic.PresvyatoyKabachok;
using Study.Lab1.Logic.Pro100futa;
using Study.Lab1.Logic.Selestz;
using Study.Lab1.Logic.SlavicSquat;
using Study.Lab1.Logic.xynthh;
using Study.Lab1.Logic.p0se1d0nov;
using Study.Lab1.Logic.Taipano;
using Study.Lab1.Logic.TucKaW;
using Study.Lab1.Logic.danaky1;
using Study.Lab1.Logic.yamisakimei;
using Study.Lab1.Logic.cocobara;
using Study.Lab1.Logic.Dronio1337;


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
    private const int PERSON_NUMBER = 1;

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
            case ("idb-23-02", 1):
                return new MansurghService();
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
            case ("idb-23-03", 17):
                return new poroshokService();
            case ("idb-23-03", 4):
                return new SlavicSquatService();
            case ("idb-23-03", 7):
                return new IvanZService();
            case ("idb-23-03", 12):
                return new alkeiviService();
            case ("idb-23-02", 12):
                return new chiriqueOnlineService();
            case ("idb-23-03", 9):
                return new TucKaWService();
            case ("idb-23-03", 3):
                return new TaipanoService();
            case ("idb-23-03", 2):
                return new love100rubbService();
            case ("idb-23-03", 10):
                return new poigkoService();
            case ("idb-23-03", 1):
                return new danaky1Service();
            case ("idb-23-03", 8):
                return new yamisakimeiService();
            case("idb-23-02", 5):
                return new Dronio1337Service();
            case ("idb-23-02", 13):
                return new cocobaraService();
            default:
                throw new NotSupportedException();
        }
    }
}
