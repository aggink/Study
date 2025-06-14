namespace Study.Lab3.Web.Features.TravelAgency.Tours.DtoModels;

public sealed record TourDto
{
    /// <summary>
    /// Идентификатор тура
    /// </summary>
    public Guid IsnTour { get; init; }

    /// <summary>
    /// Название тура
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание тура
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Страна назначения
    /// </summary>
    public string Country { get; init; }

    /// <summary>
    /// Город назначения
    /// </summary>
    public string City { get; init; }

    /// <summary>
    /// Цена тура
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Продолжительность в днях
    /// </summary>
    public int Duration { get; init; }

    /// <summary>
    /// Дата начала тура
    /// </summary>
    public DateTime StartDate { get; init; }

    /// <summary>
    /// Дата окончания тура
    /// </summary>
    public DateTime EndDate { get; init; }

    /// <summary>
    /// Максимальное количество участников
    /// </summary>
    public int MaxParticipants { get; init; }

    /// <summary>
    /// Доступен ли тур
    /// </summary>
    public bool IsAvailable { get; init; }
}