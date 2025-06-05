using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.Commands;

/// <summary>
/// Обновление статуса заказа
/// </summary>
public sealed class UpdateOrderStatusCommand : IRequest
{
    /// <summary>
    /// Данные для обновления статуса
    /// </summary>
    [Required]
    [FromBody]
    public UpdateOrderStatusDto OrderStatus { get; init; }
}

public sealed class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
{
    private readonly DataContext _dataContext;
    private readonly IRestaurantOrderService _restaurantOrderService;

    public UpdateOrderStatusCommandHandler(
        DataContext dataContext,
        IRestaurantOrderService restaurantOrderService)
    {
        _dataContext = dataContext;
        _restaurantOrderService = restaurantOrderService;
    }

    public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var order = await _dataContext.RestaurantOrders
                        .FirstOrDefaultAsync(x => x.IsnOrder == request.OrderStatus.IsnOrder, cancellationToken)
                    ?? throw new BusinessLogicException($"Заказ с идентификатором \"{request.OrderStatus.IsnOrder}\" не существует");

        order.Status = request.OrderStatus.Status;

        // Установка даты завершения при соответствующих статусах
        if (request.OrderStatus.Status == "Completed" || request.OrderStatus.Status == "Delivered")
        {
            if (!order.CompletedDate.HasValue)
            {
                order.CompletedDate = DateTime.UtcNow;
            }
        }

        await _restaurantOrderService.CreateOrUpdateOrderValidateAndThrowAsync(_dataContext, order, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}