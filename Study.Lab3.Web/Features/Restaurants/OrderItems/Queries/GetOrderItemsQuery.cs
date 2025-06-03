using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.OrderItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.OrderItems.Queries;

/// <summary>
/// Получение позиций заказа
/// </summary>
public sealed class GetOrderItemsQuery : IRequest<OrderItemDto[]>
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnOrder { get; init; }
}

public sealed class GetOrderItemsQueryHandler : IRequestHandler<GetOrderItemsQuery, OrderItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetOrderItemsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<OrderItemDto[]> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Orders.AnyAsync(x => x.IsnOrder == request.IsnOrder, cancellationToken))
            throw new BusinessLogicException($"Заказ с идентификатором \"{request.IsnOrder}\" не существует");

        return await _dataContext.OrderItems
            .AsNoTracking()
            .Where(x => x.IsnOrder == request.IsnOrder)
            .Select(x => new OrderItemDto
            {
                IsnOrderItem = x.IsnOrderItem,
                IsnOrder = x.IsnOrder,
                IsnMenuItem = x.IsnMenuItem,
                MenuItemName = x.MenuItem.Name,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                TotalPrice = x.TotalPrice,
                SpecialRequests = x.SpecialRequests
            })
            .ToArrayAsync(cancellationToken);
    }
}