using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.Adoptions.DtoModels;

public sealed record CreateAdoptionDto
{
    [Required]
    [Range(ModelConstants.Adoption.PriceMin, ModelConstants.Adoption.PriceMax)]
    public int Price { get; init; }

    [Required]
    public Guid IsnCustomer { get; init; }

    [Required]
    public Guid IsnCat { get; init; }

    [Required]
    public DateTime AdoptionDate { get; init; }
}