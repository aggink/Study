using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Queries;

public class GetBookshopGenresQuery : IRequest<IEnumerable<BookshopGenreDto>>;
