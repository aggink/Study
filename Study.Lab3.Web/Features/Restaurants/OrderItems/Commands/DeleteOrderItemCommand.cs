using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.OrderItems.Commands;

/// <summary>
/// Удаление позиции заказа
/// </summary>
public sealed class DeleteOrderItemCommand : IRequest
{
    /// <summary>
    /// Идентификатор позиции заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnOrderItem { get; init; }
}

public sealed class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
{
    private readonly DataContext _dataContext;
    private readonly IOrderItemService _orderItemService;

    public DeleteOrderItemCommandHandler(
        DataContext dataContext,
        IOrderItemService orderItemService)
    {
        _dataContext = dataContext;
        _orderItemService = orderItemService;
    }

    public async Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = await _dataContext.OrderItems
                            .Include(x => x.RestaurantOrder)
                            .FirstOrDefaultAsync(x => x.IsnOrderItem == request.IsnOrderItem, cancellationToken)
                        ?? throw new BusinessLogicException($"Позиция заказа с идентификатором \"{request.IsnOrderItem}\" не существует");

        await _orderItemService.CanDeleteAndThrowAsync(_dataContext, orderItem, cancellationToken);

        // Обновляем общую сумму заказа
        if (orderItem.RestaurantOrder != null)
        {
            orderItem.RestaurantOrder.TotalAmount -= orderItem.TotalPrice;
        }

        _dataContext.OrderItems.Remove(orderItem);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}