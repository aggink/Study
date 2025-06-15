using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Logic.Interfaces.Services.Messenger;

public interface IUserService
{
    /// <summary>
    /// Проверка модели пользователя на возможность создания
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="user">Пользователь</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateUserValidateAndThrowAsync(
        DataContext dataContext,
        User user,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка модели пользователя на возможность редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="user">Пользователь</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task UpdateUserValidateAndThrowAsync(
        DataContext dataContext,
        User user,
        CancellationToken cancellationToken = default);
}
