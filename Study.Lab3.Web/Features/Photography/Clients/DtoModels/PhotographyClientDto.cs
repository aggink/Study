namespace Study.Lab3.Web.Features.Photography.Clients.DtoModels;

public sealed record PhotographyClientDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnPhotographyClient { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; init; }

    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; init; }

    /// <summary>
    /// Комментарии о клиенте
    /// </summary>
    public string Notes { get; init; }

    /// <summary>
    /// Полное имя клиента
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";
}
