using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Web.Features.Fitness.Trainers.DtoModels;

public sealed record TrainerDto
{
    /// <summary>
    /// Идентификатор тренера
    /// </summary>
    public Guid IsnTrainer { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string PatronymicName { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Специализация
    /// </summary>
    public TrainerSpecialization Specialization { get; init; }

    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    public int ExperienceYears { get; init; }

    /// <summary>
    /// Сертификации
    /// </summary>
    public string Certifications { get; init; }

    /// <summary>
    /// Почасовая ставка
    /// </summary>
    public decimal HourlyRate { get; init; }

    /// <summary>
    /// Активен ли тренер
    /// </summary>
    public bool IsActive { get; init; }
}
