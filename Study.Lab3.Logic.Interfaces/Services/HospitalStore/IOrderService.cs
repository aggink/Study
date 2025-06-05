using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Logic.Interfaces.Services.HospitalStore;

/// <summary>
/// Интерфейс сервиса заказов (Order)
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Проверка модели заказа на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="order">Модель заказа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateOrderValidateAndThrowAsync(
        DataContext dataContext,
        Order order,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления заказа
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="order">Модель заказа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Order order,
        CancellationToken cancellationToken = default);
}
