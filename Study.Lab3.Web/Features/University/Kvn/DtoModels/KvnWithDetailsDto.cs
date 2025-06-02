namespace Study.Lab3.Web.Features.University.TheKvn.DtoModels;

public sealed record KvnWithDetailsDto
{
    /// <summary>
    /// ������������� ���
    /// </summary>
    public Guid IsnKvn { get; init; }

    /// <summary>
    /// ������������� ���������
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ��� ���������
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// ������������� ���� �����������
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// �������� ���� �����������
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// �������� ���������� ����������
    /// </summary>
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// ���� ���������� �����������
    /// </summary>
    public DateTime KvnDate { get; init; }
}