using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Storage.Models.Fitness;

/// <summary>
/// Тренер фитнес-центра
/// </summary>
public class FitnessTrainer
{
    /// <summary>
    /// Идентификатор тренера
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnTrainer { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessTrainer.SurName)]
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessTrainer.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [MaxLength(ModelConstants.FitnessTrainer.PatronymicName)]
    public string PatronymicName { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessTrainer.PhoneNumber)]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessTrainer.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Специализация
    /// </summary>
    [Required]
    public TrainerSpecialization Specialization { get; set; }

    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    [Required]
    [Range(ModelConstants.FitnessTrainer.MinExperience, ModelConstants.FitnessTrainer.MaxExperience)]
    public int ExperienceYears { get; set; }

    /// <summary>
    /// Сертификации
    /// </summary>
    [MaxLength(ModelConstants.FitnessTrainer.Certifications)]
    public string Certifications { get; set; }

    /// <summary>
    /// Почасовая ставка
    /// </summary>
    [Required]
    [Range(ModelConstants.FitnessTrainer.MinHourlyRate, ModelConstants.FitnessTrainer.MaxHourlyRate)]
    public decimal HourlyRate { get; set; }

    /// <summary>
    /// Активен ли тренер
    /// </summary>
    [Required]
    public bool IsActive { get; set; }
}