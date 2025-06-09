namespace Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;

public sealed record AttendanceLogDto
{
    /// <summary>
    /// Идентификатор посещаемости
    /// </summary>
    public Guid IsnAttendanceLog { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Дата занятия
    /// </summary>
    public DateTime SubjectDate { get; init; }

    /// <summary>
    /// Отметка посещения
    /// </summary>
    public int IsPresent { get; init; }
}