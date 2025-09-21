using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IChessclubService
{
    /// <summary>
    /// Проверка модели спортивного клуба на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="chessclub">Шахматный клуб</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateChessclubValidateAndThrowAsync(
        DataContext dataContext,
        Chessclub chessclub,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления соревнований шахматного клуба
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="chessclub">Шахматный клуб</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Chessclub chessclub,
        CancellationToken cancellationToken = default);
}