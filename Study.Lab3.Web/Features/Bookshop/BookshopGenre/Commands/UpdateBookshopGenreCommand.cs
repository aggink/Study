using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public sealed class UpdateBookshopGenreCommand : IRequest<BookshopGenreDto>
{
    public int    GenreId { get; set; }             
    public string Name   { get; set; }
}
