using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Cinema;

/// <summary>
/// Кинозал
/// </summary>
public class Hall
{
    /// <summary>
    /// Идентификатор зала
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnHall { get; set; }

    /// <summary>
    /// Название зала
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hall.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Тип зала
    /// </summary>
    [Required]
    public HallType Type { get; set; }

    /// <summary>
    /// Общая вместимость зала
    /// </summary>
    [Required]
    [Range(ModelConstants.Hall.MinCapacity, ModelConstants.Hall.MaxCapacity)]
    public int Capacity { get; set; }

    /// <summary>
    /// Количество рядов
    /// </summary>
    [Required]
    [Range(ModelConstants.Hall.MinRows, ModelConstants.Hall.MaxRows)]
    public int RowsCount { get; set; }

    /// <summary>
    /// Количество мест в ряду
    /// </summary>
    [Required]
    [Range(ModelConstants.Hall.MinSeatsPerRow, ModelConstants.Hall.MaxSeatsPerRow)]
    public int SeatsPerRow { get; set; }

    /// <summary>
    /// Активен ли зал
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Места в зале
    /// </summary>
    [InverseProperty(nameof(Seat.Hall))]
    public virtual ICollection<Seat> Seats { get; set; }

    /// <summary>
    /// Сеансы в зале
    /// </summary>
    [InverseProperty(nameof(Session.Hall))]
    public virtual ICollection<Session> Sessions { get; set; }
}