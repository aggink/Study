namespace Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;


public sealed record SweetProductionDto
{
    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    public Int64 SweetID { get; init; }

    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    public Int64 FactoryID { get; init; }
}