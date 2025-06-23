using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public class CreateBookshopAuthorCommandHandler : IRequestHandler<CreateBookshopAuthorCommand, BookshopAuthorDto>
{
    private readonly IBookshopAuthorService _authorService;

    public CreateBookshopAuthorCommandHandler(IBookshopAuthorService authorService)
    {
        _authorService = authorService;
    }

    public Task<BookshopAuthorDto> Handle(CreateBookshopAuthorCommand request, CancellationToken cancellationToken)
    {
        // Временная заглушка
        var newAuthor = new BookshopAuthorDto
        {
            Id = new Random().Next(1000, 9999),
            Name = request.Name,
            BirthYear = request.BirthYear
        };

        return Task.FromResult(newAuthor);
    }
}
