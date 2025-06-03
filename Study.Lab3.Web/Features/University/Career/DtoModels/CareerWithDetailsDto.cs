namespace Study.Lab3.Web.Features.University.TheCareer.DtoModels;

public sealed record CareerWithDetailsDto
{
    /// <summary>
    /// ������������� �������
    /// </summary>
    public Guid IsnCareer { get; init; }

    /// <summary>
    /// ������������� ��������
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ��� ��������
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// ������������� �������������
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// �������� �������������
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// �������� ���������� ����������
    /// </summary>
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// ���� ���������� ��������������
    /// </summary>
    public DateTime CareerDate { get; init; }
}