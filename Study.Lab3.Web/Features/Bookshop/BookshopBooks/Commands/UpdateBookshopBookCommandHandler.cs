using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

public class UpdateBookshopBookCommandHandler : IRequestHandler<UpdateBookshopBookCommand, BookshopBookDto>
{
    public Task<BookshopBookDto> Handle(UpdateBookshopBookCommand request, CancellationToken cancellationToken)
    {
        // В реальности тут было бы обновление в БД.
        var updated = new BookshopBookDto
        {
            Id = request.Id,
            Title = request.Title,
            Pages = request.Pages
        };

        return Task.FromResult(updated);
    }
}
