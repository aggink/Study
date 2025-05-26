using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Books.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Books.Commands;

/// <summary>
/// Редактирование книги
/// </summary>
public sealed class UpdateBookCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные группы
    /// </summary>
    [Required]
    [FromBody]
    public UpdateBookDto Book { get; init; }
}

public sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IBookService _bookService;

    public UpdateBookCommandHandler(DataContext dataContext, IBookService bookService)
    {
        _dataContext = dataContext;
        _bookService = bookService;
    }

    public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _dataContext.Books.FirstOrDefaultAsync(x => x.IsnBook == request.Book.IsnBook, cancellationToken)
             ?? throw new BusinessLogicException($"Книги с идентификатором \"{request.Book.IsnBook}\" не существует");

        book.Title = request.Book.Title;
        book.PublicationYear = request.Book.PublicationYear;

        await _bookService.CreateOrUpdateBookValidateAndThrowAsync(_dataContext, book, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return book.IsnBook;
    }
}