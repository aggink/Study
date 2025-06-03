using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Shelter;

public class Cat
{
    /// <summary>
    /// Идентификатор кота
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnCat { get; set; }

    [Required]
    [MaxLength(ModelConstants.Cat.Nickname)]
    public string Nickname { get; set; }

    [Required]
    public DateTime? BirthDate { get; set; }

    [MaxLength(ModelConstants.Cat.Description)]
    public string Description { get; set; }

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
    public bool IsAvailableForAdoption { get; set; }

    [Required]
    [Range(ModelConstants.Cat.AgeMin, ModelConstants.Cat.AgeMax)]
    public int Age { get; set; }

    [Required]
    [Range(ModelConstants.Cat.WeightMin, ModelConstants.Cat.WeightMax)]
    public int Weight { get; set; }

    [InverseProperty(nameof(Adoption.Cat))]
    public virtual ICollection<Adoption> Adoptions { get; set; }
}