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
        var author = _dataContext.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnAuthor == request.IsnAuthor, cancellationToken)
            ?? throw new BusinessLogicException($"Автора с идентификатором \"{request.IsnAuthor}\" не существует");

        return await _dataContext.AuthorBooks
            .AsNoTracking().Where(x => x.IsnAuthor == request.IsnAuthor)
            .Select(ba => new AuthorBookWithDetailsDto
            {
                IsnAuthor = ba.IsnAuthor,
                AuthorFullName = $"{ba.Author.SurName} {ba.Author.Name} {ba.Author.PatronymicName}",
                Sex = ba.Author.Sex,
                IsnTeacher = ba.Author.IsnTeacher,
                IsnBook = ba.IsnBook,
                Title = ba.Book.Title,
                PublicationYear = ba.Book.PublicationYear
            })
            .OrderBy(x => x.Title)
            .ToArrayAsync(cancellationToken);
    }
}
