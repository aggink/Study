using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Queries;

public sealed class GetBookshopGenreByIdQueryHandler
    : IRequestHandler<GetBookshopGenreByIdQuery, BookshopGenreDto?>
{
    private readonly IBookshopGenreService _svc;
    public GetBookshopGenreByIdQueryHandler(IBookshopGenreService svc) => _svc = svc;

    public async Task<BookshopGenreDto?> Handle(GetBookshopGenreByIdQuery q, CancellationToken ct)
    {
        var g = await _svc.GetByIdAsync(q.GenreId, ct);
        return g is null ? null : new BookshopGenreDto(g.GenreId, g.Name);
    }
}
