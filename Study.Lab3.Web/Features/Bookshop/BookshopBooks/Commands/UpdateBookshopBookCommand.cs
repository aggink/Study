using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

public class UpdateBookshopBookCommand : IRequest<BookshopBookDto>
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Pages { get; set; }
}
