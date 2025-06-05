using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Menus.Commands;

/// <summary>
/// Удаление меню
/// </summary>
public sealed class DeleteMenuCommand : IRequest
{
    /// <summary>
    /// Идентификатор меню
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMenu { get; init; }
}

public sealed class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMenuService _menuService;

    public DeleteMenuCommandHandler(
        DataContext dataContext,
        IMenuService menuService)
    {
        _dataContext = dataContext;
        _menuService = menuService;
    }

    public async Task Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = await _dataContext.Menus
                       .FirstOrDefaultAsync(x => x.IsnMenu == request.IsnMenu, cancellationToken)
                   ?? throw new BusinessLogicException($"Меню с идентификатором \"{request.IsnMenu}\" не существует");

        await _menuService.CanDeleteAndThrowAsync(_dataContext, menu, cancellationToken);

        _dataContext.Menus.Remove(menu);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}