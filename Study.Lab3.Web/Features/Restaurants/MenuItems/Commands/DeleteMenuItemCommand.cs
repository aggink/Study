using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.MenuItems.Commands;

/// <summary>
/// Удаление позиции меню
/// </summary>
public sealed class DeleteMenuItemCommand : IRequest
{
    /// <summary>
    /// Идентификатор позиции меню
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMenuItem { get; init; }
}

public sealed class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMenuItemService _menuItemService;

    public DeleteMenuItemCommandHandler(
        DataContext dataContext,
        IMenuItemService menuItemService)
    {
        _dataContext = dataContext;
        _menuItemService = menuItemService;
    }

    public async Task Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItem = await _dataContext.MenuItems
                           .FirstOrDefaultAsync(x => x.IsnMenuItem == request.IsnMenuItem, cancellationToken)
                       ?? throw new BusinessLogicException($"Позиция меню с идентификатором \"{request.IsnMenuItem}\" не существует");

        await _menuItemService.CanDeleteAndThrowAsync(_dataContext, menuItem, cancellationToken);

        _dataContext.MenuItems.Remove(menuItem);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}