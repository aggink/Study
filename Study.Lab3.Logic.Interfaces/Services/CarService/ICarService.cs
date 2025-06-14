using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarService;

namespace Study.Lab3.Logic.Interfaces.Services.CarService;

public interface ICarService
{
    /// <summary>
    /// Проверка записи на возможность создания/редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="car">Машина</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCarValidateAndThrowAsync(
        DataContext dataContext,
        Car car,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверка записи на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="car">Машины</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Car car,
        CancellationToken cancellationToken = default);
}