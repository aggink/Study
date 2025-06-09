using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;

public sealed record UpdateAttendanceLogDto
{
    /// <summary>
    /// Идентификатор посещаемости
    /// </summary>
    [Required]
    public Guid IsnAttendanceLog { get; init; }

    /// <summary>
    /// Дата занятия
    /// </summary>
    [Required]
    public DateTime SubjectDate { get; init; }

    /// <summary>
    /// Отметка посещения
    /// </summary>
    [Required]
    [Range(ModelConstants.AttendanceLog.MinPresentValue, ModelConstants.AttendanceLog.MaxPresentValue)]
    public int IsPresent { get; init; }
}