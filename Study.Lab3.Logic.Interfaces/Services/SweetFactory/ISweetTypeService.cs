using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;

namespace Study.Lab3.Logic.Interfaces.Services.SweetFactory;

public interface ISweetTypeService
{
    /// <summary>
    /// Проверка модели таблицы Тип Сладости на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sweettype">Тип Сладости</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateSweetTypeValidateAndThrowAsync(
        DataContext dataContext,
        SweetType sweettype,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления записи
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sweettype">Тип Сладости</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        SweetType sweettype,
        CancellationToken cancellationToken = default);
}
