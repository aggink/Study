using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record UpdateSweetFactoryDto
{
    /// <summary>
    /// Идентификатор Фабрики
    /// </summary>
    [Required]
    public Guid IsnSweetFactory { get; init; }
<<<<<<< HEAD
    
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
<<<<<<< HEAD
    [MaxLength(ModelConstants. SweetFactory.MaxNameLenght)]
=======
    [MaxLength(ModelConstants.SweetFactory.MaxNameLenght)]
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
    public string Name { get; init; }

    /// <summary>
    /// Идентификатор Типа Сладости
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.SweetFactory.MaxAddressLenght)]
    public string Address { get; init; }

    /// <summary>
    /// Ингридиенты
    /// </summary>
    [Required]
<<<<<<< HEAD
    public Int64 Volume { get; init; }
=======
    public long Volume { get; init; }
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
}