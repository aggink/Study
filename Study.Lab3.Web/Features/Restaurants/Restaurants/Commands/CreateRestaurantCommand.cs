using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;
using Study.Lab3.Web.Features.Restaurants.Restaurants.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Restaurants.Commands;

/// <summary>
/// Создание ресторана
/// </summary>
public sealed class CreateRestaurantCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные ресторана
    /// </summary>
    [Required]
    [FromBody]
    public CreateRestaurantDto Restaurant { get; init; }
}

public sealed class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IRestaurantService _restaurantService;

    public CreateRestaurantCommandHandler(
        DataContext dataContext,
        IRestaurantService restaurantService)
    {
        _dataContext = dataContext;
        _restaurantService = restaurantService;
    }

    public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = new Restaurant
        {
            IsnRestaurant = Guid.NewGuid(),
            Name = request.Restaurant.Name,
            Address = request.Restaurant.Address,
            Phone = request.Restaurant.Phone,
            Email = request.Restaurant.Email,
            WorkingHours = request.Restaurant.WorkingHours,
            CreatedDate = DateTime.UtcNow
        };

        await _restaurantService.CreateOrUpdateRestaurantValidateAndThrowAsync(
            _dataContext, restaurant, cancellationToken);

        await _dataContext.Restaurants.AddAsync(restaurant, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return restaurant.IsnRestaurant;
    }
}
