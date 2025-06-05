using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Logic.Interfaces.Services.Shelter;

public interface IAdoptionService
{
    /// <summary>
    /// Проверка модели заказа на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="adoption">Заказ</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        Adoption adoption,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления заказа
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="adoption">Заказ</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Adoption adoption,
        CancellationToken cancellationToken = default);
}