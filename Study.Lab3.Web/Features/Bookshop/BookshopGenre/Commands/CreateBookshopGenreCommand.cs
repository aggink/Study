using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

public class CreateBookshopGenreCommand : IRequest<BookshopGenreDto>
{
    public string Name { get; set; }
}