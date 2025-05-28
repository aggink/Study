using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.AuthorBooks.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.AuthorBooks.Queries;

/// <summary>
/// Получение списка книг по автору
/// </summary>
public sealed class GetBooksByAuthorQuery : IRequest<AuthorBookWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAuthor { get; init; }
}

public sealed class GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, AuthorBookWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetBooksByAuthorQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AuthorBookWithDetailsDto[]> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _dataContext.Authors.FirstOrDefaultAsync(x => x.IsnAuthor == request.IsnAuthor, cancellationToken)
                     ?? throw new BusinessLogicException($"Автора с идентификатором \"{request.IsnAuthor}\" не существует");

        var booksWithLinks = await _dataContext.AuthorBooks
            .Where(a => a.IsnAuthor == request.IsnAuthor)
            .Join(
                _dataContext.Books,
                a => a.IsnBook,
                b => b.IsnBook,
                (authorBook, book) => new { AuthorBook = authorBook, Book = book }
            )
            .ToListAsync(cancellationToken);

        var result = booksWithLinks
            .OrderBy(b => b.Book.Title)
            .Select(b => new AuthorBookWithDetailsDto
            {
                IsnAuthor = b.AuthorBook.IsnAuthor,
                IsnBook = b.Book.IsnBook,
                Title = b.Book.Title,
                PublicationYear = b.Book.PublicationYear
            })
            .ToArray();

        return result;
    }
}
