using CoreLib.Common.Extensions;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Services.BeautySalon;

public sealed class BeautyAppointmentService : IBeautyAppointmentService
{
    public async Task CreateOrUpdateAppointmentValidate(
        DataContext dataContext,
        BeautyAppointment appointment,
        CancellationToken cancellationToken = default)
    {
        /// Проверка правильности ввода дня проведения услуги
        if (appointment.Day > ModelConstants.BeautyAppointment.Day)
        {
            throw new BusinessLogicException($"День проведения услуги не может превышать {ModelConstants.BeautyAppointment.Day} - общее кол-во дней в месяце!");
        }

        /// Проверка правильности ввода месяца проведения услуги
        if (appointment.Month > ModelConstants.BeautyAppointment.Month)
        {
            throw new BusinessLogicException($"Месяц проведения услуги не может превышать {ModelConstants.BeautyAppointment.Month}- общее кол-во месяцев в году!");
        }

        /// Проверка правильности ввода часа проведения услуги
        if (appointment.Hour > ModelConstants.BeautyAppointment.Hour)
        {
            throw new BusinessLogicException($"Час проведения услуги не может превышать {ModelConstants.BeautyAppointment.Hour}- общее кол-во часов в сутках!");
        }

        /// Проверка правильности ввода минут
        if (appointment.Minutes > ModelConstants.BeautyAppointment.Minutes)
        {
            throw new BusinessLogicException($"Минуты не могут превышать {ModelConstants.BeautyAppointment.Minutes}- общее кол-во минут в одном часе!");
        }
    }

    public async Task DeleteAppointmentValidate(
        DataContext dataContext,
        BeautyAppointment appointment,
        CancellationToken cancellationToken = default)
    {
        return;
    }
}