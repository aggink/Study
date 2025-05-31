using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface ISportclubService
{
    /// <summary>
    /// Проверка модели спортивного клуба на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sportclub">Спортивный клуб</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateSportclubValidateAndThrowAsync(
        DataContext dataContext,
        Sportclub sportclub,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления соревнований спортивного клуба
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sportclub">Спортивный клуб</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Sportclub sportclub,
        CancellationToken cancellationToken = default);
}