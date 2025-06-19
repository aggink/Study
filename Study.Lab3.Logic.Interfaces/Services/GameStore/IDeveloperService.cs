using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;

namespace Study.Lab3.Logic.Interfaces.Services.GameStore;

public interface IDeveloperService
{
    /// <summary>
    /// Проверка модели разработчика на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="developer">Разработчик</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateDeveloperValidateAndThrowAsync(
        DataContext dataContext,
        Developer developer,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления разработчика
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="developer">Разработчик</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Developer developer,
        CancellationToken cancellationToken = default);
}
