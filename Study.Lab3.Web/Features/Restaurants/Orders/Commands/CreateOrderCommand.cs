using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;
using Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.Commands;

/// <summary>
/// Создание заказа
/// </summary>
public sealed class CreateOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные заказа
    /// </summary>
    [Required]
    [FromBody]
    public CreateRestaurantOrderDto Order { get; init; }
}

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IRestaurantOrderService _restaurantOrderService;
    private readonly IOrderItemService _orderItemService;

    public CreateOrderCommandHandler(
        DataContext dataContext,
        IRestaurantOrderService restaurantOrderService,
        IOrderItemService orderItemService)
    {
        _dataContext = dataContext;
        _restaurantOrderService = restaurantOrderService;
        _orderItemService = orderItemService;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderNumber = await _restaurantOrderService.GenerateOrderNumberAsync(
            _dataContext, request.Order.IsnRestaurant, cancellationToken);

        var order = new RestaurantOrder
        {
            IsnOrder = Guid.NewGuid(),
            IsnRestaurant = request.Order.IsnRestaurant,
            OrderNumber = orderNumber,
            CustomerName = request.Order.CustomerName,
            CustomerPhone = request.Order.CustomerPhone,
            TableNumber = request.Order.TableNumber,
            Status = "New",
            TotalAmount = 0,
            CreatedDate = DateTime.UtcNow
        };

        await _restaurantOrderService.CreateOrUpdateOrderValidateAndThrowAsync(
            _dataContext, order, cancellationToken);

        await _dataContext.RestaurantOrders.AddAsync(order, cancellationToken);

        // СОХРАНЯЕМ ЗАКАЗ СНАЧАЛА
        await _dataContext.SaveChangesAsync(cancellationToken);

        // Теперь добавляем позиции заказа
        double totalAmount = 0;
        foreach (var itemDto in request.Order.OrderItems)
        {
            var menuItem = await _dataContext.MenuItems
                .FirstOrDefaultAsync(x => x.IsnMenuItem == itemDto.IsnMenuItem, cancellationToken);

            if (menuItem == null) continue;

            var orderItem = new OrderItem
            {
                IsnOrderItem = Guid.NewGuid(),
                IsnOrder = order.IsnOrder, // Теперь заказ уже существует в БД
                IsnMenuItem = itemDto.IsnMenuItem,
                Quantity = itemDto.Quantity,
                UnitPrice = menuItem.Price,
                SpecialRequests = itemDto.SpecialRequests
            };

            await _orderItemService.CreateOrUpdateOrderItemValidateAndThrowAsync(
                _dataContext, orderItem, cancellationToken);

            await _dataContext.OrderItems.AddAsync(orderItem, cancellationToken);
            totalAmount += orderItem.TotalPrice;
        }

        // Обновляем общую сумму и сохраняем позиции
        order.TotalAmount = totalAmount;
        await _dataContext.SaveChangesAsync(cancellationToken);

        return order.IsnOrder;
    }
}