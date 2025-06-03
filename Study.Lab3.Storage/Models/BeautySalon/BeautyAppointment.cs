using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.BeautySalon;

/// <summary>
/// Запись клиента на услугу
/// </summary>
public class BeautyAppointment
{
    /// <summary>
    /// ID записи 
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnAppointment { get; set; }

    /// <summary>
    /// ID клиента
    /// </summary>
    [Required]
    public Guid IsnClient { get; set; }

    /// <summary>
    /// ID услуги 
    /// </summary>
    [Required]
    public Guid IsnService { get; set; }

    /// <summary>
    /// День записи
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyAppointment.Day)]
    public int Day { get; set; }

    /// <summary>
    /// Месяц записи
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyAppointment.Month)]
    public int Month { get; set; }

    /// <summary>
    /// Час записи
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyAppointment.Hour)]
    public int Hour { get; set; }

    /// <summary>
    /// Минуты
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyAppointment.Minutes)]
    public int Minutes { get; set; }
}
