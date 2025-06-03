using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Menus.DtoModels;

public sealed record UpdateMenuDto
{
    /// <summary>
    /// Идентификатор меню
    /// </summary>
    [Required]
    public Guid IsnMenu { get; init; }

    /// <summary>
    /// Название меню
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Menu.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Описание
    /// </summary>
    [MaxLength(ModelConstants.Menu.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Активность меню
    /// </summary>
    public bool IsActive { get; init; }
}