using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;

public sealed record CreateSweetProductionDto
{
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