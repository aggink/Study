using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public class UpdateBookshopAuthorCommandHandler : IRequestHandler<UpdateBookshopAuthorCommand, BookshopAuthorDto>
{
    public Task<BookshopAuthorDto> Handle(UpdateBookshopAuthorCommand request, CancellationToken cancellationToken)
    {
        // Заглушка: "обновляем" и возвращаем
        var updated = new BookshopAuthorDto
        {
            Id = request.Id,
            Name = request.Name,
            BirthYear = request.BirthYear
        };

        return Task.FromResult(updated);
    }
}
