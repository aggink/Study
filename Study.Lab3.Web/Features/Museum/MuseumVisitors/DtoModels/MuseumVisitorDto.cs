namespace Study.Lab3.Web.Features.Museum.MuseumVisitors.DtoModels;

public sealed record MuseumVisitorDto
{
    /// <summary>
    /// Идентификатор посетителя
    /// </summary>
    public Guid IsnMuseumVisitor { get; init; }

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
    public DateTime? DateOfBirth { get; init; }

    /// <summary>
    /// Дата посещения
    /// </summary>
    public DateTime VisitDate { get; init; }

    /// <summary>
    /// Тип билета
    /// </summary>
    public string TicketType { get; init; }

    /// <summary>
    /// Стоимость билета
    /// </summary>
    public double TicketPrice { get; init; }

    /// <summary>
    /// Является ли членом музея
    /// </summary>
    public bool IsMember { get; init; }

    /// <summary>
    /// Номер членского билета
    /// </summary>
    public string MembershipNumber { get; init; }
}
