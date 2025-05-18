using System.ComponentModel.DataAnnotations;

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
    [MaxLength(200)]
    public string Title { get; init; }

    /// <summary>
    /// Описание задания
    /// </summary>
    [Required]
    public string Description { get; init; }

    /// <summary>
    /// Крайний срок выполнения
    /// </summary>
    public DateTime? Deadline { get; init; }

    /// <summary>
    /// Максимальная оценка
    /// </summary>
    [Required]
    [Range(1, 100)]
    public int MaxScore { get; init; }
}