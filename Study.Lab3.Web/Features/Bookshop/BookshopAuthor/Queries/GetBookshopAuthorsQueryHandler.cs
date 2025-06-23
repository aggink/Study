using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Queries;

public class GetBookshopAuthorsQueryHandler : IRequestHandler<GetBookshopAuthorsQuery, IEnumerable<BookshopAuthorDto>>
{
    private readonly IBookshopAuthorService _authorService;

    public GetBookshopAuthorsQueryHandler(IBookshopAuthorService authorService)
    {
        _authorService = authorService;
    }

    public Task<IEnumerable<BookshopAuthorDto>> Handle(GetBookshopAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = _authorService.GetAll()
            .Cast<Study.Lab3.Storage.Models.Bookshop.BookshopAuthor>()
            .Select(a => new BookshopAuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                BirthYear = a.BirthYear
            });

        return Task.FromResult(authors);
    }
}
