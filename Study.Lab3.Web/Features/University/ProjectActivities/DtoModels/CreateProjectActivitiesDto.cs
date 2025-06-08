using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProjectActivities.DtoModels;

public sealed record CreateProjectActivitiesDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор выступлений
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение количества выступлений
    /// </summary>
    [Required]
    [Range(ModelConstants.ProjectActivities.MinPerformancesValue, ModelConstants.ProjectActivities.MaxPerformancesValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата выступлений
    /// </summary>
    [Required]
    public DateTime ProjectActivitiesDate { get; init; }
}