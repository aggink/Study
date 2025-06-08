using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.SweetTypes.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record CreateSweetTypeDto
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.SweetType.MaxNameLenght)]
    public string Name { get; init; }
}