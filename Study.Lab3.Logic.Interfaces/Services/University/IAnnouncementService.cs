using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IAnnouncementService
{
    /// <summary>
    /// Проверка модели объявления на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="announcement">Объявление</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateAnnouncementValidateAndThrowAsync(
        DataContext dataContext,
        Announcement announcement,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления объявления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="announcement">Объявление</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Announcement announcement,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности добавления группы к объявлению
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="announcementGroup">Связь объявления с группой</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <param name="skipAnnouncementCheck">Пропустить проверку существования объявления</param>
    Task AddGroupValidateAndThrowAsync(
        DataContext dataContext,
        AnnouncementGroup announcementGroup,
        CancellationToken cancellationToken = default,
        bool skipAnnouncementCheck = false);
}