using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public class UpdateBookshopGenreCommand : IRequest<BookshopGenreDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
