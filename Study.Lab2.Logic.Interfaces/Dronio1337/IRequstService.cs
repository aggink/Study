﻿namespace Study.Lab2.Logic.Interfaces.Dronio1337;

public interface IRequstService : IDisposable
{
    /// <summary>
    /// Отправить запрос к сервису
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <returns>Ответ от сервиса</returns>
    string FetchData(string url);

    /// <summary>
    /// Отправить запрос к сервису
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ от сервиса</returns>
    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
}