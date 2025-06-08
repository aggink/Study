using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.SweetTypes.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

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