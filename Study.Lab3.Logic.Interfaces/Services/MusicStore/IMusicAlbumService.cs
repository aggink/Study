using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;

namespace Study.Lab3.Logic.Interfaces.Services.MusicStore;

public interface IMusicAlbumService
{
    /// <summary>
    /// Проверка модели альбома на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="album">Альбом</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateAlbumValidateAndThrowAsync(
        DataContext dataContext,
        MusicAlbum album,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления альбома
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="album">Альбом</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MusicAlbum album,
        CancellationToken cancellationToken = default);
}
