namespace Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;

/// <summary>
/// DTO бариста
/// </summary>
public sealed record BaristaDto
{
    /// <summary>
    /// Идентификатор бариста
    /// </summary>
    public Guid IsnBarista { get; init; }

    /// <summary>
    /// Имя бариста
    /// </summary>
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия бариста
    /// </summary>
    public string LastName { get; init; }

    /// <summary>
    /// Телефон бариста
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Email бариста
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    public int Experience { get; init; }

    /// <summary>
    /// Специализация бариста
    /// </summary>
    public string Specialization { get; init; }

    /// <summary>
    /// Зарплата в месяц
    /// </summary>
    public double? Salary { get; init; }

    /// <summary>
    /// Дата найма
    /// </summary>
    public DateTime HireDate { get; init; }

    /// <summary>
    /// Активен ли сотрудник
    /// </summary>
    public bool IsActive { get; init; }
}