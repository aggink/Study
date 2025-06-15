using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Photography;

namespace Study.Lab3.Logic.Interfaces.Services.Photography;

public interface IPhotographyEquipmentService
{
    /// <summary>
    /// Проверка модели оборудования на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="equipment">Оборудование</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateEquipmentValidateAndThrowAsync(
        DataContext dataContext,
        PhotographyEquipment equipment,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления оборудования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="equipment">Оборудование</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PhotographyEquipment equipment,
        CancellationToken cancellationToken = default);
}
