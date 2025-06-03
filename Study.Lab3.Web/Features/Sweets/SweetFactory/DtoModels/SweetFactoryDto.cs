namespace Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;

public sealed record SweetFactoryDto
{
    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    public Int64 ID { get; init; }
    
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
    public Int64 Volume { get; init; }
}