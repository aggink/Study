using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.MiniPigAdoptions.DtoModels;

public sealed record CreateMiniPigAdoptionDto
{
    [Required]
    [Range(ModelConstants.Adoption.PriceMin, ModelConstants.Adoption.PriceMax)]
    public int Price { get; init; }

    [Required]
    public Guid IsnCustomer { get; init; }

    [Required]
    public Guid IsnMiniPig { get; init; }

    [Required]
    public DateTime AdoptionDate { get; init; }
}