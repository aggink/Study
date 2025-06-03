using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.MenuItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.MenuItems.Queries;

/// <summary>
/// Получение позиции меню по идентификатору
/// </summary>
public sealed class GetMenuItemByIsnQuery : IRequest<MenuItemDto>
{
    /// <summary>
    /// Идентификатор позиции меню
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMenuItem { get; init; }
}

public sealed class GetMenuItemByIsnQueryHandler : IRequestHandler<GetMenuItemByIsnQuery, MenuItemDto>
{
    private readonly DataContext _dataContext;

    public GetMenuItemByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MenuItemDto> Handle(GetMenuItemByIsnQuery request, CancellationToken cancellationToken)
    {
        var menuItem = await _dataContext.MenuItems
                           .AsNoTracking()
                           .FirstOrDefaultAsync(x => x.IsnMenuItem == request.IsnMenuItem, cancellationToken)
                       ?? throw new BusinessLogicException($"Позиция меню с идентификатором \"{request.IsnMenuItem}\" не существует");

        return new MenuItemDto
        {
            IsnMenuItem = menuItem.IsnMenuItem,
            IsnMenu = menuItem.IsnMenu,
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            Category = menuItem.Category,
            IsAvailable = menuItem.IsAvailable,
            CookingTimeMinutes = menuItem.CookingTimeMinutes
        };
    }
}