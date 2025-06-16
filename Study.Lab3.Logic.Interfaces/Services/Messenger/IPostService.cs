using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Logic.Interfaces.Services.Messenger;

public interface IPostService
{
    /// <summary>
    /// Проверка модели пользователя на возможность создания
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="post">Сообщение</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreatePostValidateAndThrowAsync(
        DataContext dataContext,
        Post post,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка модели пользователя на возможность редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="post">Сообщение</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task UpdatePostValidateAndThrowAsync(
        DataContext dataContext,
        Post post,
        CancellationToken cancellationToken = default);
}
