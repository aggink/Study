using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Artists.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Artists.Queries;

/// <summary>
/// Получение списка исполнителей
/// </summary>
public sealed class GetListMusicArtistsQuery : IRequest<MusicArtistDto[]>
{
}

public sealed class GetListMusicArtistsQueryHandler : IRequestHandler<GetListMusicArtistsQuery, MusicArtistDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMusicArtistsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MusicArtistDto[]> Handle(GetListMusicArtistsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.MusicArtists
            .AsNoTracking()
            .Select(x => new MusicArtistDto
            {
                IsnArtist = x.IsnArtist,
                Name = x.Name,
                Country = x.Country,
                BirthYear = x.BirthYear,
                Genre = x.Genre,
                ArtistType = x.ArtistType,
                Biography = x.Biography,
                CreatedDate = x.CreatedDate
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}