using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Halls.DtoModels;

public sealed record UpdateHallDto
{
    /// <summary>
    /// Идентификатор зала
    /// </summary>
    [Required]
    public Guid IsnHall { get; init; }

    /// <summary>
    /// Название зала
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hall.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Тип зала
    /// </summary>
    [Required]
    public HallType Type { get; init; }

    /// <summary>
    /// Активен ли зал
    /// </summary>
    public bool IsActive { get; init; }
}