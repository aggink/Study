using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;
using Study.Lab3.Web.Features.Restaurants.MenuItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.MenuItems.Commands;

/// <summary>
/// Создание позиции меню
/// </summary>
public sealed class CreateMenuItemCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные позиции меню
    /// </summary>
    [Required]
    [FromBody]
    public CreateMenuItemDto MenuItem { get; init; }
}

public sealed class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMenuItemService _menuItemService;

    public CreateMenuItemCommandHandler(
        DataContext dataContext,
        IMenuItemService menuItemService)
    {
        _dataContext = dataContext;
        _menuItemService = menuItemService;
    }

    public async Task<Guid> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItem = new MenuItem
        {
            IsnMenuItem = Guid.NewGuid(),
            IsnMenu = request.MenuItem.IsnMenu,
            Name = request.MenuItem.Name,
            Description = request.MenuItem.Description,
            Price = request.MenuItem.Price,
            Category = request.MenuItem.Category,
            IsAvailable = request.MenuItem.IsAvailable,
            CookingTimeMinutes = request.MenuItem.CookingTimeMinutes
        };

        await _menuItemService.CreateOrUpdateMenuItemValidateAndThrowAsync(
            _dataContext, menuItem, cancellationToken);

        await _dataContext.MenuItems.AddAsync(menuItem, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return menuItem.IsnMenuItem;
    }
}