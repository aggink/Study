using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;

public sealed record UpdateSweetFactoryDto
{
    /// <summary>
    /// Идентификатор Фабрики
    /// </summary>
    [Required]
    public Guid IsnSweetFactory { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.SweetFactory.MaxNameLenght)]
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
    public long Volume { get; init; }
}