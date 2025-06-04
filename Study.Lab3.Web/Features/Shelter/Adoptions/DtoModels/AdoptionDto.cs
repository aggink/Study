using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Web.Features.Shelter.Adoptions.DtoModels;

public sealed record AdoptionDto
{
    public Guid IsnAdoption { get; init; }
    
    public int Price { get; init; }
    
    public Guid IsnCustomer { get; init; }
    
    public Guid IsnCat { get; init; }
    
    public DateTime AdoptionDate { get; init; }
    
    public string Status { get; init; }
}