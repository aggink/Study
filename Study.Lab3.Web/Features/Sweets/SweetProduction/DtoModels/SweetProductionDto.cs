<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117


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