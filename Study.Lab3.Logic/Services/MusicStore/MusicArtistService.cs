using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;

namespace Study.Lab3.Logic.Services.MusicStore;

public sealed class MusicArtistService : IMusicArtistService
{
    public async Task CreateOrUpdateArtistValidateAndThrowAsync(
        DataContext dataContext,
        MusicArtist artist,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(artist.Name))
            throw new BusinessLogicException("Имя исполнителя не может быть пустым");

        if (string.IsNullOrWhiteSpace(artist.Country))
            throw new BusinessLogicException("Страна происхождения не может быть пустой");

        if (string.IsNullOrWhiteSpace(artist.Genre))
            throw new BusinessLogicException("Жанр исполнителя не может быть пустым");

        if (artist.BirthYear.HasValue && artist.BirthYear.Value > DateTime.Now.Year)
            throw new BusinessLogicException("Год рождения/основания не может быть в будущем");

        if (await dataContext.MusicArtists.AnyAsync(
                x => x.Name == artist.Name &&
                     x.IsnArtist != artist.IsnArtist,
                cancellationToken))
            throw new BusinessLogicException($"Исполнитель с именем \"{artist.Name}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MusicArtist artist,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.MusicArtists.AnyAsync(x => x.IsnArtist == artist.IsnArtist, cancellationToken))
            throw new BusinessLogicException($"Исполнитель с идентификатором \"{artist.IsnArtist}\" не существует");
    }
}
