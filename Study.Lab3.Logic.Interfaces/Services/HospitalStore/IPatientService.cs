using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Logic.Interfaces.Services.HospitalStore;

public interface IPatientService
{
    /// <summary>
    /// Проверка пациента на возможность создания/обновления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="patient">Данные пациента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreatePatientValidateAndThrowAsync(
        DataContext dataContext,
        Patient patient,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка пациента на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="patient">Данные пациента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeletePatientValidateAndThrowAsync(
        DataContext dataContext,
        Patient patient,
        CancellationToken cancellationToken = default);
}