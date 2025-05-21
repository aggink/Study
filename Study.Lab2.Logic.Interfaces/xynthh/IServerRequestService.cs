namespace Study.Lab2.Logic.Interfaces.xynthh;

public interface IServerRequestService : IDisposable
{
    /// <summary>
    /// Получить данные о пользователе с JSONPlaceholder
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <returns>Данные о пользователе в формате JSON</returns>
    string GetJsonPlaceholderUser(int userId);

    /// <summary>
    /// Получить данные о пользователе с ReqRes
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <returns>Данные о пользователе в формате JSON</returns>
    string GetReqResUser(int userId);

    /// <summary>
    /// Получить данные о посте с JSONPlaceholder
    /// </summary>
    /// <param name="postId">ID поста</param>
    /// <returns>Данные о посте в формате JSON</returns>
    string GetJsonPlaceholderPost(int postId);

    /// <summary>
    /// Асинхронная версия получения данных о пользователе с JSONPlaceholder
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные о пользователе в формате JSON</returns>
    Task<string> GetJsonPlaceholderUserAsync(int userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронная версия получения данных о пользователе с ReqRes
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные о пользователе в формате JSON</returns>
    Task<string> GetReqResUserAsync(int userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронная версия получения данных о посте с JSONPlaceholder
    /// </summary>
    /// <param name="postId">ID поста</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные о посте в формате JSON</returns>
    Task<string> GetJsonPlaceholderPostAsync(int postId, CancellationToken cancellationToken = default);
}