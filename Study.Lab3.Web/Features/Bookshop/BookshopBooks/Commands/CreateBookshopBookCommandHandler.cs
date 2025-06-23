using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

public class CreateBookshopBookCommandHandler : IRequestHandler<CreateBookshopBookCommand, BookshopBookDto>
{
    private readonly IBookshopBookService _bookService;

    public CreateBookshopBookCommandHandler(IBookshopBookService bookService)
    {
        _bookService = bookService;
    }

    public Task<BookshopBookDto> Handle(CreateBookshopBookCommand request, CancellationToken cancellationToken)
    {
        // Временная заглушка — "создаём" и возвращаем объект
        var newBook = new BookshopBookDto
        {
            Id = new Random().Next(1000, 9999),
            Title = request.Title,
            Pages = request.Pages
        };

        return Task.FromResult(newBook);
    }
}
