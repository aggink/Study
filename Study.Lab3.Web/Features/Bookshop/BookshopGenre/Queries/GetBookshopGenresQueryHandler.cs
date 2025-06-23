using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Queries;

public class GetBookshopGenresQueryHandler : IRequestHandler<GetBookshopGenresQuery, IEnumerable<BookshopGenreDto>>
{
    private readonly IBookshopGenreService _genreService;

    public GetBookshopGenresQueryHandler(IBookshopGenreService genreService)
    {
        _genreService = genreService;
    }

    public Task<IEnumerable<BookshopGenreDto>> Handle(GetBookshopGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = _genreService.GetAll().Select(g => new BookshopGenreDto
        {
            Id = g.Id,
            Name = g.Name
        });

        return Task.FromResult(genres);
    }
}
