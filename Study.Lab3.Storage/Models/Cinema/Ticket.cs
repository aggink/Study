using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Cinema;

/// <summary>
/// Билет
/// </summary>
public class Ticket
{
    /// <summary>
    /// Идентификатор билета
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnTicket { get; set; }

    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    [ForeignKey(nameof(Session))]
    public Guid IsnSession { get; set; }

    /// <summary>
    /// Идентификатор места
    /// </summary>
    [ForeignKey(nameof(Seat))]
    public Guid IsnSeat { get; set; }

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [ForeignKey(nameof(Customer))]
    public Guid IsnCustomer { get; set; }

    /// <summary>
    /// Цена билета
    /// </summary>
    [Required]
    [Range(ModelConstants.Ticket.MinPrice, ModelConstants.Ticket.MaxPrice)]
    public decimal Price { get; set; }

    /// <summary>
    /// Дата и время покупки
    /// </summary>
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime PurchaseDate { get; set; }

    /// <summary>
    /// Статус билета
    /// </summary>
    [Required]
    public TicketStatus Status { get; set; }

    /// <summary>
    /// Код билета для проверки
    /// </summary>
    [MaxLength(ModelConstants.Ticket.TicketCodeLength)]
    public string TicketCode { get; set; }

    /// <summary>
    /// Сеанс
    /// </summary>
    public virtual Session Session { get; set; }

    /// <summary>
    /// Место
    /// </summary>
    public virtual Seat Seat { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    public virtual Customer Customer { get; set; }
}