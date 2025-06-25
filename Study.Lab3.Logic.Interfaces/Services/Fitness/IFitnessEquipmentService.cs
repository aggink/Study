using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;

namespace Study.Lab3.Logic.Interfaces.Services.Fitness;

public interface IFitnessEquipmentService
{
    /// <summary>
    /// Проверка модели оборудования на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="equipment">Оборудование</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateEquipmentValidateAndThrowAsync(
        DataContext dataContext,
        FitnessEquipment equipment,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления оборудования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="equipment">Оборудование</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        FitnessEquipment equipment,
        CancellationToken cancellationToken = default);
}