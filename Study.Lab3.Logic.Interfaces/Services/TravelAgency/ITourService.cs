using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.TravelAgency;

namespace Study.Lab3.Logic.Interfaces.Services.TravelAgency;

public interface ITourService
{
    /// <summary>
    /// Проверка модели тура на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="tour">Тур</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateTourValidateAndThrowAsync(
        DataContext dataContext,
        Tour tour,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления тура
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="tour">Тур</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Tour tour,
        CancellationToken cancellationToken = default);
}