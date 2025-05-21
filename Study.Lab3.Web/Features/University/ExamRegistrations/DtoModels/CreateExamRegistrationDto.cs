using Study.Lab3.Storage.Enums.University;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;

public sealed record CreateExamRegistrationDto
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    [Required]
    public Guid IsnExam { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Статус регистрации
    /// </summary>
    [Required]
    public RegistrationStatus Status { get; init; } = RegistrationStatus.Registered;
}