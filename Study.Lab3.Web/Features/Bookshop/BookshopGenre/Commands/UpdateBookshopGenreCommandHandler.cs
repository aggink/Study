using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using ModelGenre = Study.Lab3.Storage.Models.Bookshop.BookshopGenre;          
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public sealed class UpdateBookshopGenreCommandHandler
    : IRequestHandler<UpdateBookshopGenreCommand, BookshopGenreDto?>
{
    private readonly IBookshopGenreService _svc;
    public UpdateBookshopGenreCommandHandler(IBookshopGenreService svc) => _svc = svc;

    public async Task<BookshopGenreDto?> Handle(UpdateBookshopGenreCommand req,
                                                CancellationToken ct)
    {
        var existing = await _svc.GetByIdAsync(req.GenreId, ct);
        if (existing is null) return null;

        existing.Name = req.Name ?? existing.Name;

        existing = await _svc.UpdateAsync(existing, ct);

        return new BookshopGenreDto(existing.GenreId, existing.Name);
    }
}
