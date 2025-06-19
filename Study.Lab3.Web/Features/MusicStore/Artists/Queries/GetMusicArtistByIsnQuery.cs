using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Artists.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Artists.Queries;

/// <summary>
/// Получить исполнителя по идентификатору
/// </summary>
public sealed class GetMusicArtistByIsnQuery : IRequest<MusicArtistDto>
{
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnArtist { get; init; }
}

public sealed class GetMusicArtistByIsnQueryHandler : IRequestHandler<GetMusicArtistByIsnQuery, MusicArtistDto>
{
    private readonly DataContext _dataContext;

    public GetMusicArtistByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MusicArtistDto> Handle(GetMusicArtistByIsnQuery request, CancellationToken cancellationToken)
    {
        var artist = await _dataContext.MusicArtists
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.IsnArtist == request.IsnArtist, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Исполнитель с идентификатором \"{request.IsnArtist}\" не существует");

        return new MusicArtistDto
        {
            IsnArtist = artist.IsnArtist,
            Name = artist.Name,
            Country = artist.Country,
            BirthYear = artist.BirthYear,
            Genre = artist.Genre,
            ArtistType = artist.ArtistType,
            Biography = artist.Biography,
            CreatedDate = artist.CreatedDate
        };
    }
}