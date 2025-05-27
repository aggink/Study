using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Interfaces.Services.Cinema;

public interface ISessionService
{
    /// <summary>
    /// Проверка модели сеанса на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="session">Сеанс</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateSessionValidateAndThrowAsync(
        DataContext dataContext,
        Session session,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления сеанса
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="session">Сеанс</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Session session,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка на пересечение сеансов в зале
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="session">Сеанс</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task<bool> CheckSessionOverlapAsync(
        DataContext dataContext,
        Session session,
        CancellationToken cancellationToken = default);
}