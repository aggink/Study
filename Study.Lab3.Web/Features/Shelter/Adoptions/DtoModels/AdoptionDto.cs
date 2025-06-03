using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Web.Features.Shelter.Adoptions.DtoModels;

public sealed record AdoptionDto
{
    [Required]
    public Guid IsnAdoption { get; set; }
        
    [Required]
    public int Price { get; set; }

    [Required]
    public Guid IsnCustomer { get; set; }
    
    [Required]
    public Guid IsnCat { get; set; }

    [Required]
    public DateTime AdoptionDate { get; set; }
        
    [Required]
    public string Status { get; set; }
}