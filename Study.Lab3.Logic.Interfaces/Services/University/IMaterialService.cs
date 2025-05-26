/*using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IMaterialService
{
    /// <summary>
    /// Проверка модели материала на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="material">Материал</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateMaterialValidateAndThrowAsync(
        DataContext dataContext,
        Material material,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления материала
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="material">Материал</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Material material,
        CancellationToken cancellationToken = default);
}*/