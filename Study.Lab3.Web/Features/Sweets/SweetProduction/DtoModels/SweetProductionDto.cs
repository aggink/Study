namespace Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;


public sealed record SweetProductionDto
{
    /// <summary>
    /// Идентификатор 
    /// </summary>
    public Guid IsnSweetProduction { get; init; }

    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    public Guid IsnSweet { get; init; }

    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    public Guid IsnFactory { get; init; }
}