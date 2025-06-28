using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Models.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public sealed class UpdateBookshopAuthorCommandHandler
    : IRequestHandler<UpdateBookshopAuthorCommand, BookshopAuthorDto?>
{
    private readonly IBookshopAuthorService _svc;
    public UpdateBookshopAuthorCommandHandler(IBookshopAuthorService svc) => _svc = svc;

    public async Task<BookshopAuthorDto?> Handle(UpdateBookshopAuthorCommand req, CancellationToken ct)
    {
        var entity = await _svc.GetByIdAsync(req.AuthorId, ct);
        if (entity is null) return null;

        entity.Name      = req.Name      ?? entity.Name;
        entity.BirthYear = req.BirthYear ?? entity.BirthYear;

        entity = await _svc.UpdateAsync(entity, ct);

        return new BookshopAuthorDto(entity.AuthorId, entity.Name, entity.BirthYear);
    }
}
