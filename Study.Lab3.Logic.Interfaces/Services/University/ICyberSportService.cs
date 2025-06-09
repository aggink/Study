using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface ICyberSportService
{
    /// <summary>
    /// Проверка модели киберспорта на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="cyberSport">киберспорт</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCyberSportValidateAndThrowAsync(
        DataContext dataContext,
        CyberSport cyberSport,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления мероприятия киберспорт
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="cyberSport">киберспорт</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        CyberSport cyberSport,
        CancellationToken cancellationToken = default);
}