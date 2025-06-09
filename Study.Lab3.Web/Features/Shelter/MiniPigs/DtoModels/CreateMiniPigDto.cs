using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.MiniPigs.DtoModels;

public class CreateMiniPigDto
{
	[Required]
	[MaxLength(ModelConstants.MiniPig.Nickname)]
	public string Nickname { get; init; }

	public DateTime? BirthDate { get; init; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.Breed)]
	public string Breed { get; init; }

	[Required]
	public bool IsVaccinated { get; init; }

	[Required]
	public bool IsSterilized { get; init; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.Color)]
	public string Color { get; init; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.MedicalHistory)]
	public string MedicalHistory { get; init; }

	[Required]
	[MaxLength(ModelConstants.MiniPig.PhotoUrl)]
	public string PhotoUrl { get; init; }

	[Required]
	public DateTime ArrivalDate { get; init; }

	[Required]
	[Range(ModelConstants.MiniPig.AgeMin, ModelConstants.MiniPig.AgeMax)]
	public int Age { get; init; }

	[Required]
	[Range(ModelConstants.MiniPig.WeightMin, ModelConstants.MiniPig.WeightMax)]
	public int Weight { get; init; }
}