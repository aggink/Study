using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Web.Features.Shelter.Adoptions.DtoModels;

public sealed record CreateAdoptionDto
{
    [Required]
    public int Price { get; init; }

    [Required]
    public Guid IsnCustomer { get; init; }

    [Required]
    public Guid IsnCat { get; init; }

    [Required]
    public DateTime AdoptionDate { get; init; }
}