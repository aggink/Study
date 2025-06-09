using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;

public sealed record CreateAttendanceLogDto
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
    /// Дата посещения
    /// </summary>
    [Required]
    public DateTime SubjectDate { get; init; }

    /// <summary>
    /// Отметка посещаемости
    /// </summary>
    [Required]
    public int IsPresent { get; init; }
}