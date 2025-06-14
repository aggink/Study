using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.TravelAgency;

/// <summary>
/// Тур
/// </summary>
public class Tour
{
    /// <summary>
    /// Идентификатор тура
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnTour { get; set; }

    /// <summary>
    /// Название тура
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Tour.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Описание тура
    /// </summary>
    [MaxLength(ModelConstants.Tour.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Страна назначения
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Tour.Country)]
    public string Country { get; set; }

    /// <summary>
    /// Город назначения
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Tour.City)]
    public string City { get; set; }

    /// <summary>
    /// Цена тура
    /// </summary>
    [Required]
    [Range(ModelConstants.Tour.MinPrice, ModelConstants.Tour.MaxPrice)]
    public decimal Price { get; set; }

    /// <summary>
    /// Продолжительность в днях
    /// </summary>
    [Required]
    [Range(ModelConstants.Tour.MinDuration, ModelConstants.Tour.MaxDuration)]
    public int Duration { get; set; }

    /// <summary>
    /// Дата начала тура
    /// </summary>
    [Required]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата окончания тура
    /// </summary>
    [Required]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Максимальное количество участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Tour.MinParticipants, ModelConstants.Tour.MaxParticipants)]
    public int MaxParticipants { get; set; }

    /// <summary>
    /// Доступен ли тур
    /// </summary>
    public bool IsAvailable { get; set; }
}