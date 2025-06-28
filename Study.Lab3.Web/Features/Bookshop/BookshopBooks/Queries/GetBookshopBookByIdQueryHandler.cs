using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Queries;

public sealed class GetBookshopBookByIdQueryHandler
    : IRequestHandler<GetBookshopBookByIdQuery, BookshopBookDto?>
{
    private readonly IBookshopBookService _svc;
    public GetBookshopBookByIdQueryHandler(IBookshopBookService svc) => _svc = svc;

    public async Task<BookshopBookDto?> Handle(GetBookshopBookByIdQuery q, CancellationToken ct)
    {
        var b = await _svc.GetByIdAsync(q.BookId, ct);
        return b is null ? null : new BookshopBookDto(b.BookId, b.Title, b.Pages,
                                                      b.AuthorId, b.GenreId);
    }
}
