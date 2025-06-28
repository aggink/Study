using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

public sealed class UpdateBookshopBookCommandHandler
    : IRequestHandler<UpdateBookshopBookCommand, BookshopBookDto?>
{
    private readonly IBookshopBookService _svc;
    public UpdateBookshopBookCommandHandler(IBookshopBookService svc) => _svc = svc;

    public async Task<BookshopBookDto?> Handle(UpdateBookshopBookCommand req, CancellationToken ct)
    {
        var entity = await _svc.GetByIdAsync(req.BookId, ct);
        if (entity is null) return null;

        entity.Title    = req.Title    ?? entity.Title;
        entity.Pages    = req.Pages    ?? entity.Pages;
        entity.AuthorId = req.AuthorId ?? entity.AuthorId;
        entity.GenreId  = req.GenreId  ?? entity.GenreId;

        entity = await _svc.UpdateAsync(entity, ct);

        return new BookshopBookDto(entity.BookId, entity.Title, entity.Pages,
                                   entity.AuthorId, entity.GenreId);
    }
}
