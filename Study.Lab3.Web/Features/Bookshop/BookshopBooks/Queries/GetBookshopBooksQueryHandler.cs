using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Models.Bookshop;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.Queries;
namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

public class GetBookshopBooksQueryHandler : IRequestHandler<GetBookshopBooksQuery, IEnumerable<BookshopBookDto>>
{
    private readonly IBookshopBookService _bookService;

    public GetBookshopBooksQueryHandler(IBookshopBookService bookService)
    {
        _bookService = bookService;
    }

    public Task<IEnumerable<BookshopBookDto>> Handle(GetBookshopBooksQuery request, CancellationToken cancellationToken)
    {
        var books = _bookService.GetAll()
            .Cast<BookshopBook>()
            .Select(b => new BookshopBookDto
            {
                Id = b.Id,
                Title = b.Title,
                Pages = b.Pages
            });

        return Task.FromResult(books);
    }
}
