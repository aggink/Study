using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record UpdateSweetDto
{
    /// <summary>
    /// Идентификатор Сладости
    /// </summary>
    [Required]
    public Guid IsnSweet { get; init; }
<<<<<<< HEAD
    
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
<<<<<<< HEAD
    [MaxLength(ModelConstants. Sweet.MaxNameLenght)]
=======
    [MaxLength(ModelConstants.Sweet.MaxNameLenght)]
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
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