using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.MenuItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.MenuItems.Queries;

/// <summary>
/// Получение позиций меню
/// </summary>
public sealed class GetMenuItemsQuery : IRequest<MenuItemDto[]>
{
    /// <summary>
    /// Идентификатор меню
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMenu { get; init; }
}

public sealed class GetMenuItemsQueryHandler : IRequestHandler<GetMenuItemsQuery, MenuItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetMenuItemsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MenuItemDto[]> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Menus.AnyAsync(x => x.IsnMenu == request.IsnMenu, cancellationToken))
            throw new BusinessLogicException($"Меню с идентификатором \"{request.IsnMenu}\" не существует");

        return await _dataContext.MenuItems
            .AsNoTracking()
            .Where(x => x.IsnMenu == request.IsnMenu)
            .Select(x => new MenuItemDto
            {
                IsnMenuItem = x.IsnMenuItem,
                IsnMenu = x.IsnMenu,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Category = x.Category,
                IsAvailable = x.IsAvailable,
                CookingTimeMinutes = x.CookingTimeMinutes
            })
            .OrderBy(x => x.Category)
            .ThenBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}