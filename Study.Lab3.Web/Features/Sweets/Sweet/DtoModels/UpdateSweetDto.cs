using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;

public sealed record UpdateSweetDto
{
    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    [Required]
    public Guid IsnSweet { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Sweet.MaxNameLenght)]
    public string Name { get; init; }

    /// <summary>
    /// Идентификатор Типа Сладости
    /// </summary>
    [Required]
    public Guid IsnSweetType { get; init; }

    /// <summary>
    /// Ингридиенты
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Sweet.MaxIngredientsLenght)]
    public string Ingredients { get; init; }
}