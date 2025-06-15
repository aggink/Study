using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Photography;

namespace Study.Lab3.Storage.Models.Photography;

/// <summary>
/// Фотосессия
/// </summary>
public class PhotographySession
{
    /// <summary>
    /// Идентификатор фотосессии
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPhotographySession { get; set; }

    /// <summary>
    /// Название фотосессии
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographySession.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Дата и время проведения
    /// </summary>
    [Required]
    public DateTime SessionDate { get; set; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.PhotographySession.MinDuration, ModelConstants.PhotographySession.MaxDuration)]
    public int Duration { get; set; }

    /// <summary>
    /// Местоположение
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographySession.Location)]
    public string Location { get; set; }

    /// <summary>
    /// Стоимость фотосессии
    /// </summary>
    [Required]
    [Range(ModelConstants.PhotographySession.MinPrice, ModelConstants.PhotographySession.MaxPrice)]
    public double Price { get; set; }

    /// <summary>
    /// Имя фотографа
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographySession.PhotographerName)]
    public string PhotographerName { get; set; }

    /// <summary>
    /// Тип фотосессии
    /// </summary>
    [Required]
    public PhotographySessionType PhotographySessionType { get; set; }

    /// <summary>
    /// Статус фотосессии
    /// </summary>
    [Required]
    public PhotographySessionStatus Status { get; set; }

    /// <summary>
    /// Описание/комментарии
    /// </summary>
    [MaxLength(ModelConstants.PhotographySession.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Количество готовых фотографий
    /// </summary>
    public int? PhotoCount { get; set; }
}