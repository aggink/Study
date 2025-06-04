using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;

public sealed record UpdateSweetProductionDto
{
    /// <summary>
    /// Идентификатор 
    /// </summary>
    public Int64 ID { get; init; }

    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    [Required]
    public Int64 SweetID { get; init; }

    /// <summary>
    /// Идентификатор Фабрики
    /// </summary>
    [Required]
    public Int64 FactoryID { get; init; }
    
}