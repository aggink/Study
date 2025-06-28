using MediatR;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using BookshopGenreModel = Study.Lab3.Storage.Models.Bookshop.BookshopGenre; 
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public sealed class CreateBookshopGenreCommandHandler
    : IRequestHandler<CreateBookshopGenreCommand, BookshopGenreDto>
{
    private readonly IBookshopGenreService _svc;
    public CreateBookshopGenreCommandHandler(IBookshopGenreService svc) => _svc = svc;

    public async Task<BookshopGenreDto> Handle(CreateBookshopGenreCommand req, CancellationToken ct)
    {
        var entity = new BookshopGenreModel { Name = req.Name ?? string.Empty };

        entity = await _svc.CreateAsync(entity, ct);

        return new BookshopGenreDto(entity.GenreId, entity.Name);
    }
}
