using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;

public sealed record CreateSweetTypeDto
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.SweetType.MaxNameLenght)]
    public string Name { get; init; }
}