namespace Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;

public sealed record TeacherSubjectWithDetailsDto
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
    /// Идентификатор предмета
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Название предмета
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// Количество студентов с оценками по предмету
    /// </summary>
    public int StudentsCount { get; init; }

    /// <summary>
    /// Средний балл по предмету
    /// </summary>
    public double AverageGrade { get; init; }
}