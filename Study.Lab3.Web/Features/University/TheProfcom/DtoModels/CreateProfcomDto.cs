using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProfcom.DtoModels;

public sealed record CreateProfcomDto
{
	/// <summary>
	/// Идентификатор студента
	/// </summary>
	[Required]
	public Guid IsnStudent { get; init; }

	/// <summary>
	/// Идентификатор научной встречи
	/// </summary>
	[Required]
	public Guid IsnSubject { get; init; }

	/// <summary>
	/// Значение количества участников
	/// </summary>
	[Required]
	[Range(ModelConstants.Profcom.MinPartValue, ModelConstants.Profcom.MaxPartValue)]
	public int ParticipantsCount { get; init; }

	/// <summary>
	/// Дата научной встречи
	/// </summary>
	[Required]
	public DateTime ProfcomDate { get; init; }

	/// <summary>
	/// Место проведения
	/// </summary>
	[Required]
	public string Audience { get; init; }
}