using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.CoffeeShop;

/// <summary>
/// Бариста
/// </summary>
public class Barista
{
    /// <summary>
    /// Идентификатор бариста
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnBarista { get; set; }

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
    public bool IsActive { get; set; }
}