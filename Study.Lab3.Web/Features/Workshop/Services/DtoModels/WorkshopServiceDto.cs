namespace Study.Lab3.Web.Features.Workshop.Services.DtoModels;

public sealed record WorkshopServiceDto
{
    /// <summary>
    /// Идентификатор услуги
    /// </summary>
    public Guid IsnService { get; init; }

    /// <summary>
    /// Название услуги
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание услуги
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Цена услуги
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Длительность выполнения в минутах
    /// </summary>
    public int Duration { get; init; }
}
