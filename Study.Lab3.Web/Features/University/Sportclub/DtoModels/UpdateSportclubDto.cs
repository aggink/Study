using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Sportclub.DtoModels;

public sealed record UpdateSportclubDto
{
    /// <summary>
    /// Идентификатор спортивного клуба
    /// </summary>
    [Required]
    public Guid IsnSportclub { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Sportclub.MinParticipantValue, ModelConstants.Sportclub.MaxParticipantValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения соревнований
    /// </summary>
    [Required]
    public DateTime SportclubDate { get; init; }
}