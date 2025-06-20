using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Museum;

namespace Study.Lab3.Logic.Interfaces.Services.Museum;

public interface IMuseumExhibitService
{
    /// <summary>
    /// Проверка модели экспоната на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="exhibit">Экспонат</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateExhibitValidateAndThrowAsync(
        DataContext dataContext,
        MuseumExhibit exhibit,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления экспоната
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="exhibit">Экспонат</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MuseumExhibit exhibit,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка модели деталей экспоната на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="exhibitDetails">Детали экспоната</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateExhibitDetailsValidateAndThrowAsync(
        DataContext dataContext,
        MuseumExhibitDetails exhibitDetails,
        CancellationToken cancellationToken = default);
}
