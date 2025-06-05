using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Workshop;

namespace Study.Lab3.Logic.Interfaces.Services.Workshop;

public interface IServiceOrderService
{
    /// <summary>
    /// Проверка модели заказа на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="serviceOrder">Заказ</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateServiceOrderValidateAndThrowAsync(
        DataContext dataContext,
        ServiceOrder serviceOrder,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления заказа
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="serviceOrder">Заказ</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ServiceOrder serviceOrder,
        CancellationToken cancellationToken = default);
}