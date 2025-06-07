using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.MenuItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.MenuItems.Commands;

/// <summary>
/// Обновление позиции меню
/// </summary>
public sealed class UpdateMenuItemCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные позиции меню
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMenuItemDto MenuItem { get; init; }
}

public sealed class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMenuItemService _menuItemService;

    public UpdateMenuItemCommandHandler(
        DataContext dataContext,
        IMenuItemService menuItemService)
    {
        _dataContext = dataContext;
        _menuItemService = menuItemService;
    }

    public async Task<Guid> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItem = await _dataContext.MenuItems
                           .FirstOrDefaultAsync(x => x.IsnMenuItem == request.MenuItem.IsnMenuItem, cancellationToken)
                       ?? throw new BusinessLogicException($"Позиция меню с идентификатором \"{request.MenuItem.IsnMenuItem}\" не существует");

        menuItem.Name = request.MenuItem.Name;
        menuItem.Description = request.MenuItem.Description;
        menuItem.Price = request.MenuItem.Price;
        menuItem.Category = request.MenuItem.Category;
        menuItem.IsAvailable = request.MenuItem.IsAvailable;
        menuItem.CookingTimeMinutes = request.MenuItem.CookingTimeMinutes;

        await _menuItemService.CreateOrUpdateMenuItemValidateAndThrowAsync(
            _dataContext, menuItem, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return menuItem.IsnMenuItem;
    }
}