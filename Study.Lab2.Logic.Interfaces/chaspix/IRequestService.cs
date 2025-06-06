namespace Study.Lab2.Logic.Interfaces.chaspix;

public interface IRequestService: IDisposable
{
    /// <summary>
    /// Синхронное выполнение HTTP-запроса
    /// </summary>
    /// <param name="url">URL для запроса</param>
    /// <param name="headers">Дополнительные заголовки</param>
    /// <returns>Ответ от сервера</returns>
    string FetchData(string url, Dictionary<string, string> headers = null);

    /// <summary>
    /// Асинхронное выполнение HTTP-запроса
    /// </summary>
    /// <param name="url">URL для запроса</param>
    /// <param name="headers">Дополнительные заголовки</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ от сервера</returns>
    Task<string> FetchDataAsync(string url, Dictionary<string, string> headers = null, CancellationToken cancellationToken = default);
}