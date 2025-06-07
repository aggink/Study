using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Interfaces.Services.Restaurants;

public interface IOrderItemService
{
    /// <summary>
    /// Проверка модели позиции заказа на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="orderItem">Позиция заказа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateOrderItemValidateAndThrowAsync(
        DataContext dataContext,
        OrderItem orderItem,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления позиции заказа
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="orderItem">Позиция заказа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        OrderItem orderItem,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Расчет общей стоимости позиции заказа
    /// </summary>
    /// <param name="quantity">Количество</param>
    /// <param name="unitPrice">Цена за единицу</param>
    /// <returns>Общая стоимость</returns>
    double CalculateTotalPrice(int quantity, double unitPrice);
}
