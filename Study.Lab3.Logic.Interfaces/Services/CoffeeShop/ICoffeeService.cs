using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CoffeeShop;

namespace Study.Lab3.Logic.Interfaces.Services.CoffeeShop;

/// <summary>
/// Интерфейс сервиса кофе
/// </summary>
public interface ICoffeeService
{
    /// <summary>
    /// Проверка модели кофе на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="coffee">Модель кофе</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCoffeeValidateAndThrowAsync(
        DataContext dataContext,
        Coffee coffee,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления кофе
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="coffee">Модель кофе</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Coffee coffee,
        CancellationToken cancellationToken = default);
}