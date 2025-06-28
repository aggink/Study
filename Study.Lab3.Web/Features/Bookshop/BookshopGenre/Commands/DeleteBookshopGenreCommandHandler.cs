using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public sealed class DeleteBookshopGenreCommandHandler
        : IRequestHandler<DeleteBookshopGenreCommand, bool>
{
    private readonly IBookshopGenreService _genreSvc;
    private readonly IBookshopBookService  _bookSvc;

    public DeleteBookshopGenreCommandHandler(
        IBookshopGenreService genreSvc,
        IBookshopBookService  bookSvc)
    {
        _genreSvc = genreSvc;
        _bookSvc  = bookSvc;
    }

    public async Task<bool> Handle(DeleteBookshopGenreCommand req,
                                   CancellationToken ct)
    {
        if (await _bookSvc.ExistsByGenreAsync(req.GenreId, ct))
            return false;

        return await _genreSvc.DeleteAsync(req.GenreId, ct);
    }
}
