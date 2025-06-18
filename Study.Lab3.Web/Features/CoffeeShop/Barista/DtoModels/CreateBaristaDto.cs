using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;

/// <summary>
/// DTO для создания бариста
/// </summary>
public class CreateBaristaDto
{
    /// <summary>
    /// Имя бариста
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Barista.FirstName)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия бариста
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Barista.LastName)]
    public string LastName { get; set; }

    /// <summary>
    /// Телефон бариста
    /// </summary>
    [MaxLength(ModelConstants.Barista.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Email бариста
    /// </summary>
    [MaxLength(ModelConstants.Barista.Email)]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    [Range(ModelConstants.Barista.MinExperience, ModelConstants.Barista.MaxExperience)]
    public int Experience { get; set; }

    /// <summary>
    /// Специализация бариста
    /// </summary>
    [MaxLength(ModelConstants.Barista.Specialization)]
    public string Specialization { get; set; }

    /// <summary>
    /// Зарплата в месяц
    /// </summary>
    [Range(ModelConstants.Barista.MinSalary, ModelConstants.Barista.MaxSalary)]
    public double? Salary { get; set; }

    /// <summary>
    /// Дата найма
    /// </summary>
    public DateTime HireDate { get; set; }

    /// <summary>
    /// Активен ли сотрудник
    /// </summary>
    public bool IsActive { get; set; } = true;
}