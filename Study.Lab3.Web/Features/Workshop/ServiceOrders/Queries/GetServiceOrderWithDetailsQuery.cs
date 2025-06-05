using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.Queries;

/// <summary>
/// Получить заказ с детальной информацией
/// </summary>
public sealed class GetServiceOrderWithDetailsQuery : IRequest<ServiceOrderWithDetailsDto>
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnServiceOrder { get; init; }
}

public sealed class GetServiceOrderWithDetailsQueryHandler : IRequestHandler<GetServiceOrderWithDetailsQuery, ServiceOrderWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetServiceOrderWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceOrderWithDetailsDto> Handle(GetServiceOrderWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.ServiceOrders
                   .AsNoTracking()
                   .Where(x => x.IsnServiceOrder == request.IsnServiceOrder)
                   .Select(x => new ServiceOrderWithDetailsDto
                   {
                       IsnServiceOrder = x.IsnServiceOrder,
                       IsnMaster = x.IsnMaster,
                       MasterName = x.Master.Name,
                       MasterSpecialization = x.Master.Specialization,
                       IsnService = x.IsnService,
                       ServiceName = x.Service.Name,
                       ServicePrice = x.Service.Price,
                       CustomerName = x.CustomerName,
                       CustomerPhone = x.CustomerPhone,
                       OrderDate = x.OrderDate,
                       Status = x.Status,
                       Description = x.Description,
                       TotalPrice = x.TotalPrice
                   })
                   .FirstOrDefaultAsync(cancellationToken)
               ?? throw new BusinessLogicException(
                   $"Заказ с идентификатором \"{request.IsnServiceOrder}\" не существует");
    }
}
