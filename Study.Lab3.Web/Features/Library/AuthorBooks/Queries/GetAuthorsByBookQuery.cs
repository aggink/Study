using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.AuthorBooks.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.AuthorBooks.Queries;

/// <summary>
/// Получение списка авторов по книге
/// </summary>
public sealed class GetAuthorsByBookQuery : IRequest<AuthorBookWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class GetAuthorsByBookQueryHandler : IRequestHandler<GetAuthorsByBookQuery, AuthorBookWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetAuthorsByBookQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AuthorBookWithDetailsDto[]> Handle(GetAuthorsByBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _dataContext.Books.FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
                   ?? throw new BusinessLogicException($"Книги с идентификатором \"{request.IsnBook}\" не существует");

        var authorsWithLinks = await _dataContext.AuthorBooks
            .Where(a => a.IsnBook == request.IsnBook)
            .Join(
                _dataContext.Authors,
                a => a.IsnAuthor,
                a => a.IsnAuthor,
                (authorBook, author) => new { AuthorBook = authorBook, Author = author }
            )
            .ToListAsync(cancellationToken);

        var result = authorsWithLinks
            .OrderBy(a => a.Author.SurName + " " + a.Author.Name + " " + a.Author.PatronymicName)
            .Select(a => new AuthorBookWithDetailsDto
            {
                IsnAuthor = a.Author.IsnAuthor,
                IsnBook = a.AuthorBook.IsnBook,
                AuthorFullName = $"{a.Author.SurName} {a.Author.Name} {a.Author.PatronymicName}",
                Sex = a.Author.Sex
            })
            .ToArray();

        return result;
    }
}
