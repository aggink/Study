namespace Study.Lab2.Logic.Interfaces.neijrr;

public interface IServerRequestService : IDisposable
{
    /// <summary>
    /// Получить данные о посте
    /// </summary>
    /// <param name="id">ID поста</param>
    /// <returns>Пост с данным ID</returns>
    IPost GetPost(int id);

    /// <summary>
    /// Отправить пост
    /// </summary>
    /// <param name="userId">ID автора</param>
    /// <param name="title">Название поста</param>
    /// <param name="body">Содержимое поста</param>
    /// <param name="error">Сообщение об ошибке, или <see langword="null"/> при успешной отправке</param>
    /// <returns>ID нового поста</returns>
    int SendPost(int userId, string title, string body);

    /// <summary>
    /// Обновить пост
    /// </summary>
    /// <param name="id">ID поста</param>
    /// <param name="title">Название поста</param>
    /// <param name="body">Содержимое поста</param>
    /// <returns>Обновлённый пост</returns>
    IPost UpdatePost(int id, string title = null, string body = null);

    /// <summary>
    /// Получить данные о посте
    /// </summary>
    /// <param name="id">ID поста</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Пост с данным ID</returns>
    Task<IPost> GetPostAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Отправить пост
    /// </summary>
    /// <param name="userId">ID автора</param>
    /// <param name="title">Название поста</param>
    /// <param name="body">Содержимое поста</param>
    /// <param name="error">Сообщение об ошибке, или <see langword="null"/> при успешной отправке</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>ID нового поста</returns>
    Task<int> SendPostAsync(int userId, string title, string body, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить пост
    /// </summary>
    /// <param name="id">ID поста</param>
    /// <param name="title">Название поста</param>
    /// <param name="body">Содержимое поста</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Обновлённый пост</returns>
    Task<IPost> UpdatePostAsync(int id, string title = null, string body = null, CancellationToken cancellationToken = default);
}
