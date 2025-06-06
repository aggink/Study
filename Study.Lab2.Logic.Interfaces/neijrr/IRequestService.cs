namespace Study.Lab2.Logic.Interfaces.neijrr;

public interface IRequestService : IDisposable
{
    /// <summary>
    /// Отправить сервису запрос на получение данных
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <returns>Ответ от сервиса</returns>
    string FetchData(string url);

    /// <summary>
    /// Отправить сервису запрос на изменение данных
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <param name="method">Используемый HTTP метод</param>
    /// <param name="request">Тело запроса</param>
    /// <remarks>
    /// По умолчанию добавляет стандартный заголовок
    /// </remarks>
    /// <returns>Ответ от сервиса</returns>
    string SendData(string url, HttpMethod method, string request);

    /// <summary>
    /// Отправить запрос к сервису
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <remarks>
    /// По умолчанию не добавляет заголовок
    /// </remarks>
    /// <returns>Ответ от сервиса</returns>
    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);

    /// <summary>
    /// Отправить сервису запрос на изменение данных
    /// </summary>
    /// <param name="url">Веб-адрес</param>
    /// <param name="method">Используемый HTTP метод</param>
    /// <param name="request">Тело запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <remarks>
    /// По умолчанию добавляет стандартный заголовок
    /// </remarks>
    /// <returns>Ответ от сервиса</returns>
    Task<string> SendDataAsync(string url, HttpMethod method, string request, CancellationToken cancellationToken = default);
}
