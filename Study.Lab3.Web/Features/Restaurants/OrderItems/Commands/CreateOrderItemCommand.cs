using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;
using Study.Lab3.Web.Features.Restaurants.OrderItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.OrderItems.Commands;

/// <summary>
/// Создание позиции заказа
/// </summary>
public sealed class CreateOrderItemCommand : IRequest<Guid>
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnOrder { get; init; }

    /// <summary>
    /// Данные позиции заказа
    /// </summary>
    [Required]
    [FromBody]
    public CreateOrderItemDto OrderItem { get; init; }
}

public sealed class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IOrderItemService _orderItemService;

    public CreateOrderItemCommandHandler(
        DataContext dataContext,
        IOrderItemService orderItemService)
    {
        _dataContext = dataContext;
        _orderItemService = orderItemService;
    }

    public async Task<Guid> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        // Получаем информацию о блюде для установки цены
        var menuItem = await _dataContext.MenuItems
                           .FirstOrDefaultAsync(x => x.IsnMenuItem == request.OrderItem.IsnMenuItem, cancellationToken)
                       ?? throw new BusinessLogicException($"Позиция меню с идентификатором \"{request.OrderItem.IsnMenuItem}\" не существует");

        var orderItem = new OrderItem
        {
            IsnOrderItem = Guid.NewGuid(),
            IsnOrder = request.IsnOrder,
            IsnMenuItem = request.OrderItem.IsnMenuItem,
            Quantity = request.OrderItem.Quantity,
            UnitPrice = menuItem.Price,
            SpecialRequests = request.OrderItem.SpecialRequests
        };

        await _orderItemService.CreateOrUpdateOrderItemValidateAndThrowAsync(
            _dataContext, orderItem, cancellationToken);

        await _dataContext.OrderItems.AddAsync(orderItem, cancellationToken);

        // Обновляем общую сумму заказа
        var order = await _dataContext.RestaurantOrders.FirstOrDefaultAsync(x => x.IsnOrder == request.IsnOrder, cancellationToken);
        if (order != null)
        {
            order.TotalAmount += orderItem.TotalPrice;
        }

        await _dataContext.SaveChangesAsync(cancellationToken);

        return orderItem.IsnOrderItem;
    }
}