using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;

public sealed record UpdateAttendanceLogDto
{
    /// <summary>
    /// ������������� ������������
    /// </summary>
    [Required]
    public Guid IsnAttendanceLog { get; init; }

    /// <summary>
    /// ���� �������
    /// </summary>
    [Required]
    public DateTime SubjectDate { get; init; }

    /// <summary>
    /// ������� ���������
    /// </summary>
    [Required]
    [Range(ModelConstants.AttendanceLog.MinPresentValue, ModelConstants.AttendanceLog.MaxPresentValue)]
    public int IsPresent { get; init; }
}