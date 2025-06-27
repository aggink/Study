namespace Study.Lab3.Web.Features.Pharmacy.Customers.DtoModels;

public sealed record PharmacyCustomerDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }
    
    /// <summary>
    /// Имя клиента
    /// </summary>
    public string FirstName { get; init; }
    
    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public string LastName { get; init; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; init; }
    
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; init; }
    
    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; init; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? DateOfBirth { get; init; }
    
    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; init; }
    
    /// <summary>
    /// Есть ли медицинская страховка
    /// </summary>
    public bool HasInsurance { get; init; }
}