namespace Study.Lab3.Web.Features.Cinema.Movies.DtoModels;

public sealed record MovieWithDetailsDto
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    public Guid IsnMovie { get; init; }

    /// <summary>
    /// Название фильма
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Описание фильма
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    public int Duration { get; init; }

    /// <summary>
    /// Форматированная строка продолжительности
    /// </summary>
    public string DurationString { get; init; }

    /// <summary>
    /// Рейтинг фильма
    /// </summary>
    public double Rating { get; init; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    public int Year { get; init; }

    /// <summary>
    /// Страна производства
    /// </summary>
    public string Country { get; init; }

    /// <summary>
    /// Возрастное ограничение
    /// </summary>
    public int AgeRating { get; init; }

    /// <summary>
    /// Форматированное возрастное ограничение
    /// </summary>
    public string AgeRatingString { get; init; }

    /// <summary>
    /// Активен ли фильм в прокате
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Дата добавления
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Жанры фильма
    /// </summary>
    public GenreItemDto[] Genres { get; init; }

    /// <summary>
    /// Количество запланированных сеансов
    /// </summary>
    public int SessionsCount { get; init; }

    /// <summary>
    /// Общее количество проданных билетов
    /// </summary>
    public int TotalTicketsSold { get; init; }

    /// <summary>
    /// Общая выручка
    /// </summary>
    public decimal TotalRevenue { get; init; }
}

public sealed record GenreItemDto
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public Guid IsnGenre { get; init; }

    /// <summary>
    /// Название жанра
    /// </summary>
    public string Name { get; init; }
}