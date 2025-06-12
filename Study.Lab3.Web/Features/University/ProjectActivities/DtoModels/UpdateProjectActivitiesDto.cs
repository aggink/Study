using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProjectActivities.DtoModels;

public sealed record UpdateProjectActivitiesDto
{
    /// <summary>
    /// Идентификатор проектной деятельности
    /// </summary>
    [Required]
    public Guid IsnProjectActivities { get; init; }

    /// <summary>
    /// Значение количества выступлений
    /// </summary>
    [Required]
    [Range(ModelConstants.ProjectActivities.MinPerformancesValue, ModelConstants.ProjectActivities.MaxPerformancesValue)]
    public int PerformancesCount { get; init; }

    /// <summary>
    /// Дата проведения выступлений
    /// </summary>
    [Required]
    public DateTime ProjectActivitiesDate { get; init; }
}