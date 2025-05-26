using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.AuthorBooks.Commands;

/// <summary>
/// Удаление связи Автор-Книга
/// </summary>
public sealed class DeleteAuthorBookCommand : IRequest
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAuthor { get; init; }

    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class DeleteAuthorBookCommandHandler : IRequestHandler<DeleteAuthorBookCommand>
{
    private readonly DataContext _dataContext;
    private readonly IAuthorBookService _authorBookService;

    public DeleteAuthorBookCommandHandler(DataContext dataContext, IAuthorBookService authorBookService)
    {
        _dataContext = dataContext;
        _authorBookService = authorBookService;
    }

    public async Task Handle(DeleteAuthorBookCommand request, CancellationToken cancellationToken)
    {
        var authorBook = await _dataContext.AuthorBooks.FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook && x.IsnAuthor == request.IsnAuthor, cancellationToken)
            ?? throw new BusinessLogicException("Связь Автор-Книга не существует");

        _dataContext.AuthorBooks.Remove(authorBook);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}