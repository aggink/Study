using Study.Lab3.Storage.Enums.MusicStore;

namespace Study.Lab3.Web.Features.MusicStore.Customers.DtoModels;

public sealed record MusicCustomerDto
{
    /// <summary>
    /// Идентификатор покупателя
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
    /// Email адрес
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; init; }

    /// <summary>
    /// Предпочитаемый жанр музыки
    /// </summary>
    public string PreferredGenre { get; init; }

    /// <summary>
    /// Статус покупателя
    /// </summary>
    public CustomerStatus Status { get; init; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; init; }
}
