using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Restaurants.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Restaurants.Queries;

/// <summary>
/// Получение ресторана по идентификатору
/// </summary>
public sealed class GetRestaurantByIsnQuery : IRequest<RestaurantDto>
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnRestaurant { get; init; }
}

public sealed class GetRestaurantByIsnQueryHandler : IRequestHandler<GetRestaurantByIsnQuery, RestaurantDto>
{
    private readonly DataContext _dataContext;

    public GetRestaurantByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<RestaurantDto> Handle(GetRestaurantByIsnQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _dataContext.Restaurants
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.IsnRestaurant == request.IsnRestaurant, cancellationToken)
                         ?? throw new BusinessLogicException($"Ресторан с идентификатором \"{request.IsnRestaurant}\" не существует");

        return new RestaurantDto
        {
            IsnRestaurant = restaurant.IsnRestaurant,
            Name = restaurant.Name,
            Address = restaurant.Address,
            Phone = restaurant.Phone,
            Email = restaurant.Email,
            WorkingHours = restaurant.WorkingHours,
            CreatedDate = restaurant.CreatedDate
        };
    }
}