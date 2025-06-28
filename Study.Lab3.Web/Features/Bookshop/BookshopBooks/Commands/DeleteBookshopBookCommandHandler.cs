using MediatR;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

public class DeleteBookshopBookCommandHandler : IRequestHandler<DeleteBookshopBookCommand, bool>
{
    public Task<bool> Handle(DeleteBookshopBookCommand request, CancellationToken cancellationToken)
    {
        // В реальности удалили бы из БД. Здесь заглушка.
        return Task.FromResult(true);
    }
}
