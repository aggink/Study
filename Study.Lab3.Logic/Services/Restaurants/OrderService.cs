using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Services.Restaurants;

public sealed class OrderService : IOrderService
{
    public async Task CreateOrUpdateOrderValidateAndThrowAsync(
        DataContext dataContext,
        Order order,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Restaurants.AnyAsync(x => x.IsnRestaurant == order.IsnRestaurant, cancellationToken))
            throw new BusinessLogicException($"Ресторан с идентификатором \"{order.IsnRestaurant}\" не существует");

        if (string.IsNullOrWhiteSpace(order.OrderNumber))
            throw new BusinessLogicException("Номер заказа не может быть пустым");

        if (order.OrderNumber.Length > ModelConstants.Order.OrderNumber)
            throw new BusinessLogicException($"Номер заказа не может превышать {ModelConstants.Order.OrderNumber} символов");

        if (string.IsNullOrWhiteSpace(order.CustomerName))
            throw new BusinessLogicException("Имя клиента не может быть пустым");

        if (order.CustomerName.Length > ModelConstants.Order.CustomerName)
            throw new BusinessLogicException($"Имя клиента не может превышать {ModelConstants.Order.CustomerName} символов");

        if (!string.IsNullOrEmpty(order.CustomerPhone) && order.CustomerPhone.Length > ModelConstants.Order.CustomerPhone)
            throw new BusinessLogicException($"Телефон клиента не может превышать {ModelConstants.Order.CustomerPhone} символов");

        if (string.IsNullOrWhiteSpace(order.Status))
            throw new BusinessLogicException("Статус заказа не может быть пустым");

        if (order.Status.Length > ModelConstants.Order.Status)
            throw new BusinessLogicException($"Статус не может превышать {ModelConstants.Order.Status} символов");

        if (order.TableNumber.HasValue && 
            (order.TableNumber < ModelConstants.Order.MinTableNumber || order.TableNumber > ModelConstants.Order.MaxTableNumber))
            throw new BusinessLogicException($"Номер стола должен быть от {ModelConstants.Order.MinTableNumber} до {ModelConstants.Order.MaxTableNumber}");

        if (order.TotalAmount < 0)
            throw new BusinessLogicException("Общая сумма заказа не может быть отрицательной");

        // Проверка уникальности номера заказа в рамках ресторана
        if (await dataContext.Orders.AnyAsync(x =>
            x.IsnOrder != order.IsnOrder &&
            x.IsnRestaurant == order.IsnRestaurant &&
            x.OrderNumber == order.OrderNumber,
            cancellationToken))
            throw new BusinessLogicException("Заказ с таким номером уже существует в данном ресторане");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Order order,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.OrderItems.AnyAsync(x => x.IsnOrder == order.IsnOrder, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить заказ, так как в нем есть позиции");

        // Нельзя удалять завершенные заказы
        if (order.Status == "Completed" || order.Status == "Delivered")
            throw new BusinessLogicException("Невозможно удалить завершенный заказ");
    }

    public async Task<string> GenerateOrderNumberAsync(
        DataContext dataContext,
        Guid restaurantId,
        CancellationToken cancellationToken = default)
    {
        var today = DateTime.UtcNow.Date;
        var todayOrdersCount = await dataContext.Orders
            .CountAsync(x => x.IsnRestaurant == restaurantId && x.CreatedDate.Date == today, cancellationToken);

        return $"ORD-{DateTime.UtcNow:yyyyMMdd}-{(todayOrdersCount + 1):D4}";
    }
}
