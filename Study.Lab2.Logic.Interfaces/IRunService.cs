﻿
public interface IRunService : IDisposable
{
    /// <summary>
    /// Запуск выполнения задания
    /// </summary>
    void RunTask();

    /// <summary>
    /// Запуск выполнения задания
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    Task RunTaskAsync(CancellationToken cancellationToken = default);
}