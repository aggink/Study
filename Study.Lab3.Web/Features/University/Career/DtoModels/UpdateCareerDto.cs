using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheCareer.DtoModels;

public sealed record UpdateCareerDto
{
    /// <summary>
    /// ������������� �������
    /// </summary>
    [Required]
    public Guid IsnCareer { get; init; }

    /// <summary>
    /// �������� ���������� ����������
    /// </summary>
    [Required]
    [Range(ModelConstants.Career.MinPartValue, ModelConstants.Career.MaxPartValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// ���� ���������� �������������
    /// </summary>
    [Required]
    public DateTime CareerDate { get; init; }
}