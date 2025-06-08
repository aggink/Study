using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;

public sealed record SweetTypeDto
{
    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    [Required]
    public Guid IsnSweetType { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    public string Name { get; init; }
}