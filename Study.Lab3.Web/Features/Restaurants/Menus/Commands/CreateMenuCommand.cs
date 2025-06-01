using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;
using Study.Lab3.Web.Features.Restaurants.Menus.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Menus.Commands;

/// <summary>
/// Создание меню
/// </summary>
public sealed class CreateMenuCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные меню
    /// </summary>
    [Required]
    [FromBody]
    public CreateMenuDto Menu { get; init; }
}

public sealed class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMenuService _menuService;

    public CreateMenuCommandHandler(
        DataContext dataContext,
        IMenuService menuService)
    {
        _dataContext = dataContext;
        _menuService = menuService;
    }

    public async Task<Guid> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = new Menu
        {
            IsnMenu = Guid.NewGuid(),
            IsnRestaurant = request.Menu.IsnRestaurant,
            Name = request.Menu.Name,
            Description = request.Menu.Description,
            IsActive = request.Menu.IsActive,
            CreatedDate = DateTime.UtcNow
        };

        await _menuService.CreateOrUpdateMenuValidateAndThrowAsync(
            _dataContext, menu, cancellationToken);

        await _dataContext.Menus.AddAsync(menu, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return menu.IsnMenu;
    }
}
