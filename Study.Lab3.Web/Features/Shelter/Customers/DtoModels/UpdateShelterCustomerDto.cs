namespace Study.Lab3.Web.Features.Shelter.Customers.DtoModels;

public sealed record UpdateShelterCustomerDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public string LastName { get; init; }

    /// <summary>
    /// Описание клиента
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Адрес клиента
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public string PhoneNumber { get; init; }

    /// <summary>
    /// Email клиента
    /// </summary>
    public string Email { get; init; }
}