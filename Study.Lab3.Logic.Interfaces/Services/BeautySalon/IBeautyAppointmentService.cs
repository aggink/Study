using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Interfaces.Services.BeautySalon;

/// <summary>
/// Интерфейс сервиса записи клиента на услугу
/// </summary>
public interface IBeautyAppointmentService
{
    /// <summary>
    /// Проверка записи на возможность создания/редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="appointment">Запись в салон</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateAppointmentValidateAndThrowAsync(
        DataContext dataContext,
        BeautyAppointment appointment,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка записи на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="appointment">ЗАпись в салон</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        BeautyAppointment appointment,
        CancellationToken cancellationToken = default);
}
