using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.Commands;

/// <summary>
/// Обновление заказа
/// </summary>
public sealed class UpdateServiceOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные заказа
    /// </summary>
    [Required]
    [FromBody]
    public UpdateServiceOrderDto ServiceOrder { get; init; }
}

public sealed class UpdateServiceOrderCommandHandler : IRequestHandler<UpdateServiceOrderCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IServiceOrderService _serviceOrderService;

    public UpdateServiceOrderCommandHandler(
        DataContext dataContext,
        IServiceOrderService serviceOrderService)
    {
        _dataContext = dataContext;
        _serviceOrderService = serviceOrderService;
    }

    public async Task<Guid> Handle(UpdateServiceOrderCommand request, CancellationToken cancellationToken)
    {
        var serviceOrder = await _dataContext.ServiceOrders
                               .FirstOrDefaultAsync(x => x.IsnServiceOrder == request.ServiceOrder.IsnServiceOrder, cancellationToken)
                           ?? throw new BusinessLogicException(
                               $"Заказ с идентификатором \"{request.ServiceOrder.IsnServiceOrder}\" не существует");

        serviceOrder.Status = request.ServiceOrder.Status;
        serviceOrder.Description = request.ServiceOrder.Description;
        serviceOrder.TotalPrice = request.ServiceOrder.TotalPrice;

        await _serviceOrderService.CreateOrUpdateServiceOrderValidateAndThrowAsync(
            _dataContext, serviceOrder, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return serviceOrder.IsnServiceOrder;
    }
}
