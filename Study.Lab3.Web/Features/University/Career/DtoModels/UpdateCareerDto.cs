using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Career.DtoModels;

public sealed record UpdateCareerDto
{
    /// <summary>
    /// Идентификатор карьеры
    /// </summary>
    [Required]
    public Guid IsnCareer { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Career.MinPartValue, ModelConstants.Career.MaxPartValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения собеседования
    /// </summary>
    [Required]
    public DateTime CareerDate { get; init; }
}