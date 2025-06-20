using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

public sealed record CreateMuseumExhibitDto
{
    /// <summary>
    /// Название экспоната
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumExhibit.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Описание экспоната
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibit.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Дата приобретения
    /// </summary>
    [Required]
    public DateTime AcquisitionDate { get; init; }

    /// <summary>
    /// Оценочная стоимость
    /// </summary>
    [Required]
    [Range(ModelConstants.MuseumExhibit.MinEstimatedValue, ModelConstants.MuseumExhibit.MaxEstimatedValue)]
    public double EstimatedValue { get; init; }

    /// <summary>
    /// Местоположение в музее
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumExhibit.Location)]
    public string Location { get; init; }

    /// <summary>
    /// Статус экспоната
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumExhibit.Status)]
    public string Status { get; init; } = "В хранилище";
}
