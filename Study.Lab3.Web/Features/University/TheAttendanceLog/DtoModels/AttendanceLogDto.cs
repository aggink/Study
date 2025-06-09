namespace Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;

public sealed record AttendanceLogDto
{
    /// <summary>
    /// ������������� ������������
    /// </summary>
    public Guid IsnAttendanceLog { get; init; }

    /// <summary>
    /// ������������� ��������
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ������������� ��������
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// ���� �������
    /// </summary>
    public DateTime SubjectDate { get; init; }

    /// <summary>
    /// ������� ���������
    /// </summary>
    public int IsPresent { get; init; }
}