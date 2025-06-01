using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Logic.Interfaces.Services.HospitalStore;

public interface IProductService
{
    /// <summary>
    /// Проверка товара на возможность создания/обновления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="product">Данные товара</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateProductValidateAndThrowAsync(
        DataContext dataContext,
        Product product,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка товара на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="product">Данные товара</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteProductValidateAndThrowAsync(
        DataContext dataContext,
        Product product,
        CancellationToken cancellationToken = default);
}