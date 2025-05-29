using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Cinema;

/// <summary>
/// Место в кинозале
/// </summary>
public class Seat
{
    /// <summary>
    /// Идентификатор места
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnSeat { get; set; }

    /// <summary>
    /// Идентификатор зала
    /// </summary>
    [ForeignKey(nameof(Hall))]
    public Guid IsnHall { get; set; }

    /// <summary>
    /// Номер ряда
    /// </summary>
    [Required]
    public int Row { get; set; }

    /// <summary>
    /// Номер места в ряду
    /// </summary>
    [Required]
    public int Number { get; set; }

    /// <summary>
    /// Тип места
    /// </summary>
    [Required]
    public SeatType Type { get; set; }

    /// <summary>
    /// Активно ли место (не сломано)
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Зал
    /// </summary>
    public virtual Hall Hall { get; set; }

    /// <summary>
    /// Билеты на это место
    /// </summary>
    [InverseProperty(nameof(Ticket.Seat))]
    public virtual ICollection<Ticket> Tickets { get; set; }
}