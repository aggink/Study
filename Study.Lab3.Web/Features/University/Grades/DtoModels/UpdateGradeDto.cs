using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Grades.DtoModels;

public sealed record UpdateGradeDto
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    [Required]
    public Guid IsnGrade { get; init; }

    /// <summary>
    /// Значение оценки
    /// </summary>
    [Required]
    [Range(2, 5)]
    public int Value { get; init; }

    /// <summary>
    /// Дата выставления оценки
    /// </summary>
    [Required]
    public DateTime GradeDate { get; init; }
}