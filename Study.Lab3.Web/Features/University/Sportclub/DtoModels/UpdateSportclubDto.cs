using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheSportclub.DtoModels;

public sealed record UpdateSportclubDto
{
    /// <summary>
    /// ������������� ����������� �����
    /// </summary>
    [Required]
    public Guid IsnSportclub { get; init; }

    /// <summary>
    /// �������� ���������� ����������
    /// </summary>
    [Required]
    [Range(ModelConstants.Sportclub.MinParticipantValue, ModelConstants.Sportclub.MaxParticipantValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// ���� ���������� ������������
    /// </summary>
    [Required]
    public DateTime SportclubDate { get; init; }
}