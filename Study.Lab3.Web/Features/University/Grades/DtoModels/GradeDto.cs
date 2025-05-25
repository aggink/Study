namespace Study.Lab3.Web.Features.University.Grades.DtoModels;

public sealed record GradeDto
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    public Guid IsnGrade { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение оценки
    /// </summary>
    public int Value { get; init; }

    /// <summary>
    /// Дата выставления оценки
    /// </summary>
    public DateTime GradeDate { get; init; }
}