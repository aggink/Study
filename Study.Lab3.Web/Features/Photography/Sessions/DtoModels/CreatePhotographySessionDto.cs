using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Photography;

namespace Study.Lab3.Web.Features.Photography.Sessions.DtoModels;

public sealed record CreatePhotographySessionDto
{
    /// <summary>
    /// Название фотосессии
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographySession.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Дата и время проведения
    /// </summary>
    [Required]
    public DateTime SessionDate { get; init; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.PhotographySession.MinDuration, ModelConstants.PhotographySession.MaxDuration)]
    public int Duration { get; init; }

    /// <summary>
    /// Местоположение
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographySession.Location)]
    public string Location { get; init; }

    /// <summary>
    /// Стоимость фотосессии
    /// </summary>
    [Required]
    [Range(ModelConstants.PhotographySession.MinPrice, ModelConstants.PhotographySession.MaxPrice)]
    public double Price { get; init; }

    /// <summary>
    /// Имя фотографа
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographySession.PhotographerName)]
    public string PhotographerName { get; init; }

    /// <summary>
    /// Тип фотосессии
    /// </summary>
    [Required]
    public PhotographySessionType PhotographySessionType { get; init; }

    /// <summary>
    /// Статус фотосессии
    /// </summary>
    [Required]
    public PhotographySessionStatus Status { get; init; } = PhotographySessionStatus.Scheduled;

    /// <summary>
    /// Описание/комментарии
    /// </summary>
    [MaxLength(ModelConstants.PhotographySession.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Количество готовых фотографий
    /// </summary>
    public int? PhotoCount { get; init; }
}
