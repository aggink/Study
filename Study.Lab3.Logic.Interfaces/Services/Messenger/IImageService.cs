using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Logic.Interfaces.Services.Messenger;

public interface IImageService
{
    /// <summary>
    /// Проверка модели пользователя на возможность создания
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="image">Изображение</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateImageValidateAndThrowAsync(
        DataContext dataContext,
        Image image,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка модели пользователя на возможность редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="image">Изображение</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task UpdateImageValidateAndThrowAsync(
        DataContext dataContext,
        Image image,
        CancellationToken cancellationToken = default);
}
