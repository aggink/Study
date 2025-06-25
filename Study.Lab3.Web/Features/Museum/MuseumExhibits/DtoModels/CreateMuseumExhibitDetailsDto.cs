using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

public sealed record CreateMuseumExhibitDetailsDto
{
    /// <summary>
    /// Идентификатор экспоната
    /// </summary>
    [Required]
    public Guid IsnMuseumExhibit { get; init; }

    /// <summary>
    /// Происхождение экспоната
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Origin)]
    public string Origin { get; init; }

    /// <summary>
    /// Создатель/Автор
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Creator)]
    public string Creator { get; init; }

    /// <summary>
    /// Год создания
    /// </summary>
    public int? CreationYear { get; init; }

    /// <summary>
    /// Материал изготовления
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Material)]
    public string Material { get; init; }

    /// <summary>
    /// Размеры (высота x ширина x глубина)
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Dimensions)]
    public string Dimensions { get; init; }

    /// <summary>
    /// Вес в килограммах
    /// </summary>
    [Range(ModelConstants.MuseumExhibitDetails.MinWeight, ModelConstants.MuseumExhibitDetails.MaxWeight)]
    public double? Weight { get; init; }

    /// <summary>
    /// Историческая эпоха
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.HistoricalPeriod)]
    public string HistoricalPeriod { get; init; }

    /// <summary>
    /// Состояние сохранности
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Condition)]
    public string Condition { get; init; }
}
