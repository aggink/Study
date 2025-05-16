using Study.Lab3.Web.Features.University.Subjects.DtoModels;

namespace Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;

public sealed record TeacherSubjectListItemDto
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// ФИО учителя
    /// </summary>
    public string TeacherFullName { get; init; }

    /// <summary>
    /// Список предметов учителя
    /// </summary>
    public SubjectDto[] Subjects { get; init; }
}
