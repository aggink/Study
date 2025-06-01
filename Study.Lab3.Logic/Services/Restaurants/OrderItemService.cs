using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Services.Restaurants;

public sealed class OrderItemService : IOrderItemService
{
    public async Task CreateOrUpdateOrderItemValidateAndThrowAsync(
        DataContext dataContext,
        OrderItem orderItem,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Orders.AnyAsync(x => x.IsnOrder == orderItem.IsnOrder, cancellationToken))
            throw new BusinessLogicException($"Заказ с идентификатором \"{orderItem.IsnOrder}\" не существует");

        if (!await dataContext.MenuItems.AnyAsync(x => x.IsnMenuItem == orderItem.IsnMenuItem, cancellationToken))
            throw new BusinessLogicException($"Позиция меню с идентификатором \"{orderItem.IsnMenuItem}\" не существует");

        if (orderItem.Quantity < ModelConstants.OrderItem.MinQuantity || orderItem.Quantity > ModelConstants.OrderItem.MaxQuantity)
            throw new BusinessLogicException($"Количество должно быть от {ModelConstants.OrderItem.MinQuantity} до {ModelConstants.OrderItem.MaxQuantity}");

        if (orderItem.UnitPrice <= 0)
            throw new BusinessLogicException("Цена за единицу должна быть положительной");

        if (!string.IsNullOrEmpty(orderItem.SpecialRequests) && orderItem.SpecialRequests.Length > ModelConstants.OrderItem.SpecialRequests)
            throw new BusinessLogicException($"Особые пожелания не могут превышать {ModelConstants.OrderItem.SpecialRequests} символов");

        // Автоматический расчет общей стоимости
        orderItem.TotalPrice = CalculateTotalPrice(orderItem.Quantity, orderItem.UnitPrice);

        // Проверка, что блюдо доступно
        var menuItem = await dataContext.MenuItems.FirstOrDefaultAsync(x => x.IsnMenuItem == orderItem.IsnMenuItem, cancellationToken);
        if (menuItem != null && !menuItem.IsAvailable)
            throw new BusinessLogicException("Выбранное блюдо недоступно");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        OrderItem orderItem,
        CancellationToken cancellationToken = default)
    {
        var order = await dataContext.Orders.FirstOrDefaultAsync(x => x.IsnOrder == orderItem.IsnOrder, cancellationToken);
        if (order != null && (order.Status == "Completed" || order.Status == "Delivered"))
            throw new BusinessLogicException("Невозможно удалить позицию из завершенного заказа");
    }

    public double CalculateTotalPrice(int quantity, double unitPrice)
    {
        return quantity * unitPrice;
    }
}
