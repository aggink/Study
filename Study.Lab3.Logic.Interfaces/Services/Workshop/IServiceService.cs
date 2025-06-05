using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Workshop;

namespace Study.Lab3.Logic.Interfaces.Services.Workshop;

public interface IServiceService
{
    /// <summary>
    /// Проверка модели услуги на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="service">Услуга</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateServiceValidateAndThrowAsync(
        DataContext dataContext,
        Service service,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления услуги
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="service">Услуга</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,  
        Service service,
        CancellationToken cancellationToken = default);
}
