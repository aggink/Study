namespace Study.Lab2.Logic.Interfaces.kinkiss1;

public interface IServerRequestService : IDisposable
{
    /// <summary>
    /// Получить данные о пользователе с JSONPlaceholder
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <returns>Данные о пользователе в формате JSON</returns>
    string JsonGetUser(int userId);

    /// <summary>
    /// Получить данные о пользователе с ReqRes
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <returns>Данные о пользователе в формате JSON</returns>
    string ReqresGetUser(int userId);

    /// <summary>
    /// Асинхронная версия получения фактов о кошках
    /// </summary>
    /// <returns>Данные о кошках в формате Json</returns>>
    string CatGetFacts();

    /// <summary>
    /// Получить данные о посте с JSONPlaceholder
    /// </summary>
    /// <param name="postId">ID поста</param>
    /// <returns>Данные о посте в формате JSON</returns>
    string JsonGetPost(int postId);

    /// <summary>
    /// Асинхронная версия получения данных о пользователе с JSONPlaceholder
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные о пользователе в формате JSON</returns>
    Task<string> JsonGetUserAsync(int userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронная версия получения данных о пользователе с ReqRes
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные о пользователе в формате JSON</returns>
    Task<string> ReqresGetUserAsync(int userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронная версия получения данных о посте с JSONPlaceholder
    /// </summary>
    /// <param name="postId">ID поста</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные о посте в формате JSON</returns>

    Task<string> JsonGetPostAsync(int postId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронная версия получения фактов о кошках
    /// </summary>
    /// <paparam name="cancellationToken">Токен отмены</param>
    /// <returns>Данные о кошках в формате Json</returns>>
    Task<string> CatGetFactsAsync(CancellationToken cancellationToken = default);


}
