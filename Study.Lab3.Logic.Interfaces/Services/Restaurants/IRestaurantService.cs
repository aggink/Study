using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Interfaces.Services.Restaurants;

public interface IRestaurantService
{
    /// <summary>
    /// Проверка модели ресторана на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="restaurant">Ресторан</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateRestaurantValidateAndThrowAsync(
        DataContext dataContext,
        Restaurant restaurant,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления ресторана
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="restaurant">Ресторан</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Restaurant restaurant,
        CancellationToken cancellationToken = default);
}
