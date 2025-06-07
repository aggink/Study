using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Menus.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Menus.Commands;

/// <summary>
/// Обновление меню
/// </summary>
public sealed class UpdateMenuCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные меню
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMenuDto Menu { get; init; }
}

public sealed class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMenuService _menuService;

    public UpdateMenuCommandHandler(
        DataContext dataContext,
        IMenuService menuService)
    {
        _dataContext = dataContext;
        _menuService = menuService;
    }

    public async Task<Guid> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = await _dataContext.Menus
                       .FirstOrDefaultAsync(x => x.IsnMenu == request.Menu.IsnMenu, cancellationToken)
                   ?? throw new BusinessLogicException($"Меню с идентификатором \"{request.Menu.IsnMenu}\" не существует");

        menu.Name = request.Menu.Name;
        menu.Description = request.Menu.Description;
        menu.IsActive = request.Menu.IsActive;

        await _menuService.CreateOrUpdateMenuValidateAndThrowAsync(_dataContext, menu, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return menu.IsnMenu;
    }
}