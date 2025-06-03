using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.DtoModels;


public sealed record SweetTypeDto
{
    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    [Required]
    public Int64 ID { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    public string Name { get; init; }
}