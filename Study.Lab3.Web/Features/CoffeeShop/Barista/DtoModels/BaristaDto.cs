namespace Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;

/// <summary>
/// DTO бариста
/// </summary>
public class BaristaDto
{
    /// <summary>
    /// Идентификатор бариста
    /// </summary>
    public Guid IsnBarista { get; set; }

    /// <summary>
    /// Имя бариста
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия бариста
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Телефон бариста
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Email бариста
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    public int Experience { get; set; }

    /// <summary>
    /// Специализация бариста
    /// </summary>
    public string Specialization { get; set; }

    /// <summary>
    /// Зарплата в месяц
    /// </summary>
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