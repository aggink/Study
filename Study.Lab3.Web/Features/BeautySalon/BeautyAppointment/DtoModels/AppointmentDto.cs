namespace Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.DtoModels;
public sealed record AppointmentDto
{
    /// <summary>
    /// ID записи
    /// </summary>
    public Guid IsnAppointment { get; init; }

    /// <summary>
    /// День записи
    /// </summary>
    public int Day { get; init; }

    /// <summary>
    /// Месяц записи
    /// </summary>
    public int Month { get; init; }

    /// <summary>
    /// Час записи
    /// </summary>
    public int Hour { get; init; }

    /// <summary>
    /// Минуты
    /// </summary>
    public int Minutes { get; init; }
}