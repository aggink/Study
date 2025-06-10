using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProfcom.DtoModels;

public sealed record UpdateProfcomDto
{
	/// <summary>
	/// Идентификатор профкома
	/// </summary>
	[Required]
	public Guid IsnProfcom { get; init; }

	/// <summary>
	/// Значение количества участников
	/// </summary>
	[Required]
	[Range(ModelConstants.Profcom.MinPartValue, ModelConstants.Profcom.MaxPartValue)]
	public int ParticipantsCount { get; init; }

	/// <summary>
	/// Дата проведения научной встречи
	/// </summary>
	[Required]
	public DateTime ProfcomDate { get; init; }
}