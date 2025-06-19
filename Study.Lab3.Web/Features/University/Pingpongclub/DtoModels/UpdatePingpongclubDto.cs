using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;

public sealed record UpdatePingpongclubDto
{
    /// <summary>
    /// Идентификатор спортивного клуба
    /// </summary>
    [Required]
    public Guid IsnPingpongclub { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Pingpongclub.MinParticipantValue, ModelConstants.Pingpongclub.MaxParticipantValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения соревнований
    /// </summary>
    [Required]
    public DateTime PingpongclubDate { get; init; }
}