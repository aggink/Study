using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Workshop;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.Commands;

/// <summary>
/// Создание заказа
/// </summary>
public sealed class CreateServiceOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные заказа
    /// </summary>
    [Required]
    [FromBody]
    public CreateServiceOrderDto ServiceOrder { get; init; }
}

public sealed class CreateServiceOrderCommandHandler : IRequestHandler<CreateServiceOrderCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IServiceOrderService _serviceOrderService;

    public CreateServiceOrderCommandHandler(
        DataContext dataContext,
        IServiceOrderService serviceOrderService)
    {
        _dataContext = dataContext;
        _serviceOrderService = serviceOrderService;
    }

    public async Task<Guid> Handle(CreateServiceOrderCommand request, CancellationToken cancellationToken)
    {
        var serviceOrder = new ServiceOrder
        {
            IsnServiceOrder = Guid.NewGuid(),
            IsnMaster = request.ServiceOrder.IsnMaster,
            IsnService = request.ServiceOrder.IsnService,
            CustomerName = request.ServiceOrder.CustomerName,
            CustomerPhone = request.ServiceOrder.CustomerPhone,
            OrderDate = request.ServiceOrder.OrderDate,
            Status = request.ServiceOrder.Status,
            Description = request.ServiceOrder.Description,
            TotalPrice = request.ServiceOrder.TotalPrice
        };

        await _serviceOrderService.CreateOrUpdateServiceOrderValidateAndThrowAsync(
            _dataContext, serviceOrder, cancellationToken);

        await _dataContext.ServiceOrders.AddAsync(serviceOrder, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return serviceOrder.IsnServiceOrder;
    }
}
