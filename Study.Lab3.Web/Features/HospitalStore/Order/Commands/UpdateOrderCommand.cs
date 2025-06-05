using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Order.Commands;

/// <summary>
/// Редактирование заказа
/// </summary>
public sealed class UpdateOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные заказа
    /// </summary>
    [Required]
    [FromBody]
    public UpdateHospitalStoreOrderDto Order { get; init; }
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
                ?? throw new BusinessLogicException($"Заказ с идентификатором \"{request.Order.IsnOrder}\" не найден");

        order.Quantity = request.Order.Quantity;

        await _orderService.CreateOrUpdateOrderValidateAndThrowAsync(
            _dataContext, order, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return order.IsnOrder;
    }
}
