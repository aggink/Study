using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;

public sealed record BuyTicketDto
{
    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    [Required]
    public Guid IsnSession { get; init; }

    /// <summary>
    /// Идентификатор места
    /// </summary>
    [Required]
    public Guid IsnSeat { get; init; }

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    public Guid IsnCustomer { get; init; }
}