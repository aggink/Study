using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Halls.DtoModels;

public sealed record CreateHallDto
{
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
    /// Количество рядов
    /// </summary>
    [Required]
    [Range(ModelConstants.Hall.MinRows, ModelConstants.Hall.MaxRows)]
    public int RowsCount { get; init; }

    /// <summary>
    /// Количество мест в ряду
    /// </summary>
    [Required]
    [Range(ModelConstants.Hall.MinSeatsPerRow, ModelConstants.Hall.MaxSeatsPerRow)]
    public int SeatsPerRow { get; init; }
}