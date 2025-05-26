using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Books.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Books.Queries;

/// <summary>
/// Получить книгу по идентификатору
/// </summary>
public sealed class GetBookByIsnQuery : IRequest<BookDto>
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class GetBookByIsnQueryHandler : IRequestHandler<GetBookByIsnQuery, BookDto>
{
    private readonly DataContext _dataContext;

    public GetBookByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<BookDto> Handle(GetBookByIsnQuery request, CancellationToken cancellationToken)
    {
        var book = await _dataContext.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
                ?? throw new BusinessLogicException($"Книги с идентификатором \"{request.IsnBook}\" не существует");

        return new BookDto
        {
            IsnBook = book.IsnBook,
            Title = book.Title,
            PublicationYear = book.PublicationYear,
            Genre = book.Genre
        };
    }
}