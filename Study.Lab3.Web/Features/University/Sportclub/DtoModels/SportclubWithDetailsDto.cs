namespace Study.Lab3.Web.Features.University.TheSportclub.DtoModels;

public sealed record SportclubWithDetailsDto
{
    /// <summary>
    /// ������������� ����������� �����
    /// </summary>
    public Guid IsnSportclub { get; init; }

    /// <summary>
    /// ������������� ��������
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ��� ��������
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// ������������� ������������
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// �������� ������������
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// �������� ���������� ����������
    /// </summary>
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// ���� ���������� ������������
    /// </summary>
    public DateTime SportclubDate { get; init; }
}