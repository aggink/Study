using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;

public sealed record CreatePingpongclubDto
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
    [Range(ModelConstants.Pingpongclub.MinParticipantValue, ModelConstants.Pingpongclub.MaxParticipantValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата соревнований
    /// </summary>
    [Required]
    public DateTime PingpongclubDate { get; init; }
}