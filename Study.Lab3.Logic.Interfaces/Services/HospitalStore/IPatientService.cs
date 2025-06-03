using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Logic.Interfaces.Services.HospitalStore;

/// <summary>
/// Интерфейс сервиса пациентов
/// </summary>
public interface IPatientService
{
    /// <summary>
    /// Проверка модели пациента на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="patient">Модель пациента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdatePatientValidateAndThrowAsync(
        DataContext dataContext,
        Patient patient,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления пациента
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="patient">Модель пациента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Patient patient,
        CancellationToken cancellationToken = default);
}
