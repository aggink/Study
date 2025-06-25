using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;

namespace Study.Lab3.Logic.Services.MusicStore;

public sealed class MusicAlbumService : IMusicAlbumService
{
    public async Task CreateOrUpdateAlbumValidateAndThrowAsync(
        DataContext dataContext,
        MusicAlbum album,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(album.Title))
            throw new BusinessLogicException("Название альбома не может быть пустым");

        if (string.IsNullOrWhiteSpace(album.Genre))
            throw new BusinessLogicException("Жанр альбома не может быть пустым");

        if (album.Price <= 0)
            throw new BusinessLogicException("Цена альбома должна быть положительным числом");

        if (album.Duration <= 0)
            throw new BusinessLogicException("Продолжительность альбома должна быть положительным числом");

        if (album.ReleaseYear > DateTime.Now.Year)
            throw new BusinessLogicException("Год выпуска не может быть в будущем");

        if (await dataContext.MusicAlbums.AnyAsync(
                x => x.Title == album.Title &&
                     x.IsnAlbum != album.IsnAlbum,
                cancellationToken))
            throw new BusinessLogicException($"Альбом с названием \"{album.Title}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MusicAlbum album,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.MusicAlbums.AnyAsync(x => x.IsnAlbum == album.IsnAlbum, cancellationToken))
            throw new BusinessLogicException($"Альбом с идентификатором \"{album.IsnAlbum}\" не существует");
    }
}
