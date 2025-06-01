using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.BeautySalon;

/// <summary>
/// Запись клиента на услугу
/// </summary>
public class BeautyAppointments
{
    /// <summary>
    /// ID записи 
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyAppointment.AppointmentID)]
    public string AppointmentID { get; set; }

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
