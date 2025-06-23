using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public class CreateBookshopGenreCommandHandler : IRequestHandler<CreateBookshopGenreCommand, BookshopGenreDto>
{
    private readonly IBookshopGenreService _genreService;

    public CreateBookshopGenreCommandHandler(IBookshopGenreService genreService)
    {
        _genreService = genreService;
    }

    public Task<BookshopGenreDto> Handle(CreateBookshopGenreCommand request, CancellationToken cancellationToken)
    {
        var newGenre = new BookshopGenreDto
        {
            Id = new Random().Next(1000, 9999),
            Name = request.Name
        };

        return Task.FromResult(newGenre);
    }
}
