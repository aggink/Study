using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.MusicStore.Artists.Commands;

/// <summary>
/// Удаление музыкального исполнителя
/// </summary>
public sealed class DeleteMusicArtistCommand : IRequest
{
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnArtist { get; init; }
}

public sealed class DeleteMusicArtistCommandHandler : IRequestHandler<DeleteMusicArtistCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMusicArtistService _artistService;

    public DeleteMusicArtistCommandHandler(
        DataContext dataContext,
        IMusicArtistService artistService)
    {
        _dataContext = dataContext;
        _artistService = artistService;
    }

    public async Task Handle(DeleteMusicArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = await _dataContext.MusicArtists
                         .FirstOrDefaultAsync(x => x.IsnArtist == request.IsnArtist, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Исполнитель с идентификатором \"{request.IsnArtist}\" не существует");

        await _artistService.CanDeleteAndThrowAsync(_dataContext, artist, cancellationToken);

        _dataContext.MusicArtists.Remove(artist);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}