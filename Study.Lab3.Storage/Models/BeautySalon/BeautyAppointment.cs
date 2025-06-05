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
    [Required, ForeignKey(nameof(BeautyClient))]
    public Guid IsnBeautyClient { get; set; }

    /// <summary>
    /// ID услуги 
    /// </summary>
    [Required, ForeignKey(nameof(BeautyService))]
    public Guid IsnBeautyService { get; set; }

    /// <summary>
    /// День записи
    /// </summary>
    [Required, Range(0, ModelConstants.BeautyAppointment.Day)]
    public int Day { get; set; }

    /// <summary>
    /// Месяц записи
    /// </summary>
    [Required, Range(0, ModelConstants.BeautyAppointment.Month)]
    public int Month { get; set; }

    /// <summary>
    /// Час записи
    /// </summary>
    [Required, Range(0, ModelConstants.BeautyAppointment.Hour)]
    public int Hour { get; set; }

    /// <summary>
    /// Минуты
    /// </summary>
    [Required, Range(0, ModelConstants.BeautyAppointment.Minutes)]
    public int Minutes { get; set; }

    public virtual BeautyClient BeautyClient { get; set; }

    public virtual BeautyService BeautyService { get; set; }
}
