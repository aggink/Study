using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Models.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

public sealed class CreateBookshopBookCommandHandler
    : IRequestHandler<CreateBookshopBookCommand, BookshopBookDto>
{
    private readonly IBookshopBookService _svc;
    public CreateBookshopBookCommandHandler(IBookshopBookService svc) => _svc = svc;

    public async Task<BookshopBookDto> Handle(CreateBookshopBookCommand req, CancellationToken ct)
    {
        var entity = new BookshopBook
        {
            Title    = req.Title,
            Pages    = req.Pages,
            AuthorId = req.AuthorId,
            GenreId  = req.GenreId
        };

        entity = await _svc.CreateAsync(entity, ct);

        return new BookshopBookDto(entity.BookId, entity.Title, entity.Pages,
                                   entity.AuthorId, entity.GenreId);
    }
}
