using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

public class CreateBookshopBookCommand : IRequest<BookshopBookDto>
{
    public string  Title  { get; set; } = null!;
    public int     Pages  { get; set; }
    public int     AuthorId { get; set; }
    public int     GenreId  { get; set; }
}
