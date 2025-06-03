using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.OrderItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.OrderItems.Commands;

/// <summary>
/// Обновление позиции заказа
/// </summary>
public sealed class UpdateOrderItemCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные позиции заказа
    /// </summary>
    [Required]
    [FromBody]
    public UpdateOrderItemDto OrderItem { get; init; }
}

public sealed class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IOrderItemService _orderItemService;

    public UpdateOrderItemCommandHandler(
        DataContext dataContext,
        IOrderItemService orderItemService)
    {
        _dataContext = dataContext;
        _orderItemService = orderItemService;
    }

    public async Task<Guid> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = await _dataContext.OrderItems
                            .Include(x => x.RestaurantOrder)
                            .FirstOrDefaultAsync(x => x.IsnOrderItem == request.OrderItem.IsnOrderItem, cancellationToken)
                        ?? throw new BusinessLogicException($"Позиция заказа с идентификатором \"{request.OrderItem.IsnOrderItem}\" не существует");

        var oldTotalPrice = orderItem.TotalPrice;
        
        orderItem.Quantity = request.OrderItem.Quantity;
        orderItem.SpecialRequests = request.OrderItem.SpecialRequests;

        await _orderItemService.CreateOrUpdateOrderItemValidateAndThrowAsync(
            _dataContext, orderItem, cancellationToken);

        // Обновляем общую сумму заказа
        if (orderItem.RestaurantOrder != null)
        {
            orderItem.RestaurantOrder.TotalAmount = orderItem.RestaurantOrder.TotalAmount - oldTotalPrice + orderItem.TotalPrice;
        }

        await _dataContext.SaveChangesAsync(cancellationToken);
        return orderItem.IsnOrderItem;
    }
}