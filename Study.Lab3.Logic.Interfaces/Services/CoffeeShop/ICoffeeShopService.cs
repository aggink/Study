using Study.Lab3.Storage.Database;

namespace Study.Lab3.Logic.Interfaces.Services.CoffeeShop;

/// <summary>
/// Интерфейс сервиса кофейни
/// </summary>
public interface ICoffeeShopService
{
    /// <summary>
    /// Проверка модели кофейни на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="coffeeShop">Модель кофейни</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCoffeeShopValidateAndThrowAsync(
        DataContext dataContext,
        Storage.Models.CoffeeShop.CoffeeShop coffeeShop,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления кофейни
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="coffeeShop">Модель кофейни</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Storage.Models.CoffeeShop.CoffeeShop coffeeShop,
        CancellationToken cancellationToken = default);
}