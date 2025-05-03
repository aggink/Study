namespace Study.Lab2.Logic.Interfaces.xynthh;

public interface IRequestService : IDisposable
{
    /// <summary>
    /// Отправить запрос к сервису (синхронный)
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <param name="headers">HTTP заголовки</param>
    /// <returns>Ответ от сервиса</returns>
    string FetchData(string url, Dictionary<string, string> headers = null);

    /// <summary>
    /// Отправить запрос к сервису (асинхронный)
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <param name="headers">HTTP заголовки</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ от сервиса</returns>
    Task<string> FetchDataAsync(
        string url,
        Dictionary<string, string> headers = null,
        CancellationToken cancellationToken = default);
}