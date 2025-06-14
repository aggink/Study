using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;

namespace Study.Lab3.Logic.Interfaces.Services.GameStore;

public interface IPlatformService
{
    /// <summary>
    /// Проверка модели платформы на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="platform">Платформа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdatePlatformValidateAndThrowAsync(
        DataContext dataContext,
        Platform platform,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления платформы
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="platform">Платформа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Platform platform,
        CancellationToken cancellationToken = default);
}
