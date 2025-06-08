using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Оценки
/// </summary>
public class Profcom
{
	/// <summary>
	/// Идентификатор профкома
	/// </summary>
	[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
	public Guid IsnProfcom { get; set; }

	/// <summary>
	/// Идентификатор студента
	/// </summary>
	[ForeignKey(nameof(Student))]
	public Guid IsnStudent { get; set; }

	/// <summary>
	/// Идентификатор предмета
	/// </summary>
	[ForeignKey(nameof(Subject))]
	public Guid IsnSubject { get; set; }

	/// <summary>
	/// Значение количества участников
	/// </summary>
	[Required]
	[Range(ModelConstants.Profcom.MinPartValue, ModelConstants.Profcom.MaxPartValue)]
	public int ParticipantsCount { get; set; }

	/// <summary>
	/// Дата мероприятия
	/// </summary>
	[Required]
	public DateTime ProfcomDate { get; set; }

	/// <summary>
	/// Студент
	/// </summary>
	public virtual Student Student { get; set; }

	/// <summary>
	/// Предмет
	/// </summary>
	public virtual Subject Subject { get; set; }

	/// <summary>
	/// Место проведения
	/// </summary>
	public virtual string Audience { get; set; }
}