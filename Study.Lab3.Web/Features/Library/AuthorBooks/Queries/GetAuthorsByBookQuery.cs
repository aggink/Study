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
        var book = await _dataContext.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
            ?? throw new BusinessLogicException($"Книги с идентификатором \"{request.IsnBook}\" не существует");

        return await _dataContext.AuthorBooks
            .AsNoTracking()
            .Where(x => x.IsnBook == request.IsnBook).Select(ab => new AuthorBookWithDetailsDto
            {
                IsnAuthor = ab.IsnAuthor,
                AuthorFullName = $"{ab.Author.SurName} {ab.Author.Name} {ab.Author.PatronymicName}",
                Sex = ab.Author.Sex,
                IsnTeacher = ab.Author.IsnTeacher,
                IsnBook = ab.IsnBook,
                Title = ab.Book.Title,
                PublicationYear = ab.Book.PublicationYear
            })
            .OrderBy(x => x.AuthorFullName)
            .ToArrayAsync(cancellationToken);
    }
}
