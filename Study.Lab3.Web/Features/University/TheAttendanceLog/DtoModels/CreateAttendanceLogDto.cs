using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;

public sealed record CreateAttendanceLogDto
{
    /// <summary>
    /// ������������� ��������
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ������������� ��������
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// ���� ���������
    /// </summary>
    [Required]
    public DateTime SubjectDate { get; init; }

    /// <summary>
    /// ������� ������������
    /// </summary>
    [Required]
    public int IsPresent { get; init; }
}