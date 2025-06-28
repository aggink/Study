using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Queries;

public sealed record GetBookshopGenreByIdQuery(int GenreId)
        : IRequest<BookshopGenreDto?>;
