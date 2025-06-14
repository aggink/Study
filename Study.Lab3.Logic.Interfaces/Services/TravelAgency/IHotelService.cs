using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.TravelAgency;

namespace Study.Lab3.Logic.Interfaces.Services.TravelAgency;

public interface IHotelService
{
    /// <summary>
    /// Проверка модели отеля на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="hotel">Отель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateHotelValidateAndThrowAsync(
        DataContext dataContext,
        Hotel hotel,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления отеля
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="hotel">Отель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Hotel hotel,
        CancellationToken cancellationToken = default);
}