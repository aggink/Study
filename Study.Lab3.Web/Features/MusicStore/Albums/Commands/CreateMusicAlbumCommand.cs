using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;
using Study.Lab3.Web.Features.MusicStore.Albums.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Albums.Commands;

/// <summary>
/// Создание музыкального альбома
/// </summary>
public sealed class CreateMusicAlbumCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные альбома
    /// </summary>
    [Required]
    [FromBody]
    public CreateMusicAlbumDto Album { get; init; }
}

public sealed class CreateMusicAlbumCommandHandler : IRequestHandler<CreateMusicAlbumCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMusicAlbumService _albumService;

    public CreateMusicAlbumCommandHandler(
        DataContext dataContext,
        IMusicAlbumService albumService)
    {
        _dataContext = dataContext;
        _albumService = albumService;
    }

    public async Task<Guid> Handle(CreateMusicAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = new MusicAlbum
        {
            IsnAlbum = Guid.NewGuid(),
            Title = request.Album.Title,
            Genre = request.Album.Genre,
            ReleaseYear = request.Album.ReleaseYear,
            Price = request.Album.Price,
            Duration = request.Album.Duration,
            CreatedDate = DateTime.UtcNow
        };

        await _albumService.CreateOrUpdateAlbumValidateAndThrowAsync(
            _dataContext, album, cancellationToken);

        await _dataContext.MusicAlbums.AddAsync(album, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return album.IsnAlbum;
    }
}