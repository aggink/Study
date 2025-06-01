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
/// Обновление заказа
/// </summary>
public sealed class UpdateOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные заказа
    /// </summary>
    [Required]
    [FromBody]
    public UpdateOrderDto Order { get; init; }
}

public sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IOrderService _orderService;

    public UpdateOrderCommandHandler(
        DataContext dataContext,
        IOrderService orderService)
    {
        _dataContext = dataContext;
        _orderService = orderService;
    }

    public async Task<Guid> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _dataContext.Orders
                        .FirstOrDefaultAsync(x => x.IsnOrder == request.Order.IsnOrder, cancellationToken)
                    ?? throw new BusinessLogicException($"Заказ с идентификатором \"{request.Order.IsnOrder}\" не существует");

        order.CustomerName = request.Order.CustomerName;
        order.CustomerPhone = request.Order.CustomerPhone;
        order.TableNumber = request.Order.TableNumber;
        order.Status = request.Order.Status;

        if (request.Order.Status == "Completed" || request.Order.Status == "Delivered")
        {
            order.CompletedDate = DateTime.UtcNow;
        }

        await _orderService.CreateOrUpdateOrderValidateAndThrowAsync(_dataContext, order, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return order.IsnOrder;
    }
}