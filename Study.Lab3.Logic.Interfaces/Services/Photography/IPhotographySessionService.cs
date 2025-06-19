using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Photography;

namespace Study.Lab3.Logic.Interfaces.Services.Photography;

public interface IPhotographySessionService
{
    /// <summary>
    /// Проверка модели фотосессии на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="session">Фотосессия</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateSessionValidateAndThrowAsync(
        DataContext dataContext,
        PhotographySession session,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления фотосессии
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="session">Фотосессия</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PhotographySession session,
        CancellationToken cancellationToken = default);
}
