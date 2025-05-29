namespace Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;

public sealed record TeacherSubjectDto
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Имя учителя
    /// </summary>
    public string TeacherName { get; init; }

    /// <summary>
    /// Название предмета
    /// </summary>
    public string SubjectName { get; init; }
}