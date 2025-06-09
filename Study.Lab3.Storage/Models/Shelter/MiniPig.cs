using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Shelter;

public class MiniPig
{
	/// <summary>
	/// Идентификатор мини пига
	/// </summary>
	[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
	public Guid IsnMiniPig { get; set; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.Nickname)]
	public string Nickname { get; set; }

	[Required]
	public DateTime? BirthDate { get; set; }

	[MaxLength(ModelConstants.MiniPig.Description)]
	public string Description { get; set; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.Breed)]
	public string Breed { get; set; }

	[Required]
	public bool IsVaccinated { get; set; }

	[Required]
	public bool IsSterilized { get; set; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.Color)]
	public string Color { get; set; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.MedicalHistory)]
	public string MedicalHistory { get; set; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.PhotoUrl)]
	public string PhotoUrl { get; set; }

	[Required]
	public DateTime ArrivalDate { get; set; }

	[Required]
	public bool IsAvailableForAdoption { get; set; }

	[Required]
	[Range(ModelConstants.MiniPig.AgeMin, ModelConstants.MiniPig.AgeMax)]
	public int Age { get; set; }

	[Required]
	[Range(ModelConstants.MiniPig.WeightMin, ModelConstants.MiniPig.WeightMax)]
	public int Weight { get; set; }

	[InverseProperty(nameof(Adoption.MiniPig))]
	public virtual ICollection<Adoption> Adoptions { get; set; }
}