using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Grades.DtoModels;

public sealed record CreateGradeDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение оценки
    /// </summary>
    [Required]
    [Range(ModelConstants.Grade.MinValue, ModelConstants.Grade.MaxValue)]
    public int Value { get; init; }

    /// <summary>
    /// Дата выставления оценки
    /// </summary>
    [Required]
    public DateTime GradeDate { get; init; }
}