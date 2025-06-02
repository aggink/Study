using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Web.Features.Shelter.Adoptions.DtoModels;

public sealed record CreateAdoptionDto
{
    [Required]
    [Range(ModelConstants.Adoption.PriceMin, ModelConstants.Adoption.PriceMax)]
    public int Price { get; set; }

    [Required]
    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }

    [ForeignKey(nameof(Cat))]
    public Guid CatId { get; set; }

    [Required]
    public DateTime AdoptionDate { get; set; }
}