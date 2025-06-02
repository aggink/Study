namespace Study.Lab3.Web.Features.BeautySalon.BeautyClient.DtoModels;
public sealed record ClientDto
{
    /// <summary>
    /// ID клиента
    /// </summary>
    public Guid IsnClient { get; init; }

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
    public string PhoneNumber { get; init; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string EmailAddress { get; init; }
}