using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;

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
    public string Address { get; init; }

    /// <summary>
    /// Объём производства
    /// </summary>
    [Required]
    public long Volume { get; init; }
}