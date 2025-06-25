using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Formula1.Drivers.DtoModels;

public sealed record CreateDriverDto
{
    /// <summary>
    /// Идентификатор команды
    /// </summary>
    [Required]
    public Guid IsnTeam { get; init; }

    /// <summary>
    /// Имя гонщика
    /// </summary>
    [Required, MaxLength(ModelConstants.Driver.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Возраст
    /// </summary>
    [Required, Range(ModelConstants.Driver.AgeMin, ModelConstants.Driver.AgeMax)]
    public int Age { get; init; }

    /// <summary>
    /// Страна происхождения
    /// </summary>
    [MaxLength(ModelConstants.Driver.CountryOfOrigin)]
    public string CountryOfOrigin { get; init; }
}
