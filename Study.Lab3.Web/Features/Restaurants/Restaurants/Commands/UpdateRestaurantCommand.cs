using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Restaurants.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Restaurants.Commands;

/// <summary>
/// Редактирование ресторана
/// </summary>
public sealed class UpdateRestaurantCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные ресторана
    /// </summary>
    [Required]
    [FromBody]
    public UpdateRestaurantDto Restaurant { get; init; }
}

public sealed class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IRestaurantService _restaurantService;

    public UpdateRestaurantCommandHandler(
        DataContext dataContext,
        IRestaurantService restaurantService)
    {
        _dataContext = dataContext;
        _restaurantService = restaurantService;
    }

    public async Task<Guid> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _dataContext.Restaurants
                             .FirstOrDefaultAsync(x => x.IsnRestaurant == request.Restaurant.IsnRestaurant, cancellationToken)
                         ?? throw new BusinessLogicException($"Ресторан с идентификатором \"{request.Restaurant.IsnRestaurant}\" не существует");

        restaurant.Name = request.Restaurant.Name;
        restaurant.Address = request.Restaurant.Address;
        restaurant.Phone = request.Restaurant.Phone;
        restaurant.Email = request.Restaurant.Email;
        restaurant.WorkingHours = request.Restaurant.WorkingHours;

        await _restaurantService.CreateOrUpdateRestaurantValidateAndThrowAsync(
            _dataContext, restaurant, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return restaurant.IsnRestaurant;
    }
}