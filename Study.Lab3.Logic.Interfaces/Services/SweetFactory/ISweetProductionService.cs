using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;

namespace Study.Lab3.Logic.Interfaces.Services.SweetFactory;

public interface ISweetProductionService
{
    /// <summary>
    /// Проверка модели таблицы Сладкая продукция на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sweetproduction">Сладкая продукция</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateSweetProductionValidateAndThrowAsync(
        DataContext dataContext,
        SweetProduction sweetproduction,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления записи
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sweetproduction">Сладкая продукция</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        SweetProduction sweetproduction,
        CancellationToken cancellationToken = default);
}
