using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.Commands;

/// <summary>
/// Удаление заказа
/// </summary>
public sealed class DeleteServiceOrderCommand : IRequest
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnServiceOrder { get; init; }
}

public sealed class DeleteServiceOrderCommandHandler : IRequestHandler<DeleteServiceOrderCommand>
{
    private readonly DataContext _dataContext;
    private readonly IServiceOrderService _serviceOrderService;

    public DeleteServiceOrderCommandHandler(
        DataContext dataContext,
        IServiceOrderService serviceOrderService)
    {
        _dataContext = dataContext;
        _serviceOrderService = serviceOrderService;
    }

    public async Task Handle(DeleteServiceOrderCommand request, CancellationToken cancellationToken)
    {
        var serviceOrder = await _dataContext.ServiceOrders
                               .FirstOrDefaultAsync(x => x.IsnServiceOrder == request.IsnServiceOrder, cancellationToken)
                           ?? throw new BusinessLogicException(
                               $"Заказ с идентификатором \"{request.IsnServiceOrder}\" не существует");

        await _serviceOrderService.CanDeleteAndThrowAsync(_dataContext, serviceOrder, cancellationToken);

        _dataContext.ServiceOrders.Remove(serviceOrder);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
