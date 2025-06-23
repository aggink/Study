using Study.Lab2.Logic.Interfaces.mansurgh.DtoModels;



namespace Study.Lab2.Logic.Interfaces.mansurgh;

public interface IRequestService : IDisposable
{
    /// <summary>
    /// Отправить синхронный HTTP-запрос
    /// </summary>
    /// <param name="url">Адрес API</param>
    /// <returns>Ответ с данными и кодом</returns>
    HttpResponseDto FetchData(string url);

    /// <summary>
    /// Отправить асинхронный HTTP-запрос
    /// </summary>
    /// <param name="url">Адрес API</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ с данными и кодом</returns>
    Task<HttpResponseDto> FetchDataAsync(string url, CancellationToken cancellationToken = default);
}
