using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Albums.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Albums.Queries;

/// <summary>
/// Получить альбом по идентификатору
/// </summary>
public sealed class GetMusicAlbumByIsnQuery : IRequest<MusicAlbumDto>
{
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAlbum { get; init; }
}

public sealed class GetMusicAlbumByIsnQueryHandler : IRequestHandler<GetMusicAlbumByIsnQuery, MusicAlbumDto>
{
    private readonly DataContext _dataContext;

    public GetMusicAlbumByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MusicAlbumDto> Handle(GetMusicAlbumByIsnQuery request, CancellationToken cancellationToken)
    {
        var album = await _dataContext.MusicAlbums
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.IsnAlbum == request.IsnAlbum, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Альбом с идентификатором \"{request.IsnAlbum}\" не существует");

        return new MusicAlbumDto
        {
            IsnAlbum = album.IsnAlbum,
            Title = album.Title,
            Genre = album.Genre,
            ReleaseYear = album.ReleaseYear,
            Price = album.Price,
            Duration = album.Duration,
            CreatedDate = album.CreatedDate
        };
    }
}