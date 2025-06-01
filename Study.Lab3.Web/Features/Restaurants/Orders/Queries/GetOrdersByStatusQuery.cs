using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.Queries;

/// <summary>
/// Получение заказов по статусу
/// </summary>
public sealed class GetOrdersByStatusQuery : IRequest<OrderDto[]>
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnRestaurant { get; init; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    [Required]
    [FromQuery]
    public string Status { get; init; }
}

public sealed class GetOrdersByStatusQueryHandler : IRequestHandler<GetOrdersByStatusQuery, OrderDto[]>
{
    private readonly DataContext _dataContext;

    public GetOrdersByStatusQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<OrderDto[]> Handle(GetOrdersByStatusQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Restaurants.AnyAsync(x => x.IsnRestaurant == request.IsnRestaurant, cancellationToken))
            throw new BusinessLogicException($"Ресторан с идентификатором \"{request.IsnRestaurant}\" не существует");

        return await _dataContext.Orders
            .AsNoTracking()
            .Where(x => x.IsnRestaurant == request.IsnRestaurant && x.Status == request.Status)
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