using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Logic.Interfaces.Services.HospitalStore;

/// <summary>
/// Интерфейс сервиса товаров 
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Проверка модели товара на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="product">Модель товара</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateProductValidateAndThrowAsync(
        DataContext dataContext,
        Product product,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления товара
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="product">Модель товара</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Product product,
        CancellationToken cancellationToken = default);
}
