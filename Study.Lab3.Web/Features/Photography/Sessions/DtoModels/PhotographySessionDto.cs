using Study.Lab3.Storage.Enums.Photography;

namespace Study.Lab3.Web.Features.Photography.Sessions.DtoModels;

public sealed record PhotographySessionDto
{
    /// <summary>
    /// Идентификатор фотосессии
    /// </summary>
    public Guid IsnPhotographySession { get; init; }

    /// <summary>
    /// Название фотосессии
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Дата и время проведения
    /// </summary>
    public DateTime SessionDate { get; init; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    public int Duration { get; init; }

    /// <summary>
    /// Местоположение
    /// </summary>
    public string Location { get; init; }

    /// <summary>
    /// Стоимость фотосессии
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Имя фотографа
    /// </summary>
    public string PhotographerName { get; init; }

    /// <summary>
    /// Тип фотосессии
    /// </summary>
    public PhotographySessionType PhotographySessionType { get; init; }

    /// <summary>
    /// Статус фотосессии
    /// </summary>
    public PhotographySessionStatus Status { get; init; }

    /// <summary>
    /// Описание/комментарии
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Количество готовых фотографий
    /// </summary>
    public int? PhotoCount { get; init; }

    /// <summary>
    /// Окончание фотосессии
    /// </summary>
    public DateTime SessionEndDate => SessionDate.AddMinutes(Duration);
}
