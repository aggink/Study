namespace Study.Lab2.Logic.Interfaces.kinkiss1;

public interface IRequestService : IDisposable
{
    /// <summary>
    /// Отправить запрос к сервису
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <param name="headers">Заголовки</param>
    /// <returns>Ответ от сервиса</returns>
    string FetchSync(string url, Dictionary<string, string> headers = null);

    /// <summary>
    /// Отправить запрос к сервису
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <param name="headers">Заголовки</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ от сервиса</returns>
    Task<string> FetchAsync(
        string url,
        Dictionary<string, string> headers = null,
        CancellationToken cancellationToken = default);
}
