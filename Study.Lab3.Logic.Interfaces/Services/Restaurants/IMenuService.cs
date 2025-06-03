using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Interfaces.Services.Restaurants;

public interface IMenuService
{
    /// <summary>
    /// Проверка модели меню на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="menu">Меню</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateMenuValidateAndThrowAsync(
        DataContext dataContext,
        Menu menu,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления меню
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="menu">Меню</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Menu menu,
        CancellationToken cancellationToken = default);
}
