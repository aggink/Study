/*using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.University.Assignments.DtoModels;

public sealed record UpdateAssignmentDto
{
    /// <summary>
    /// Идентификатор задания
    /// </summary>
    [Required]
    public Guid IsnAssignment { get; init; }

    /// <summary>
    /// Название задания
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Assignment.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Описание задания
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Assignment.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Крайний срок выполнения
    /// </summary>
    public DateTime? Deadline { get; init; }

    /// <summary>
    /// Максимальная оценка
    /// </summary>
    [Required]
    [Range(ModelConstants.Assignment.MinScore, ModelConstants.Assignment.MaxScore)]
    public int MaxScore { get; init; }
}*/