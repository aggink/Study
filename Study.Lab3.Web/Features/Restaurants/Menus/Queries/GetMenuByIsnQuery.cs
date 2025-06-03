using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Menus.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Menus.Queries;

/// <summary>
/// Получение меню по идентификатору
/// </summary>
public sealed class GetMenuByIsnQuery : IRequest<MenuDto>
{
    /// <summary>
    /// Идентификатор меню
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMenu { get; init; }
}

public sealed class GetMenuByIsnQueryHandler : IRequestHandler<GetMenuByIsnQuery, MenuDto>
{
    private readonly DataContext _dataContext;

    public GetMenuByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MenuDto> Handle(GetMenuByIsnQuery request, CancellationToken cancellationToken)
    {
        var menu = await _dataContext.Menus
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.IsnMenu == request.IsnMenu, cancellationToken)
                   ?? throw new BusinessLogicException($"Меню с идентификатором \"{request.IsnMenu}\" не существует");

        return new MenuDto
        {
            IsnMenu = menu.IsnMenu,
            IsnRestaurant = menu.IsnRestaurant,
            Name = menu.Name,
            Description = menu.Description,
            IsActive = menu.IsActive,
            CreatedDate = menu.CreatedDate
        };
    }
}