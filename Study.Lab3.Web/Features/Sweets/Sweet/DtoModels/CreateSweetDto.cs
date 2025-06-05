using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;

public sealed record CreateSweetDto
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Sweet.MaxNameLenght)]
    public string Name { get; init; }
    
    /// <summary>
    /// Идентификатор типа сладости
    /// </summary>
    [Required]
    public Guid SweetTypeID { get; init; }
    
    /// <summary>
    /// Ингридиенты
    /// </summary>
    [MaxLength(ModelConstants.Sweet.MaxIngredientsLenght)]
    public string Ingredients { get; init; }
}