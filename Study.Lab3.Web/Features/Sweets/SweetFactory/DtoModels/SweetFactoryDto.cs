namespace Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;

public sealed record SweetFactoryDto
{
    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    public Guid IsnSweetFactory { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Объём продукции
    /// </summary>
    public long Volume { get; init; }
}