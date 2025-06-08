using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record CreateSweetFactoryDto
{
    /// <summary>
    /// Название фабрики
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.SweetFactory.MaxNameLenght)]
    public string Name { get; init; }

    /// <summary>
    /// Адрес
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.SweetFactory.MaxAddressLenght)]
    public string Adress { get; init; }

    /// <summary>
    /// Объём производства
    /// </summary>
    [Required]
<<<<<<< HEAD
    public Int64 Volume { get; init; }
=======
    public long Volume { get; init; }
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
}