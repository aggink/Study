using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;

namespace Study.Lab3.Web.Features.AsianComics.Manga.Queries;

public sealed class GetListMangaQuery : IRequest<MangaDto[]>
{

}

public sealed class GetListMangasQueryHandler : IRequestHandler<GetListMangaQuery, MangaDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMangasQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MangaDto[]> Handle(GetListMangaQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Manga
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .Select(x => new MangaDto
            {
                IsnBook = x.IsnBook,
                Title = x.Title,
                PublicationYear = x.PublicationYear
            })
            .ToArrayAsync(cancellationToken);
    }
}