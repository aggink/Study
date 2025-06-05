namespace Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;


public sealed record SweetProductionDto
{
    /// <summary>
    /// Идентификатор 
    /// </summary>
    public Guid ID { get; init; }

    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    public Guid SweetID { get; init; }

    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    public Guid FactoryID { get; init; }
}