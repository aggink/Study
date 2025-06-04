namespace Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;


public sealed record SweetProductionDto
{
    /// <summary>
    /// Идентификатор 
    /// </summary>
    public Int64 ID { get; init; }

    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    public Int64 SweetID { get; init; }

    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    public Int64 FactoryID { get; init; }
}