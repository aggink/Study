using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.Queries;

/// <summary>
/// Получение заказов мастера
/// </summary>
public sealed class GetServiceOrdersByMasterQuery : IRequest<ServiceOrderWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMaster { get; init; }
}

public sealed class GetServiceOrdersByMasterQueryHandler : IRequestHandler<GetServiceOrdersByMasterQuery, ServiceOrderWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetServiceOrdersByMasterQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceOrderWithDetailsDto[]> Handle(GetServiceOrdersByMasterQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Masters.AnyAsync(x => x.IsnMaster == request.IsnMaster, cancellationToken))
            throw new BusinessLogicException($"Мастер с идентификатором \"{request.IsnMaster}\" не существует");

        return await _dataContext.ServiceOrders
            .AsNoTracking()
            .Where(x => x.IsnMaster == request.IsnMaster)
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
            .OrderByDescending(x => x.OrderDate)
            .ToArrayAsync(cancellationToken);
    }
}
