using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Cinema;

/// <summary>
/// Киносеанс
/// </summary>
public class Session
{
    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnSession { get; set; }

    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [ForeignKey(nameof(Movie))]
    public Guid IsnMovie { get; set; }

    /// <summary>
    /// Идентификатор зала
    /// </summary>
    [ForeignKey(nameof(Hall))]
    public Guid IsnHall { get; set; }

    /// <summary>
    /// Время начала сеанса
    /// </summary>
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Время окончания сеанса (рассчитывается автоматически)
    /// </summary>
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Базовая цена билета
    /// </summary>
    [Required]
    [Range(ModelConstants.Session.MinPrice, ModelConstants.Session.MaxPrice)]
    public decimal BasePrice { get; set; }

    /// <summary>
    /// Активен ли сеанс
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Фильм
    /// </summary>
    public virtual Movie Movie { get; set; }

    /// <summary>
    /// Зал
    /// </summary>
    public virtual Hall Hall { get; set; }

    /// <summary>
    /// Билеты на сеанс
    /// </summary>
    [InverseProperty(nameof(Ticket.Session))]
    public virtual ICollection<Ticket> Tickets { get; set; }
}