using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using DbAuthor = Study.Lab3.Storage.Models.Bookshop.BookshopAuthor;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public sealed class CreateBookshopAuthorCommandHandler
    : IRequestHandler<CreateBookshopAuthorCommand, BookshopAuthorDto>
{
    private readonly IBookshopAuthorService _svc;
    public CreateBookshopAuthorCommandHandler(IBookshopAuthorService svc) => _svc = svc;

    public async Task<BookshopAuthorDto> Handle(CreateBookshopAuthorCommand req, CancellationToken ct)
    {
        var entity = new DbAuthor
        {
            Name      = req.Name ?? string.Empty,
            BirthYear = req.BirthYear
        };

        entity = await _svc.CreateAsync(entity, ct);

        return new BookshopAuthorDto(entity.AuthorId, entity.Name, entity.BirthYear);
    }
}
