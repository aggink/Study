using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Shelter.Cats.DtoModels;

public class CreateCatDto
{
    [Required]
    [MaxLength(ModelConstants.Cat.Nickname)]
    public string Nickname { get; set; }
    
    public DateTime? BirthDate { get; set; }

    [Required]
    [MaxLength(ModelConstants.Cat.Breed)]
    public string Breed { get; set; }

    [Required]
    public bool IsVaccinated { get; set; }

    [Required]
    public bool IsSterilized { get; set; }

    [Required]
    [MaxLength(ModelConstants.Cat.Color)]
    public string Color { get; set; }

    [Required]
    [MaxLength(ModelConstants.Cat.MedicalHistory)]
    public string MedicalHistory { get; set; }

    [Required]
    [MaxLength(ModelConstants.Cat.PhotoUrl)]
    public string PhotoUrl { get; set; }

    [Required]
    public DateTime ArrivalDate { get; set; }

    [Required]
    [Range(ModelConstants.Cat.AgeMin, ModelConstants.Cat.AgeMax)]
    public int Age { get; set; }
        
    [Required]
    [Range(ModelConstants.Cat.WeightMin, ModelConstants.Cat.WeightMax)]
    public int Weight { get; set; }
}