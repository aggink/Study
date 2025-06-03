using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.Queries;

/// <summary>
/// Получение заказов ресторана
/// </summary>
public sealed class GetOrdersByRestaurantQuery : IRequest<OrderDto[]>
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnRestaurant { get; init; }

    /// <summary>
    /// Статус заказа (опционально)
    /// </summary>
    [FromQuery]
    public string Status { get; init; }
}

public sealed class GetOrdersByRestaurantQueryHandler : IRequestHandler<GetOrdersByRestaurantQuery, OrderDto[]>
{
    private readonly DataContext _dataContext;

    public GetOrdersByRestaurantQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<OrderDto[]> Handle(GetOrdersByRestaurantQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Restaurants.AnyAsync(x => x.IsnRestaurant == request.IsnRestaurant, cancellationToken))
            throw new BusinessLogicException($"Ресторан с идентификатором \"{request.IsnRestaurant}\" не существует");

        var query = _dataContext.RestaurantOrders
            .AsNoTracking()
            .Where(x => x.IsnRestaurant == request.IsnRestaurant);

        if (!string.IsNullOrEmpty(request.Status))
        {
            query = query.Where(x => x.Status == request.Status);
        }

        return await query
            .Select(x => new OrderDto
            {
                IsnOrder = x.IsnOrder,
                IsnRestaurant = x.IsnRestaurant,
                OrderNumber = x.OrderNumber,
                CustomerName = x.CustomerName,
                CustomerPhone = x.CustomerPhone,
                TableNumber = x.TableNumber,
                Status = x.Status,
                TotalAmount = x.TotalAmount,
                CreatedDate = x.CreatedDate,
                CompletedDate = x.CompletedDate
            })
            .OrderByDescending(x => x.CreatedDate)
            .ToArrayAsync(cancellationToken);
    }
}