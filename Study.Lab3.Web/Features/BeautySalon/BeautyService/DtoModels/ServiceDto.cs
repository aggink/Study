namespace Study.Lab3.Web.Features.BeautySalon.BeautyService.DtoModels;

public sealed record ServiceDto
{
    /// <summary>
    /// ID услуги
    /// </summary>
    public Guid IsnService { get; init; }

    /// <summary>
    /// Название услуги
    /// </summary>
    public string ServiceName { get; init; }

    /// <summary>
    /// Описание услуги
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; }

    /// <summary>
    /// Длительность
    /// </summary>
    public int Duration { get; init; }
}