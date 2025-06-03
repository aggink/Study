using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Services.Restaurants;

public sealed class RestaurantOrderService : IRestaurantOrderService
{
    public async Task CreateOrUpdateOrderValidateAndThrowAsync(
        DataContext dataContext,
        RestaurantOrder restaurantOrder,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Restaurants.AnyAsync(x => x.IsnRestaurant == restaurantOrder.IsnRestaurant, cancellationToken))
            throw new BusinessLogicException($"Ресторан с идентификатором \"{restaurantOrder.IsnRestaurant}\" не существует");

        if (string.IsNullOrWhiteSpace(restaurantOrder.OrderNumber))
            throw new BusinessLogicException("Номер заказа не может быть пустым");

        if (restaurantOrder.OrderNumber.Length > ModelConstants.RestaurantOrder.OrderNumber)
            throw new BusinessLogicException($"Номер заказа не может превышать {ModelConstants.RestaurantOrder.OrderNumber} символов");

        if (string.IsNullOrWhiteSpace(restaurantOrder.CustomerName))
            throw new BusinessLogicException("Имя клиента не может быть пустым");

        if (restaurantOrder.CustomerName.Length > ModelConstants.RestaurantOrder.CustomerName)
            throw new BusinessLogicException($"Имя клиента не может превышать {ModelConstants.RestaurantOrder.CustomerName} символов");

        if (!string.IsNullOrEmpty(restaurantOrder.CustomerPhone) && restaurantOrder.CustomerPhone.Length > ModelConstants.RestaurantOrder.CustomerPhone)
            throw new BusinessLogicException($"Телефон клиента не может превышать {ModelConstants.RestaurantOrder.CustomerPhone} символов");

        if (string.IsNullOrWhiteSpace(restaurantOrder.Status))
            throw new BusinessLogicException("Статус заказа не может быть пустым");

        if (restaurantOrder.Status.Length > ModelConstants.RestaurantOrder.Status)
            throw new BusinessLogicException($"Статус не может превышать {ModelConstants.RestaurantOrder.Status} символов");

        if (restaurantOrder.TableNumber.HasValue && 
            (restaurantOrder.TableNumber < ModelConstants.RestaurantOrder.MinTableNumber || restaurantOrder.TableNumber > ModelConstants.RestaurantOrder.MaxTableNumber))
            throw new BusinessLogicException($"Номер стола должен быть от {ModelConstants.RestaurantOrder.MinTableNumber} до {ModelConstants.RestaurantOrder.MaxTableNumber}");

        if (restaurantOrder.TotalAmount < 0)
            throw new BusinessLogicException("Общая сумма заказа не может быть отрицательной");

        // Проверка уникальности номера заказа в рамках ресторана
        if (await dataContext.RestaurantOrders.AnyAsync(x =>
            x.IsnOrder != restaurantOrder.IsnOrder &&
            x.IsnRestaurant == restaurantOrder.IsnRestaurant &&
            x.OrderNumber == restaurantOrder.OrderNumber,
            cancellationToken))
            throw new BusinessLogicException("Заказ с таким номером уже существует в данном ресторане");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        RestaurantOrder restaurantOrder,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.OrderItems.AnyAsync(x => x.IsnOrder == restaurantOrder.IsnOrder, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить заказ, так как в нем есть позиции");

        // Нельзя удалять завершенные заказы
        if (restaurantOrder.Status == "Completed" || restaurantOrder.Status == "Delivered")
            throw new BusinessLogicException("Невозможно удалить завершенный заказ");
    }

    public async Task<string> GenerateOrderNumberAsync(
        DataContext dataContext,
        Guid restaurantId,
        CancellationToken cancellationToken = default)
    {
        var today = DateTime.UtcNow.Date;
        var todayOrdersCount = await dataContext.RestaurantOrders
            .CountAsync(x => x.IsnRestaurant == restaurantId && x.CreatedDate.Date == today, cancellationToken);

        return $"ORD-{DateTime.UtcNow:yyyyMMdd}-{(todayOrdersCount + 1):D4}";
    }
}
