using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Artists.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Artists.Commands;

/// <summary>
/// Обновление музыкального исполнителя
/// </summary>
public sealed class UpdateMusicArtistCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные исполнителя
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMusicArtistDto Artist { get; init; }
}

public sealed class UpdateMusicArtistCommandHandler : IRequestHandler<UpdateMusicArtistCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMusicArtistService _artistService;

    public UpdateMusicArtistCommandHandler(
        DataContext dataContext,
        IMusicArtistService artistService)
    {
        _dataContext = dataContext;
        _artistService = artistService;
    }

    public async Task<Guid> Handle(UpdateMusicArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = await _dataContext.MusicArtists
                         .FirstOrDefaultAsync(x => x.IsnArtist == request.Artist.IsnArtist, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Исполнитель с идентификатором \"{request.Artist.IsnArtist}\" не существует");

        artist.Name = request.Artist.Name;
        artist.Country = request.Artist.Country;
        artist.BirthYear = request.Artist.BirthYear;
        artist.Genre = request.Artist.Genre;
        artist.ArtistType = request.Artist.ArtistType;
        artist.Biography = request.Artist.Biography;

        await _artistService.CreateOrUpdateArtistValidateAndThrowAsync(
            _dataContext, artist, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return artist.IsnArtist;
    }
}