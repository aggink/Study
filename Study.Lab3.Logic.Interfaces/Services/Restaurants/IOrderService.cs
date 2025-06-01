using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Interfaces.Services.Restaurants;

public interface IOrderService
{
    /// <summary>
    /// Проверка модели заказа на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="order">Заказ</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateOrderValidateAndThrowAsync(
        DataContext dataContext,
        Order order,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления заказа
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="order">Заказ</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Order order,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Генерация номера заказа
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="restaurantId">Идентификатор ресторана</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Номер заказа</returns>
    Task<string> GenerateOrderNumberAsync(
        DataContext dataContext,
        Guid restaurantId,
        CancellationToken cancellationToken = default);
}
