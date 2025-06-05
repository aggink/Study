using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.Queries;

/// <summary>
/// Получение списка заказов
/// </summary>
public sealed class GetListServiceOrdersQuery : IRequest<ServiceOrderDto[]>
{
}

public sealed class GetListServiceOrdersQueryHandler : IRequestHandler<GetListServiceOrdersQuery, ServiceOrderDto[]>
{
    private readonly DataContext _dataContext;

    public GetListServiceOrdersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceOrderDto[]> Handle(GetListServiceOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.ServiceOrders
            .AsNoTracking()
            .Select(x => new ServiceOrderDto
            {
                IsnServiceOrder = x.IsnServiceOrder,
                IsnMaster = x.IsnMaster,
                IsnService = x.IsnService,
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
