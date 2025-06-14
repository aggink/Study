using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;

namespace Study.Lab3.Logic.Interfaces.Services.GameStore;

public interface IGameService
{
    /// <summary>
    /// Проверка модели игры на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="game">Игра</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateGameValidateAndThrowAsync(
        DataContext dataContext,
        Game game,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления игры
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="game">Игра</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Game game,
        CancellationToken cancellationToken = default);
}
