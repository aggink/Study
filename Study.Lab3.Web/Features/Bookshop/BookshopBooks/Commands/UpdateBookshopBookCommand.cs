using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

public sealed class UpdateBookshopBookCommand : IRequest<BookshopBookDto>
{
    public int   BookId   { get; set; }              
    public string Title  { get; set; }
    public int?  Pages    { get; set; }
    public int?  AuthorId { get; set; }
    public int?  GenreId  { get; set; }
}
