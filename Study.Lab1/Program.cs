﻿using Study.Lab1.Logic.Assistant;
using Study.Lab1.Logic.Interfaces;

public static class Program
{
    /// <summary>
    /// Номер выполняемой задачи
    /// </summary>
    private const int RUN_TASK_NUMBER = 2;

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
            default:
                throw new NotSupportedException();
        }
    }
}
