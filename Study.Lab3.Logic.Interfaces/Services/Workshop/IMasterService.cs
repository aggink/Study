using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Workshop;

namespace Study.Lab3.Logic.Interfaces.Services.Workshop;

public interface IMasterService
{
    /// <summary>
    /// Проверка модели мастера на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="master">Мастер</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateMasterValidateAndThrowAsync(
        DataContext dataContext,
        Master master,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления мастера
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="master">Мастер</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Master master,
        CancellationToken cancellationToken = default);
}