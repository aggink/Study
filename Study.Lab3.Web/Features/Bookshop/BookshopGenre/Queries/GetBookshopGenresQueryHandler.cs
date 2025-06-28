using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Queries;

public sealed class GetBookshopGenresQueryHandler
    : IRequestHandler<GetBookshopGenresQuery, IEnumerable<BookshopGenreDto>>
{
    private readonly IBookshopGenreService _svc;
    public GetBookshopGenresQueryHandler(IBookshopGenreService svc) => _svc = svc;

    public async Task<IEnumerable<BookshopGenreDto>> Handle(GetBookshopGenresQuery _, CancellationToken ct)
    {
        var list = await _svc.GetAllAsync(ct);
        return list.Select(g => new BookshopGenreDto(g.GenreId, g.Name));
    }
}
