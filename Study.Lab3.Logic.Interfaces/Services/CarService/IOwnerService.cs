using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarService;

namespace Study.Lab3.Logic.Interfaces.Services.CarService;

public interface IOwnerService
{
    /// <summary>
    /// Проверка на возможность создания/редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="owner">Владелец</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateOwnerValidateAndThrowAsync(
        DataContext dataContext,
        Owner owner,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверка на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="owner">Владелец</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Owner owner,
        CancellationToken cancellationToken = default);
}