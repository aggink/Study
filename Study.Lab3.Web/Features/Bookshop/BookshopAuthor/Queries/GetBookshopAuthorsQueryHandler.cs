using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Queries;

public sealed class GetBookshopAuthorsQueryHandler
    : IRequestHandler<GetBookshopAuthorsQuery, IEnumerable<BookshopAuthorDto>>
{
    private readonly IBookshopAuthorService _svc;
    public GetBookshopAuthorsQueryHandler(IBookshopAuthorService svc) => _svc = svc;

    public async Task<IEnumerable<BookshopAuthorDto>> Handle(GetBookshopAuthorsQuery _, CancellationToken ct)
    {
        var list = await _svc.GetAllAsync(ct);
        return list.Select(a => new BookshopAuthorDto(a.AuthorId, a.Name, a.BirthYear));
    }
}
