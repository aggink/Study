using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheKvn.DtoModels;

public sealed record UpdateKvnDto
{
    /// <summary>
    /// ������������� ���
    /// </summary>
    [Required]
    public Guid IsnKvn { get; init; }

    /// <summary>
    /// �������� ���������� ����������
    /// </summary>
    [Required]
    [Range(ModelConstants.Kvn.MinPart, ModelConstants.Kvn.MaxPart)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// ���� ���������� �����������
    /// </summary>
    [Required]
    public DateTime KvnDate { get; init; }
}