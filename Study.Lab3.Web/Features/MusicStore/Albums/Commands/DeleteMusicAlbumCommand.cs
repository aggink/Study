using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.MusicStore.Albums.Commands;

/// <summary>
/// Удаление музыкального альбома
/// </summary>
public sealed class DeleteMusicAlbumCommand : IRequest
{
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAlbum { get; init; }
}

public sealed class DeleteMusicAlbumCommandHandler : IRequestHandler<DeleteMusicAlbumCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMusicAlbumService _albumService;

    public DeleteMusicAlbumCommandHandler(
        DataContext dataContext,
        IMusicAlbumService albumService)
    {
        _dataContext = dataContext;
        _albumService = albumService;
    }

    public async Task Handle(DeleteMusicAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = await _dataContext.MusicAlbums
                        .FirstOrDefaultAsync(x => x.IsnAlbum == request.IsnAlbum, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Альбом с идентификатором \"{request.IsnAlbum}\" не существует");

        await _albumService.CanDeleteAndThrowAsync(_dataContext, album, cancellationToken);

        _dataContext.MusicAlbums.Remove(album);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}