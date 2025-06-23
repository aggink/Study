using MediatR;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public class DeleteBookshopAuthorCommand : IRequest<bool>
{
    public int Id { get; set; }
}
