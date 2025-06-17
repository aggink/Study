using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Albums.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Albums.Queries;

/// <summary>
/// Получение списка альбомов
/// </summary>
public sealed class GetListMusicAlbumsQuery : IRequest<MusicAlbumDto[]>
{
}

public sealed class GetListMusicAlbumsQueryHandler : IRequestHandler<GetListMusicAlbumsQuery, MusicAlbumDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMusicAlbumsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MusicAlbumDto[]> Handle(GetListMusicAlbumsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.MusicAlbums
            .AsNoTracking()
            .Select(x => new MusicAlbumDto
            {
                IsnAlbum = x.IsnAlbum,
                Title = x.Title,
                Genre = x.Genre,
                ReleaseYear = x.ReleaseYear,
                Price = x.Price,
                Duration = x.Duration,
                CreatedDate = x.CreatedDate
            })
            .OrderBy(x => x.Title)
            .ToArrayAsync(cancellationToken);
    }
}