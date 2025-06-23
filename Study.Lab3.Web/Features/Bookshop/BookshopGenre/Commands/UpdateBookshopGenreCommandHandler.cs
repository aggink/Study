using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public class UpdateBookshopGenreCommandHandler : IRequestHandler<UpdateBookshopGenreCommand, BookshopGenreDto>
{
    public Task<BookshopGenreDto> Handle(UpdateBookshopGenreCommand request, CancellationToken cancellationToken)
    {
        var updated = new BookshopGenreDto
        {
            Id = request.Id,
            Name = request.Name
        };

        return Task.FromResult(updated);
    }
}
