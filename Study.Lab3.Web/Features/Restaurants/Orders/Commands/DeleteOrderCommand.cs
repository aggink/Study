using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.Commands;

/// <summary>
/// Удаление заказа
/// </summary>
public sealed class DeleteOrderCommand : IRequest
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnOrder { get; init; }
}

public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly DataContext _dataContext;
    private readonly IRestaurantOrderService _restaurantOrderService;

    public DeleteOrderCommandHandler(
        DataContext dataContext,
        IRestaurantOrderService restaurantOrderService)
    {
        _dataContext = dataContext;
        _restaurantOrderService = restaurantOrderService;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _dataContext.RestaurantOrders
                        .Include(x => x.OrderItems)
                        .FirstOrDefaultAsync(x => x.IsnOrder == request.IsnOrder, cancellationToken)
                    ?? throw new BusinessLogicException($"Заказ с идентификатором \"{request.IsnOrder}\" не существует");

        await _restaurantOrderService.CanDeleteAndThrowAsync(_dataContext, order, cancellationToken);

        _dataContext.OrderItems.RemoveRange(order.OrderItems);
        _dataContext.RestaurantOrders.Remove(order);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}