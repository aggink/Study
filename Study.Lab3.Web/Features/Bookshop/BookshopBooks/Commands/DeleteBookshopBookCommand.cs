using MediatR;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

public class DeleteBookshopBookCommand : IRequest<bool>
{
    public int Id { get; set; }
}
