using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Web.Features.Fitness.Trainers.DtoModels;

public sealed record CreateTrainerDto
{
    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessTrainer.SurName)]
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessTrainer.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    [MaxLength(ModelConstants.FitnessTrainer.PatronymicName)]
    public string PatronymicName { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessTrainer.PhoneNumber)]
    public string PhoneNumber { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessTrainer.Email)]
    public string Email { get; init; }

    /// <summary>
    /// Специализация
    /// </summary>
    [Required]
    public TrainerSpecialization Specialization { get; init; }

    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    [Required]
    [Range(ModelConstants.FitnessTrainer.MinExperience, ModelConstants.FitnessTrainer.MaxExperience)]
    public int ExperienceYears { get; init; }

    /// <summary>
    /// Сертификации
    /// </summary>
    [MaxLength(ModelConstants.FitnessTrainer.Certifications)]
    public string Certifications { get; init; }

    /// <summary>
    /// Почасовая ставка
    /// </summary>
    [Required]
    [Range(ModelConstants.FitnessTrainer.MinHourlyRate, ModelConstants.FitnessTrainer.MaxHourlyRate)]
    public decimal HourlyRate { get; init; }

    /// <summary>
    /// Активен ли тренер
    /// </summary>
    public bool IsActive { get; init; } = true;
}
