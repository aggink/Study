using Study.Lab3.Storage.Enums.University;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;

public sealed record UpdateExamRegistrationDto
{
    /// <summary>
    /// Идентификатор регистрации
    /// </summary>
    [Required]
    public Guid IsnExamRegistration { get; init; }

    /// <summary>
    /// Статус регистрации
    /// </summary>
    [Required]
    public RegistrationStatus Status { get; init; }
}