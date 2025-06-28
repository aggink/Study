using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Queries;

public sealed class GetBookshopBooksQueryHandler
    : IRequestHandler<GetBookshopBooksQuery, IEnumerable<BookshopBookDto>>
{
    private readonly IBookshopBookService _svc;
    public GetBookshopBooksQueryHandler(IBookshopBookService svc) => _svc = svc;

    public async Task<IEnumerable<BookshopBookDto>> Handle(GetBookshopBooksQuery _, CancellationToken ct)
    {
        var list = await _svc.GetAllAsync(ct);
        return list.Select(b => new BookshopBookDto(b.BookId,  b.Title,  b.Pages,
                                                    b.AuthorId, b.GenreId));
    }
}
