using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.Commands;

/// <summary>
/// Создание связи книги с автором
/// </summary>
public sealed class AddBookAndAuthorCommand : IRequest
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [Required]
    public Guid IsnBook { get; init; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    public Guid IsnAuthor { get; init; }
}

public sealed class AddBookAndAuthorCommandHandler : IRequest<AddBookAndAuthorCommand>
{
    private readonly DataContext _dataContext;

    public AddBookAndAuthorCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(AddBookAndAuthorCommand request, CancellationToken cancellationToken)
    {
        var book = await _dataContext.Books.FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
            ?? throw new BusinessLogicException($"Книги с идентификатором \"{request.IsnBook}\" не существует");

        var author = await _dataContext.Authors.FirstOrDefaultAsync(x => x.IsnAuthor == request.IsnAuthor, cancellationToken)
            ?? throw new BusinessLogicException($"Автора с идентификатором \"{request.IsnAuthor}\" не существует");

        if (await _dataContext.AuthorBooks.AnyAsync(x => x.IsnBook == request.IsnBook && x.IsnAuthor == request.IsnAuthor, cancellationToken))
            throw new BusinessLogicException($"Книга с идентификатором \"{request.IsnBook}\" уже привязана к автору с идентификатором \"{request.IsnAuthor}\"");

        var link = new Storage.Models.Library.AuthorBooks
        {
            IsnAuthor = request.IsnAuthor,
            IsnBook = request.IsnBook
        };

        await _dataContext.AuthorBooks.AddAsync(link, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return;
    }
}