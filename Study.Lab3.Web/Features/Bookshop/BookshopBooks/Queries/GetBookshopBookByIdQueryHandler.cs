using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Queries;

public class GetBookshopBookByIdQueryHandler : IRequestHandler<GetBookshopBookByIdQuery, BookshopBookDto>
{
    private readonly IBookshopBookService _bookService;

    public GetBookshopBookByIdQueryHandler(IBookshopBookService bookService)
    {
        _bookService = bookService;
    }

    public Task<BookshopBookDto> Handle(GetBookshopBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = _bookService.GetAll()
            .FirstOrDefault(b => ((int)b.GetType().GetProperty("Id")!.GetValue(b)!) == request.Id);

        if (book is null)
            throw new Exception($"Книга с ID={request.Id} не найдена");

        var dto = new BookshopBookDto
        {
            Id = (int)book.GetType().GetProperty("Id")!.GetValue(book)!,
            Title = (string)book.GetType().GetProperty("Title")!.GetValue(book)!,
            Pages = (int)book.GetType().GetProperty("Pages")!.GetValue(book)!
        };

        return Task.FromResult(dto);
    }
}
