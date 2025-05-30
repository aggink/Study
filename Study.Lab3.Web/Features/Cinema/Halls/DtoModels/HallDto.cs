namespace Study.Lab3.Web.Features.Cinema.Halls.DtoModels;

public sealed record HallDto
{
    /// <summary>
    /// Идентификатор зала
    /// </summary>
    public Guid IsnHall { get; init; }

    /// <summary>
    /// Название зала
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Тип зала
    /// </summary>
    public int Type { get; init; }

    /// <summary>
    /// Общая вместимость зала
    /// </summary>
    public int Capacity { get; init; }

    /// <summary>
    /// Количество рядов
    /// </summary>
    public int RowsCount { get; init; }

    /// <summary>
    /// Количество мест в ряду
    /// </summary>
    public int SeatsPerRow { get; init; }

    /// <summary>
    /// Активен ли зал
    /// </summary>
    public bool IsActive { get; init; }
}