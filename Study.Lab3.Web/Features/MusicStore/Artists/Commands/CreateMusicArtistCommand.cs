using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;
using Study.Lab3.Web.Features.MusicStore.Artists.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Artists.Commands;

/// <summary>
/// Создание музыкального исполнителя
/// </summary>
public sealed class CreateMusicArtistCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные исполнителя
    /// </summary>
    [Required]
    [FromBody]
    public CreateMusicArtistDto Artist { get; init; }
}

public sealed class CreateMusicArtistCommandHandler : IRequestHandler<CreateMusicArtistCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMusicArtistService _artistService;

    public CreateMusicArtistCommandHandler(
        DataContext dataContext,
        IMusicArtistService artistService)
    {
        _dataContext = dataContext;
        _artistService = artistService;
    }

    public async Task<Guid> Handle(CreateMusicArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = new MusicArtist
        {
            IsnArtist = Guid.NewGuid(),
            Name = request.Artist.Name,
            Country = request.Artist.Country,
            BirthYear = request.Artist.BirthYear,
            Genre = request.Artist.Genre,
            ArtistType = request.Artist.ArtistType,
            Biography = request.Artist.Biography,
            CreatedDate = DateTime.UtcNow
        };

        await _artistService.CreateOrUpdateArtistValidateAndThrowAsync(
            _dataContext, artist, cancellationToken);

        await _dataContext.MusicArtists.AddAsync(artist, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return artist.IsnArtist;
    }
}