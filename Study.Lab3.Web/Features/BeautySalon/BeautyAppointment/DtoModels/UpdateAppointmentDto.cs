using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.DtoModels;

public sealed record UpdateAppointmentDto
{
    /// <summary>
    /// ID записи
    /// </summary>
    [Required]
    public Guid IsnAppointment { get; init; }

    /// <summary>
    /// День записи
    /// </summary>
    [Required]
    [Range(0, ModelConstants.BeautyAppointment.Day)]
    public int Day { get; init; }

    /// <summary>
    /// Месяц записи
    /// </summary>
    [Required]
    [Range(0, ModelConstants.BeautyAppointment.Month)]
    public int Month { get; init; }

    /// <summary>
    /// Час записи
    /// </summary>
    [Required]
    [Range(0, ModelConstants.BeautyAppointment.Hour)]
    public int Hour { get; init; }

    /// <summary>
    /// Минуты
    /// </summary>
    [Required]
    [Range(0, ModelConstants.BeautyAppointment.Minutes)]
    public int Minutes { get; init; }
}