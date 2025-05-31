namespace Study.Lab3.Web.Features.University.TheSportclub.DtoModels;

public sealed record SportclubDto
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
    /// ������������� ������������
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// �������� ���������� ����������
    /// </summary>
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// ���� ���������� ������������
    /// </summary>
    public DateTime SportclubDate { get; init; }
}