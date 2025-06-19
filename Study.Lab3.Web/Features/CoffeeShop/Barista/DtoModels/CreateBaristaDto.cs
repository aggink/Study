using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;

/// <summary>
/// DTO для создания бариста
/// </summary>
public sealed record CreateBaristaDto
{
    /// <summary>
    /// Имя бариста
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Barista.FirstName)]
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия бариста
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Barista.LastName)]
    public string LastName { get; init; }

    /// <summary>
    /// Телефон бариста
    /// </summary>
    [MaxLength(ModelConstants.Barista.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Email бариста
    /// </summary>
    [MaxLength(ModelConstants.Barista.Email)]
    [EmailAddress]
    public string Email { get; init; }

    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    [Range(ModelConstants.Barista.MinExperience, ModelConstants.Barista.MaxExperience)]
    public int Experience { get; init; }

    /// <summary>
    /// Специализация бариста
    /// </summary>
    [MaxLength(ModelConstants.Barista.Specialization)]
    public string Specialization { get; init; }

    /// <summary>
    /// Зарплата в месяц
    /// </summary>
    [Range(ModelConstants.Barista.MinSalary, ModelConstants.Barista.MaxSalary)]
    public double? Salary { get; init; }

    /// <summary>
    /// Дата найма
    /// </summary>
    public DateTime HireDate { get; init; }

    /// <summary>
    /// Активен ли сотрудник
    /// </summary>
    public bool IsActive { get; init; } = true;
}