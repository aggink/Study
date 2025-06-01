using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Books.Commands;

/// <summary>
/// Удаление книги
/// </summary>
public sealed class DeleteBookCommand : IRequest
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly DataContext _dataContext;
    private readonly IBookService _bookService;

    public DeleteBookCommandHandler(DataContext dataContext, IBookService bookService)
    {
        _dataContext = dataContext;
        _bookService = bookService;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _dataContext.Books.FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
             ?? throw new BusinessLogicException($"Книги с идентификатором \"{request.IsnBook}\" не существует");

        _dataContext.Books.Remove(book);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
