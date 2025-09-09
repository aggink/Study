using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
namespace Study.Lab3.Web.Features.Formula1.Drivers.DtoModels;

public class UpdateDriverDto
{
    [Required]
    public Guid IsnDriver { get; init; }
    [Required]
    public Guid IsnTeam { get; init; }
    [Required, MaxLength(ModelConstants.Driver.Name)]
    public string Name { get; init; }
    [Required, Range(ModelConstants.Driver.AgeMin, ModelConstants.Driver.AgeMax)]
    public int Age { get; init; }
    [Required, MaxLength(ModelConstants.Driver.CountryOfOrigin)]
    public string CountryOfOrigin { get; init; }
}
