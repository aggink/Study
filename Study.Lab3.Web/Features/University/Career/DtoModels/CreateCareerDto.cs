using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheCareer.DtoModels;

public sealed record CreateCareerDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор собеседования
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Career.MinPartValue, ModelConstants.Career.MaxPartValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата собеседования
    /// </summary>
    [Required]
    public DateTime CareerDate { get; init; }
}