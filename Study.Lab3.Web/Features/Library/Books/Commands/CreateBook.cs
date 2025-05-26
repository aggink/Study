using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Books.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Books.Commands;

/// <summary>
/// Создание книги
/// </summary>
public sealed class CreateBookCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные книги
    /// </summary>
    [FromBody]
    [Required]
    public CreateBookDto Book { get; init; }
}

public sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IBookService _bookService;

    public CreateBookCommandHandler(
        DataContext dataContext, IBookService bookService)
    {
        _dataContext = dataContext;
        _bookService = bookService;
    }

    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Storage.Models.Library.Books
        {
            IsnBook = Guid.NewGuid(),
            Title = request.Book.Title,
            PublicationYear = request.Book.PublicationYear,
            Genre = request.Book.Genre,
        };

        await _bookService.CreateOrUpdateBookValidateAndThrowAsync(_dataContext, book, cancellationToken);

        await _dataContext.Books.AddAsync(book, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return book.IsnBook;
    }
}

