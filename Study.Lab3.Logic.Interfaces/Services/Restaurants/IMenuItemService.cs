using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Interfaces.Services.Restaurants;

public interface IMenuItemService
{
    /// <summary>
    /// Проверка модели позиции меню на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="menuItem">Позиция меню</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateMenuItemValidateAndThrowAsync(
        DataContext dataContext,
        MenuItem menuItem,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления позиции меню
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="menuItem">Позиция меню</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MenuItem menuItem,
        CancellationToken cancellationToken = default);
}
