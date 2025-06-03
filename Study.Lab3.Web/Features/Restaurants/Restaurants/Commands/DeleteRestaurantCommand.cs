using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Restaurants.Commands;

/// <summary>
/// Удаление ресторана
/// </summary>
public sealed class DeleteRestaurantCommand : IRequest
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnRestaurant { get; init; }
}

public sealed class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand>
{
    private readonly DataContext _dataContext;
    private readonly IRestaurantService _restaurantService;

    public DeleteRestaurantCommandHandler(
        DataContext dataContext,
        IRestaurantService restaurantService)
    {
        _dataContext = dataContext;
        _restaurantService = restaurantService;
    }

    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _dataContext.Restaurants
                             .FirstOrDefaultAsync(x => x.IsnRestaurant == request.IsnRestaurant, cancellationToken)
                         ?? throw new BusinessLogicException($"Ресторан с идентификатором \"{request.IsnRestaurant}\" не существует");

        await _restaurantService.CanDeleteAndThrowAsync(_dataContext, restaurant, cancellationToken);

        _dataContext.Restaurants.Remove(restaurant);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
