using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;

namespace Study.Lab3.Logic.Interfaces.Services.Pharmacy;

/// <summary>
/// Интерфейс сервиса рецептов
/// </summary>
public interface IPrescriptionService
{
    /// <summary>
    /// Проверка модели рецепта на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="prescription">Рецепт</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdatePrescriptionValidateAndThrowAsync(
        DataContext dataContext,
        Prescription prescription,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверка возможности удаления рецепта
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="prescription">Рецепт</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Prescription prescription,
        CancellationToken cancellationToken = default);
}