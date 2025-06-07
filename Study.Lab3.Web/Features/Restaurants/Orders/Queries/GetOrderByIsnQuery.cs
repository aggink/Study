using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.Queries;

/// <summary>
/// Получение заказа по идентификатору
/// </summary>
public sealed class GetOrderByIsnQuery : IRequest<RestaurantOrderDto>
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnOrder { get; init; }
}

public sealed class GetOrderByIsnQueryHandler : IRequestHandler<GetOrderByIsnQuery, RestaurantOrderDto>
{
    private readonly DataContext _dataContext;

    public GetOrderByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<RestaurantOrderDto> Handle(GetOrderByIsnQuery request, CancellationToken cancellationToken)
    {
        var order = await _dataContext.RestaurantOrders
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.IsnOrder == request.IsnOrder, cancellationToken)
                    ?? throw new BusinessLogicException($"Заказ с идентификатором \"{request.IsnOrder}\" не существует");

        return new RestaurantOrderDto
        {
            IsnOrder = order.IsnOrder,
            IsnRestaurant = order.IsnRestaurant,
            OrderNumber = order.OrderNumber,
            CustomerName = order.CustomerName,
            CustomerPhone = order.CustomerPhone,
            TableNumber = order.TableNumber,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            CreatedDate = order.CreatedDate,
            CompletedDate = order.CompletedDate
        };
    }
}