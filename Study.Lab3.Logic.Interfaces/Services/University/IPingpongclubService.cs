using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IPingpongclubService
{
    /// <summary>
    /// Проверка модели спортивного клуба на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="Pingpongclub">Спортивный клуб</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdatePingpongclubValidateAndThrowAsync(
        DataContext dataContext,
        Pingpongclub Pingpongclub,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления соревнований спортивного клуба
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="Pingpongclub">Спортивный клуб</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Pingpongclub Pingpongclub,
        CancellationToken cancellationToken = default);
}