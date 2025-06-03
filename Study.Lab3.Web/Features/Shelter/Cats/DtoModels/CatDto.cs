using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Shelter.Cats.DtoModels;

public sealed record CatDto
{
    /// <summary>
    /// Идентификатор кота
    /// </summary>
    [Required]
    public Guid IsnCat { get; init; }

    [Required]
    [MaxLength(ModelConstants.Cat.Nickname)]
    public string Nickname { get; init; }
    
    public DateTime? BirthDate { get; init; }

    [MaxLength(ModelConstants.Cat.Description)]
    public string Description { get; init; }

    [Required]
    [MaxLength(ModelConstants.Cat.Breed)]
    public string Breed { get; init; }

    [Required]
    public bool IsVaccinated { get; init; }

    [Required]
    public bool IsSterilized { get; init; }

    [Required]
    [MaxLength(ModelConstants.Cat.Color)]
    public string Color { get; init; }

    [Required]
    [MaxLength(ModelConstants.Cat.MedicalHistory)]
    public string MedicalHistory { get; init; }

    [Required]
    [MaxLength(ModelConstants.Cat.PhotoUrl)]
    public string PhotoUrl { get; init; }

    [Required]
    public DateTime ArrivalDate { get; init; }

    [Required]
    public bool IsAvailableForAdoption { get; init; }

    [Required]
    [Range(ModelConstants.Cat.AgeMin, ModelConstants.Cat.AgeMax)]
    public int Age { get; init; }
        
    [Required]
    [Range(ModelConstants.Cat.WeightMin, ModelConstants.Cat.WeightMax)]
    public int Weight { get; init; }
}