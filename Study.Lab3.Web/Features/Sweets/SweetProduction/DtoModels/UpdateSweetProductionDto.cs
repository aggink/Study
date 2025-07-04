using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;

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

}