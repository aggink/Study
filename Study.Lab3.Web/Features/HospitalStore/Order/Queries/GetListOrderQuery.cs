using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;

namespace Study.Lab3.Web.Features.HospitalStore.Order.Queries;

/// <summary>
/// Получение списка заказов
/// </summary>
public sealed class GetListOrderQuery : IRequest<OrderDto[]>
{
}

public sealed class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, OrderDto[]>
{
    private readonly DataContext _dataContext;

    public GetListOrderQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<OrderDto[]> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Orders
            .AsNoTracking()
            .Select(x => new OrderDto
            {
                IsnOrder = x.IsnOrder,
                IsnPatient = x.IsnPatient,
                IsnProduct = x.IsnProduct,
                Quantity = x.Quantity
            })
            .OrderByDescending(x => x.IsnOrder) // или .OrderByDescending(x => x.CreatedAt), если есть
            .ToArrayAsync(cancellationToken);
    }
}
