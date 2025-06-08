using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record UpdateSweetProductionDto
{
    /// <summary>
    /// Идентификатор 
    /// </summary>
    public Guid IsnSweetProduction { get; init; }

    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    [Required]
    public Guid IsnSweet { get; init; }

    /// <summary>
    /// Идентификатор Фабрики
    /// </summary>
    [Required]
    public Guid IsnFactory { get; init; }
<<<<<<< HEAD
    
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
}