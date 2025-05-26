using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Authors.DtoModels;
using Study.Lab3.Web.Features.Library.Books.DtoModels;

namespace Study.Lab3.Web.Features.Library.Books.Queries;

/// <summary>
/// Получить книгу с авторами
/// </summary>
public sealed class GetListBooksWithAuthorsQuery : IRequest<BookWithAuthorsItemDto[]>
{

}

public sealed class GetListBooksWithAuthorsQueryHandler : IRequestHandler<GetListBooksWithAuthorsQuery, BookWithAuthorsItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListBooksWithAuthorsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<BookWithAuthorsItemDto[]> Handle(GetListBooksWithAuthorsQuery request, CancellationToken cancellationToken)
    {
        var books = await _dataContext.Books.Select(book => new BookWithAuthorsItemDto
        {
            IsnBook = book.IsnBook,
            Title = book.Title,
            PublicationYear = book.PublicationYear,
            Authors = book.AuthorBook.Select(author => new AuthorItemDto
            {
                IsnAuthor = author.IsnAuthor,
                SurName = author.Author.SurName,
                Name = author.Author.Name,
                PatronymicName = author.Author.PatronymicName
            }).ToArray()
        }).OrderBy(x => x.Title).ToArrayAsync(cancellationToken);

        return books;
    }
}