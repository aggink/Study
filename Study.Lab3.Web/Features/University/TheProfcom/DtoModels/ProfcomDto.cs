namespace Study.Lab3.Web.Features.University.TheProfcom.DtoModels;
//хихи хаха
public sealed record ProfcomDto
{
	/// <summary>
	/// Идентификатор профкома
	/// </summary>
	public Guid IsnProfcom { get; init; }

	/// <summary>
	/// Идентификатор студента
	/// </summary>
	public Guid IsnStudent { get; init; }

	/// <summary>
	/// Идентификатор предмета
	/// </summary>
	public Guid IsnSubject { get; init; }

	/// <summary>
	/// Значение количества участников
	/// </summary>
	public int ParticipantsCount { get; init; }

	/// <summary>
	/// Дата проведения научной встречи
	/// </summary>
	public DateTime ProfcomDate { get; init; }
}