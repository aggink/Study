using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheSportclub.DtoModels;

public sealed record CreateSportclubDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор соревнований
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Sportclub.MinParticipantValue, ModelConstants.Sportclub.MaxParticipantValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата соревнований
    /// </summary>
    [Required]
    public DateTime SportclubDate { get; init; }
}