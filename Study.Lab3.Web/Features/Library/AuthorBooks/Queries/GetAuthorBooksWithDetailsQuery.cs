using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.AuthorBooks.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.AuthorBooks.Queries;

/// <summary>
/// Получение списка книг автора с детальной информацией
/// </summary>
public sealed class GetAuthorBooksWithDetailsQuery : IRequest<AuthorBookWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAuthor { get; init; }
}

public sealed class GetAuthorBooksWithDetailsQueryHandler : IRequestHandler<GetAuthorBooksWithDetailsQuery, AuthorBookWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetAuthorBooksWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AuthorBookWithDetailsDto[]> Handle(GetAuthorBooksWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.AuthorBooks
            .AsNoTracking()
            .Where(x => x.IsnAuthor == request.IsnAuthor)
            .Select(ab => new AuthorBookWithDetailsDto
            {
                IsnAuthor = ab.IsnAuthor,
                AuthorFullName = $"{ab.Author.SurName} {ab.Author.Name} {ab.Author.PatronymicName}",
                Sex = ab.Author.Sex,
                IsnTeacher = ab.Author.IsnTeacher,
                IsnBook = ab.IsnBook,
                Title = ab.Book.Title,
                PublicationYear = ab.Book.PublicationYear
            }).ToArrayAsync(cancellationToken);
    }
}
