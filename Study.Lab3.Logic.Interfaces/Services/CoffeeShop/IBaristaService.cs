using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CoffeeShop;

namespace Study.Lab3.Logic.Interfaces.Services.CoffeeShop;

/// <summary>
/// Интерфейс сервиса бариста
/// </summary>
public interface IBaristaService
{
    /// <summary>
    /// Проверка модели бариста на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="barista">Модель бариста</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateBaristaValidateAndThrowAsync(
        DataContext dataContext,
        Barista barista,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления бариста
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="barista">Модель бариста</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Barista barista,
        CancellationToken cancellationToken = default);
}