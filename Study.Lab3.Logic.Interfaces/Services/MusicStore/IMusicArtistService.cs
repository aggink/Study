using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;

namespace Study.Lab3.Logic.Interfaces.Services.MusicStore;

public interface IMusicArtistService
{
    /// <summary>
    /// Проверка модели исполнителя на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="artist">Исполнитель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateArtistValidateAndThrowAsync(
        DataContext dataContext,
        MusicArtist artist,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления исполнителя
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="artist">Исполнитель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MusicArtist artist,
        CancellationToken cancellationToken = default);
}
