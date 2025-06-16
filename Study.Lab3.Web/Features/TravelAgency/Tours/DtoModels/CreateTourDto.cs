using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.TravelAgency.Tours.DtoModels;

public sealed record CreateTourDto
{
    /// <summary>
    /// Название тура
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Tour.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Описание тура
    /// </summary>
    [MaxLength(ModelConstants.Tour.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Страна назначения
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Tour.Country)]
    public string Country { get; init; }

    /// <summary>
    /// Город назначения
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Tour.City)]
    public string City { get; init; }

    /// <summary>
    /// Цена тура
    /// </summary>
    [Required]
    [Range(ModelConstants.Tour.MinPrice, ModelConstants.Tour.MaxPrice)]
    public decimal Price { get; init; }

    /// <summary>
    /// Продолжительность в днях
    /// </summary>
    [Required]
    [Range(ModelConstants.Tour.MinDuration, ModelConstants.Tour.MaxDuration)]
    public int Duration { get; init; }

    /// <summary>
    /// Дата начала тура
    /// </summary>
    [Required]
    public DateTime StartDate { get; init; }

    /// <summary>
    /// Максимальное количество участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Tour.MinParticipants, ModelConstants.Tour.MaxParticipants)]
    public int MaxParticipants { get; init; }

    /// <summary>
    /// Доступен ли тур
    /// </summary>
    public bool IsAvailable { get; init; } = true;
}
