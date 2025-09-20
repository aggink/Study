using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Albums.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Albums.Commands;

/// <summary>
/// Обновление музыкального альбома
/// </summary>
public sealed class UpdateMusicAlbumCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные альбома
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMusicAlbumDto Album { get; init; }
}

public sealed class UpdateMusicAlbumCommandHandler : IRequestHandler<UpdateMusicAlbumCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMusicAlbumService _albumService;

    public UpdateMusicAlbumCommandHandler(
        DataContext dataContext,
        IMusicAlbumService albumService)
    {
        _dataContext = dataContext;
        _albumService = albumService;
    }

    public async Task<Guid> Handle(UpdateMusicAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = await _dataContext.MusicAlbums
                        .FirstOrDefaultAsync(x => x.IsnAlbum == request.Album.IsnAlbum, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Альбом с идентификатором \"{request.Album.IsnAlbum}\" не существует");

        album.Title = request.Album.Title;
        album.Genre = request.Album.Genre;
        album.ReleaseYear = request.Album.ReleaseYear;
        album.Price = request.Album.Price;
        album.Duration = request.Album.Duration;

        await _albumService.CreateOrUpdateAlbumValidateAndThrowAsync(
            _dataContext, album, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return album.IsnAlbum;
    }
}