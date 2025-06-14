namespace Study.Lab3.Web.Features.TravelAgency.Customers.DtoModels;

public sealed record TravelCustomerDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }

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
    /// Дата рождения
    /// </summary>
    public DateTime DateOfBirth { get; init; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    public string PassportNumber { get; init; }

    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Адрес проживания
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Дата регистрации в системе
    /// </summary>
    public DateTime RegistrationDate { get; init; }

    /// <summary>
    /// VIP клиент
    /// </summary>
    public bool IsVip { get; init; }
}
