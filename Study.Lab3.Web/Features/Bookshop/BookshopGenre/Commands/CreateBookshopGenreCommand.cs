using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public class CreateBookshopGenreCommand : IRequest<BookshopGenreDto>
{
    public string Name { get; set; } = string.Empty;
}
