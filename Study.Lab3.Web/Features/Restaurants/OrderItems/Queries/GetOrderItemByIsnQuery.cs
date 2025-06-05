using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.OrderItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.OrderItems.Queries;

/// <summary>
/// Получение позиции заказа по идентификатору
/// </summary>
public sealed class GetOrderItemByIsnQuery : IRequest<OrderItemDto>
{
    /// <summary>
    /// Идентификатор позиции заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnOrderItem { get; init; }
}

public sealed class GetOrderItemByIsnQueryHandler : IRequestHandler<GetOrderItemByIsnQuery, OrderItemDto>
{
    private readonly DataContext _dataContext;

    public GetOrderItemByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<OrderItemDto> Handle(GetOrderItemByIsnQuery request, CancellationToken cancellationToken)
    {
        var orderItem = await _dataContext.OrderItems
                            .AsNoTracking()
                            .Include(x => x.MenuItem)
                            .FirstOrDefaultAsync(x => x.IsnOrderItem == request.IsnOrderItem, cancellationToken)
                        ?? throw new BusinessLogicException($"Позиция заказа с идентификатором \"{request.IsnOrderItem}\" не существует");

        return new OrderItemDto
        {
            IsnOrderItem = orderItem.IsnOrderItem,
            IsnOrder = orderItem.IsnOrder,
            IsnMenuItem = orderItem.IsnMenuItem,
            MenuItemName = orderItem.MenuItem?.Name ?? string.Empty,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
            TotalPrice = orderItem.TotalPrice,
            SpecialRequests = orderItem.SpecialRequests
        };
    }
}