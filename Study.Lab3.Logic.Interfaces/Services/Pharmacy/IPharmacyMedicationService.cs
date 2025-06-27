using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;

namespace Study.Lab3.Logic.Interfaces.Services.Pharmacy;

/// <summary>
/// Интерфейс сервиса медикаментов в аптеке
/// </summary>
public interface IPharmacyMedicationService
{
    /// <summary>
    /// Проверка модели медикамента на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="medication">Медикамент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateMedicationValidateAndThrowAsync(
        DataContext dataContext,
        PharmacyMedication medication,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверка возможности удаления медикамента
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="medication">Медикамент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PharmacyMedication medication,
        CancellationToken cancellationToken = default);
}