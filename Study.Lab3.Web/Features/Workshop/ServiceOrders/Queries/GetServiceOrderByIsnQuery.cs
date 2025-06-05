using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.Queries;

/// <summary>
/// Получить заказ по идентификатору
/// </summary>
public sealed class GetServiceOrderByIsnQuery : IRequest<ServiceOrderDto>
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnServiceOrder { get; init; }
}

public sealed class GetServiceOrderByIsnQueryHandler : IRequestHandler<GetServiceOrderByIsnQuery, ServiceOrderDto>
{
    private readonly DataContext _dataContext;

    public GetServiceOrderByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceOrderDto> Handle(GetServiceOrderByIsnQuery request, CancellationToken cancellationToken)
    {
        var serviceOrder = await _dataContext.ServiceOrders
                               .AsNoTracking()
                               .FirstOrDefaultAsync(x => x.IsnServiceOrder == request.IsnServiceOrder, cancellationToken)
                           ?? throw new BusinessLogicException(
                               $"Заказ с идентификатором \"{request.IsnServiceOrder}\" не существует");

        return new ServiceOrderDto
        {
            IsnServiceOrder = serviceOrder.IsnServiceOrder,
            IsnMaster = serviceOrder.IsnMaster,
            IsnService = serviceOrder.IsnService,
            CustomerName = serviceOrder.CustomerName,
            CustomerPhone = serviceOrder.CustomerPhone,
            OrderDate = serviceOrder.OrderDate,
            Status = serviceOrder.Status,
            Description = serviceOrder.Description,
            TotalPrice = serviceOrder.TotalPrice
        };
    }
}
