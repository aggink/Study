using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IKvnService
{
    /// <summary>
    /// Проверка модели квн на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="kvn">квн</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateKvnValidateAndThrowAsync(
        DataContext dataContext,
        Kvn kvn,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления мероприятия квн
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="kvn">квн</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Kvn kvn,
        CancellationToken cancellationToken = default);
}