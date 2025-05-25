using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;

public sealed record CreateTeacherSubjectDto
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [Required]
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }
}