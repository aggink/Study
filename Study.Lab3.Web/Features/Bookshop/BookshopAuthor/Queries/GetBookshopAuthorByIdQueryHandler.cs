using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Queries;

public sealed class GetBookshopAuthorByIdQueryHandler
    : IRequestHandler<GetBookshopAuthorByIdQuery, BookshopAuthorDto?>
{
    private readonly IBookshopAuthorService _svc;
    public GetBookshopAuthorByIdQueryHandler(IBookshopAuthorService svc) => _svc = svc;

    public async Task<BookshopAuthorDto?> Handle(GetBookshopAuthorByIdQuery q, CancellationToken ct)
    {
        var a = await _svc.GetByIdAsync(q.AuthorId, ct);
        return a is null ? null : new BookshopAuthorDto(a.AuthorId, a.Name, a.BirthYear);
    }
}
