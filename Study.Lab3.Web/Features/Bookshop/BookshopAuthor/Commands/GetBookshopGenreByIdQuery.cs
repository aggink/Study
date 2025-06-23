using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Queries;

public class GetBookshopGenreByIdQuery : IRequest<BookshopGenreDto>
{
    public int Id { get; set; }
}
