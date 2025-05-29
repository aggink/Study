namespace Study.Lab3.Web.Features.Cinema.Customers.DtoModels;

public sealed record CustomerDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; init; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; init; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; init; }
    
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; init; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; init; }
    
    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; init; }
    
    /// <summary>
    /// Активен ли клиент
    /// </summary>
    public bool IsActive { get; init; }
}