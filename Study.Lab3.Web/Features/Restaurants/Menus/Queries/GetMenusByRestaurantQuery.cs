using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Menus.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Menus.Queries;

/// <summary>
/// Получение меню по ресторану
/// </summary>
public sealed class GetMenusByRestaurantQuery : IRequest<MenuDto[]>
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnRestaurant { get; init; }
}

public sealed class GetMenusByRestaurantQueryHandler : IRequestHandler<GetMenusByRestaurantQuery, MenuDto[]>
{
    private readonly DataContext _dataContext;

    public GetMenusByRestaurantQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MenuDto[]> Handle(GetMenusByRestaurantQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Restaurants.AnyAsync(x => x.IsnRestaurant == request.IsnRestaurant, cancellationToken))
            throw new BusinessLogicException($"Ресторан с идентификатором \"{request.IsnRestaurant}\" не существует");

        return await _dataContext.Menus
            .AsNoTracking()
            .Where(x => x.IsnRestaurant == request.IsnRestaurant)
            .Select(x => new MenuDto
            {
                IsnMenu = x.IsnMenu,
                IsnRestaurant = x.IsnRestaurant,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}