﻿using Study.Lab1.Logic.Assistant;
using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.kinkiss1;
using Study.Lab1.Logic.katty;
using Study.Lab1.Logic.xynthh;
using Study.Lab1.Logic.lsokol14l;

public static class Program
{
    /// <summary>
    /// Номер выполняемой задачи
    /// </summary>
    private const int RUN_TASK_NUMBER = 1;

    /// <summary>
    /// Название группы
    /// </summary>
    private const string GROUP_NAME = "idb-23-02";

    /// <summary>
    /// Порядковый номер
    /// </summary>
    private const int PERSON_NUMBER = 19;

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
            default:
                throw new NotSupportedException();
        }
    }
}