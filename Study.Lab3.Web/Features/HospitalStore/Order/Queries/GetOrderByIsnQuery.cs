using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;

namespace Study.Lab3.Web.Features.HospitalStore.Order.Queries;

/// <summary>
/// Получение заказа по идентификатору
/// </summary>
public sealed class GetOrderByIsnQuery : IRequest<OrderDto?>
{
    public Guid IsnOrder { get; }

    public GetOrderByIsnQuery(Guid isnOrder)
    {
        IsnOrder = isnOrder;
    }
}

public sealed class GetOrderByIsnQueryHandler : IRequestHandler<GetOrderByIsnQuery, OrderDto?>
{
    private readonly DataContext _dataContext;

    public GetOrderByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<OrderDto?> Handle(GetOrderByIsnQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Orders
            .AsNoTracking()
            .Where(x => x.IsnOrder == request.IsnOrder)
            .Select(x => new OrderDto
            {
                IsnOrder = x.IsnOrder,
                IsnPatient = x.IsnPatient,
                IsnProduct = x.IsnProduct,
                Quantity = x.Quantity
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
