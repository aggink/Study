using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public sealed class DeleteBookshopAuthorCommandHandler
        : IRequestHandler<DeleteBookshopAuthorCommand, bool>
{
    private readonly IBookshopAuthorService _authorSvc;
    private readonly IBookshopBookService   _bookSvc;

    public DeleteBookshopAuthorCommandHandler(
        IBookshopAuthorService authorSvc,
        IBookshopBookService   bookSvc)
    {
        _authorSvc = authorSvc;
        _bookSvc   = bookSvc;
    }

    public async Task<bool> Handle(DeleteBookshopAuthorCommand req,
                                   CancellationToken ct)
    {
        // есть ли книги у автора?
        if (await _bookSvc.ExistsByAuthorAsync(req.AuthorId, ct))
            return false;

        return await _authorSvc.DeleteAsync(req.AuthorId, ct);
    }
}
