using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Order.Commands;

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
    private readonly IOrderService _orderService;

    public DeleteOrderCommandHandler(
        DataContext dataContext,
        IOrderService orderService)
    {
        _dataContext = dataContext;
        _orderService = orderService;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _dataContext.Orders
            .FirstOrDefaultAsync(x => x.IsnOrder == request.IsnOrder, cancellationToken)
                ?? throw new BusinessLogicException($"Заказ с идентификатором \"{request.IsnOrder}\" не существует");

        await _orderService.CanDeleteAndThrowAsync(
            _dataContext, order, cancellationToken);

        _dataContext.Orders.Remove(order);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
