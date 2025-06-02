using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Order.Commands;

/// <summary>
/// Создание заказа
/// </summary>
public sealed class CreateOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные заказа
    /// </summary>
    [Required]
    [FromBody]
    public CreateOrderDto Order { get; init; }
}

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IOrderService _orderService;

    public CreateOrderCommandHandler(
        DataContext dataContext,
        IOrderService orderService)
    {
        _dataContext = dataContext;
        _orderService = orderService;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Storage.Models.HospitalStore.Order
        {
            IsnOrder = Guid.NewGuid(),
            IsnPatient = request.Order.IsnPatient,
            IsnProduct = request.Order.IsnProduct,
            Quantity = request.Order.Quantity
        };

        await _orderService.CreateOrUpdateOrderValidateAndThrowAsync(
            _dataContext, order, cancellationToken);

        await _dataContext.Orders.AddAsync(order, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return order.IsnOrder;
    }
}
