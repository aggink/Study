using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarService;

namespace Study.Lab3.Logic.Interfaces.Services.CarService;

public interface IServiceRecordService
{
    /// <summary>
    /// Проверка записи на возможность создания/редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="record">TO</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateServiceRecordValidateAndThrowAsync(
        DataContext dataContext,
        ServiceRecord record,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверка записи на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="record">TO</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ServiceRecord record,
        CancellationToken cancellationToken = default);
}