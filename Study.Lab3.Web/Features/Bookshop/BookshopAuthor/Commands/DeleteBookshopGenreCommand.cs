using MediatR;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public class DeleteBookshopGenreCommand : IRequest<bool>
{
    public int Id { get; set; }
}
