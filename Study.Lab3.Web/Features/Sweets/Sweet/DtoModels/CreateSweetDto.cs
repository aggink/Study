using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record CreateSweetDto
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Sweet.MaxNameLenght)]
    public string Name { get; init; }
<<<<<<< HEAD
    
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
    /// <summary>
    /// Идентификатор типа сладости
    /// </summary>
    [Required]
    public Guid IsnSweetType { get; init; }
<<<<<<< HEAD
    
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
    /// <summary>
    /// Ингридиенты
    /// </summary>
    [MaxLength(ModelConstants.Sweet.MaxIngredientsLenght)]
    public string Ingredients { get; init; }
}